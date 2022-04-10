using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface ILendingsRepository
    {
        List<ILending> GetLendings();
        bool AddLending(ILending lending);
        bool RemoveLending(ILending lending);
        List<ILending> FindLendingsByPredicate(Predicate<ILending> predicate);
    }
}