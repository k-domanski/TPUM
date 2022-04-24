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
        private readonly object _dataLock = new object();

        public LendingsRepository()
        {
            _lendings = new List<ILending>();
        }


        public List<ILending> GetLendings()
        {
            lock (_dataLock)
            {
                return new List<ILending>(_lendings);
            }
        }

        public bool AddLending(ILending lending)
        {
            lock (_dataLock)
            {
                if (_lendings.Contains(lending))
                {
                    return false;
                }

                _lendings.Add(lending);
                onLendingAdded?.Invoke(lending);
                return true;
            }
        }

        public bool RemoveLending(ILending lending)
        {
            lock (_dataLock)
            {
                if (_lendings.Remove(lending))
                {
                    onLendingRemoved?.Invoke(lending);
                    return true;
                }

                return false;
            }
        }

        public List<ILending> FindLendingsByPredicate(Predicate<ILending> predicate)
        {
            lock (_dataLock)
            {
                return _lendings.FindAll(predicate);
            }
        }
    }
}