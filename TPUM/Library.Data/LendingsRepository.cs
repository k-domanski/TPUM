using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Data
{
    public class LendingsRepository : ILendingsRepository
    {
        private List<ILending> _lendings;

        public LendingsRepository()
        {
            _lendings = new List<ILending>();
        }

        public List<ILending> GetLendings()
        {
            return _lendings;
        }

        public bool AddLending(ILending lending)
        {
            if (_lendings.Contains(lending))
            {
                return false;
            }

            _lendings.Add(lending);
            return true;
        }

        public bool RemoveLending(ILending lending)
        {
            return _lendings.Remove(lending);
        }

        public List<ILending> FindLendingsByPredicate(Predicate<ILending> predicate)
        {
            return _lendings.FindAll(predicate);
        }
    }
}