using System;
using Library.Logic.Interface;

namespace Library.Logic
{
    public struct LendingInfo : ILendingInfo
    {
        public Guid personID { get; set; }
        public Guid bookID { get; set; }
    }
}