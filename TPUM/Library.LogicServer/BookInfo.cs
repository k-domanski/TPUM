using System;
using Library.LogicServer.Interface;

namespace Library.LogicServer
{
    public struct BookInfo : IBookInfo
    {
        public Guid id { get; set; }
        public string isbn { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public bool isAvailable { get; set; }
    }
}