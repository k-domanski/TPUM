using System;

namespace Library.Logic.Interface
{
    public interface ILendingInfo
    {
        Guid personID { get; set; }
        Guid bookID { get; set; }
    }
}