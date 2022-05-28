using System.Collections.Generic;
using Library.DataServer.Interface;

namespace Library.LogicServer.Interface
{
    public interface ILendingsManager
    {
        bool CreateLending(LendingInfo initData);
        List<LendingInfo> GetLendings(IFilter<LendingInfo> filter);
        bool UpdateLending(LendingInfo original, LendingInfo updated);
        bool RemoveLending(LendingInfo lending);
    }
}