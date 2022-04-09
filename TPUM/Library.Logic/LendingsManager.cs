using System.Collections.Generic;
using Library.Data.Interface;
using Library.Logic.Factories;
using Library.Logic.Interface;

namespace Library.Logic
{
    public class LendingsManager : ILendingsManager
    {
        private Library _library;
        public LendingsManager(Library library)
        {
            _library = library;
        }

        public bool CreateLending(LendingInfo initData)
        {
            CreateLendingFactory factory = new CreateLendingFactory(initData);
            return _library.dataLayer.GetLendingsRepository().AddLending(factory.Create());
        }

        public List<ILending> GetLendings(IFilter<ILending> filter)
        {
            return _library.dataLayer.GetLendingsRepository().FindLendingsByPredicate(filter.Match);
        }

        public bool UpdateLending(ILending lending, ILendingFactory lendingFactory)
        {
            ILendingsRepository repository = _library.dataLayer.GetLendingsRepository();
            bool removed = repository.RemoveLending(lending);
            if (!removed)
            {
                return false;
            }
            return repository.AddLending(lendingFactory.Create());
        }

        public bool RemoveLending(ILending lending)
        {
            return _library.dataLayer.GetLendingsRepository().RemoveLending(lending);
        }
    }
}