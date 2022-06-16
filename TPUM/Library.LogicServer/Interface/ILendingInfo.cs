using System;

namespace Library.LogicServer.Interface
{
    public interface ILendingInfo
    {
        Guid personID { get; set; }
        Guid bookID { get; set; }
    }
}