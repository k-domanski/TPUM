using System;

namespace Library.Logic
{
    public struct LendingInfo
    {
        public Guid personID { get; set; }
        public Guid bookISBN { get; set; }
    }
}