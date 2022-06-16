using System;
using Library.LogicServer.Interface;

namespace Library.LogicServer
{
    public struct LendingInfo : ILendingInfo
    {
        public Guid personID { get; set; }
        public Guid bookID { get; set; }
    }
}