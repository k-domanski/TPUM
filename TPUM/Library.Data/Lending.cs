using System;
using Library.Data.Interface;

namespace Library.Data
{
    public class Lending : ILending
    {
        private Guid _personID;
        private Guid _bookID;
        //TODO: Add lending date
        //TODO: Add valid through date

        public Lending(Guid personID, Guid bookID)
        {
            _personID = personID;
            _bookID = bookID;
        }

        public bool Equals(ILending other)
        {
            if (other == null)
            {
                return false;
            }

            return GetPersonID() == other.GetPersonID() && GetBookISBN() == other.GetBookISBN();
        }

        public Guid GetPersonID()
        {
            return _personID;
        }

        public Guid GetBookISBN()
        {
            return _bookID;
        }
    }
}