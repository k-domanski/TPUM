using System;

namespace Library.Logic
{
    public struct LendingInitData
    {
        public Guid personID { get; set; }
        public Guid bookISBN { get; set; }
    }
}