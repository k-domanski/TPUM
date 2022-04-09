using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Logic.Interface;

namespace Library.Logic.Filters
{
    public class BookIDFilter : IFilter<IBook>
    {
        public Guid id { get; }

        public BookIDFilter(Guid id)
        {
            this.id = id;
        }

        public bool Match(IBook item)
        {
            return item.GetBookID() == id;
        }
    }

    public class BookISBNFilter : IFilter<IBook>
    {
        private string isbn { get; }

        public BookISBNFilter(string isbn)
        {
            this.isbn = isbn;
        }

        public bool Match(IBook item)
        {
            return String.Equals(isbn, item.GetISBN());
        }
    }

    public class BookAuthorFilter : StringLinguisticFilter<IBook>
    {
        public BookAuthorFilter(string pattern) : base(pattern)
        {
        }

        public override string GetString(IBook item)
        {
            return item.GetAuthor();
        }
    }

    public class BookTitleFilter : StringLinguisticFilter<IBook>
    {
        public BookTitleFilter(string pattern) : base(pattern)
        {
        }

        public override string GetString(IBook item)
        {
            return item.GetTitle();
        }
    }

    public class BookAvailabilityFilter : IFilter<IBook>
    {
        public bool available { get; }

        BookAvailabilityFilter(bool available)
        {
            this.available = available;
        }

        public bool Match(IBook item)
        {
            return item.IsAvailable() == available;
        }
    }
}
