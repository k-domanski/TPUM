﻿using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.PresentationServer
{
    public static class WebSocketServer
    {
        public static async Task Server(int p2pPort, Action<WebSocketConnection> onConnection)
        {
            Uri uri = new Uri($@"http://localhost:{p2pPort}/");
            await ServerLoop(uri, onConnection);
        }

        private static async Task ServerLoop(Uri uri, Action<WebSocketConnection> onConnection)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add(uri.ToString());
            server.Start();
            while (true)
            {
                HttpListenerContext hc = await server.GetContextAsync();
                if (!hc.Request.IsWebSocketRequest)
                {
                    hc.Response.StatusCode = 400;
                    hc.Response.Close();
                }
                HttpListenerWebSocketContext context = await hc.AcceptWebSocketAsync(null);
                WebSocketConnection ws = new ServerWebSocketConnection(context.WebSocket, hc.Request.RemoteEndPoint);
                onConnection?.Invoke(ws);
            }
        }

        private class ServerWebSocketConnection : WebSocketConnection
        {
            public ServerWebSocketConnection(WebSocket webSocket, IPEndPoint remoteEndPoint)
            {
                _webSocket = webSocket;
                _remoteEndPoint = remoteEndPoint;
                Task.Factory.StartNew(() => ServerMessageLoop(webSocket));
            }

            protected override Task SendTask(string message)
            {
                return _webSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None);
            }

            public override Task DisconnectAsync()
            {
                return _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
            }


            public override string ToString()
            {
                return _remoteEndPoint.ToString();
            }

            private WebSocket _webSocket = null;
            private IPEndPoint _remoteEndPoint;

            private void ServerMessageLoop(WebSocket ws)
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    ArraySegment<byte> segments = new ArraySegment<byte>(buffer);
                    WebSocketReceiveResult receiveResult = ws.ReceiveAsync(segments, CancellationToken.None).Result;
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        onClose?.Invoke();
                        ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None);
                        return;
                    }
                    int count = receiveResult.Count;
                    while (!receiveResult.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                            onClose?.Invoke();
                            ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                            return;
                        }
                        segments = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        receiveResult = ws.ReceiveAsync(segments, CancellationToken.None).Result;
                        count += receiveResult.Count;
                    }
                    string message = Encoding.UTF8.GetString(buffer, 0, count);
                    onMessage?.Invoke(message);
                }
            }
        }
    }
}