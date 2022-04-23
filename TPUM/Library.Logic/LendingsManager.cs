using System;
using System.Collections.Generic;
using Library.Data.Interface;
using Library.Logic.Factories;
using Library.Logic.Filters;
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

            List<BookInfo> books = _library.GetBooksManager().GetBooks(new BookIDFilter(initData.bookID));
            if (books.Count == 1 && !books[0].isAvailable)
            {
                return false;
            }

            CreateLendingFactory factory = new CreateLendingFactory(initData);
            BookInfo updatedInfo = books[0];
            updatedInfo.isAvailable = false;
            _library.GetBooksManager().UpdateBook(books[0], updatedInfo);
            return _library.dataLayer.GetLendingsRepository().AddLending(factory.Create());
        }

        public List<LendingInfo> GetLendings(IFilter<LendingInfo> filter)
        {
            return _library.dataLayer.GetLendingsRepository().GetLendings().ConvertAll(Library.ToLendingInfo)
                .FindAll(filter.Match);
        }

        public bool UpdateLending(LendingInfo original, LendingInfo updated)
        {
            ILendingsRepository repository = _library.dataLayer.GetLendingsRepository();
            Predicate<ILending> predicate = (item) =>
            {
                return item.GetBookID() == updated.bookID && item.GetPersonID() == updated.personID;
            };
            if (updated.bookID != original.bookID && updated.personID != original.personID)
            {
                bool exists = repository.FindLendingsByPredicate(predicate).Count > 0;
                if (exists)
                {
                    return false;
                }
            }

            List<ILending> oldLending = repository.FindLendingsByPredicate(predicate);
            if (oldLending.Count != 1)
            {
                return false;
            }

            /* ++++ Atomic Operation ++++ */
            bool removed = repository.RemoveLending(oldLending[0]);
            if (!removed)
            {
                return false;
            }
            bool added = repository.AddLending(Library.ToLending(updated));
            /* ---- Atomic Operation ---- */
            return added;
        }

        public bool RemoveLending(LendingInfo lending)
        {
            List<ILending> target = _library.dataLayer.GetLendingsRepository().FindLendingsByPredicate(item =>
                item.GetBookID() == lending.bookID && item.GetPersonID() == lending.personID);
            if (target.Count != 1)
            {
                return false;
            }

            List<BookInfo> books = _library.GetBooksManager().GetBooks(new BookIDFilter(lending.bookID));
            if (books.Count != 1)
            {
                return false;
            }

            BookInfo updatedInfo = books[0];
            updatedInfo.isAvailable = true;
            if (!_library.GetBooksManager().UpdateBook(books[0], updatedInfo))
            {
                return false;
            }

            return _library.dataLayer.GetLendingsRepository().RemoveLending(target[0]);
        }
    }
}