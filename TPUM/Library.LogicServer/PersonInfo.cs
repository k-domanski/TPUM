using System;
using Library.LogicServer.Interface;

namespace Library.LogicServer
{
    public struct PersonInfo : IPersonInfo
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
    }
}