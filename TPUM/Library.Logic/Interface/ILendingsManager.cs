using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface ILendingsManager
    {
        bool CreateLending(LendingInfo initData);
        List<LendingInfo> GetLendings(IFilter<LendingInfo> filter);
        bool UpdateLending(LendingInfo original, LendingInfo updated);
        bool RemoveLending(LendingInfo lending);
    }
}