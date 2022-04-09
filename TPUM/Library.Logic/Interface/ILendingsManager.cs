using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface ILendingsManager
    {
        bool CreateLending(LendingInfo initData);
        List<ILending> GetLendings(IFilter<ILending> filter);
        bool UpdateLending(ILending lending, ILendingFactory lendingFactory);
        bool RemoveLending(ILending lending);
    }
}