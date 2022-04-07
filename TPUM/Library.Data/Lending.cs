using System;
using Library.Data.Interface;

namespace Library.Data
{
    public class Lending : ILending
    {
        private Guid _personID;
        private Guid _bookISBN;
        //TODO: Add lending date
        //TODO: Add valid through date

        public Lending(Guid personID, Guid bookISBN)
        {
            _personID = personID;
            _bookISBN = bookISBN;
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
            return _bookISBN;
        }
    }
}