﻿using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface IBooksRepository
    {
        event Action<IBook> onBookAdded;
        List<IBook> GetBooks();
        bool AddBook(IBook book);
        bool RemoveBook(IBook book);
        List<IBook> FindBooksByPredicate(Predicate<IBook> predicate);
    }
}
