using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Data
{
    public class LendingsRepository : ILendingsRepository
    {
        public event Action<ILending> onLendingAdded;
        public event Action<ILending> onLendingRemoved;

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
            onLendingAdded?.Invoke(lending);
            return true;
        }

        public bool RemoveLending(ILending lending)
        {
            if (_lendings.Remove(lending))
            {
                onLendingRemoved?.Invoke(lending);
                return true;
            }

            return false;
        }

        public List<ILending> FindLendingsByPredicate(Predicate<ILending> predicate)
        {
            return _lendings.FindAll(predicate);
        }
    }
}