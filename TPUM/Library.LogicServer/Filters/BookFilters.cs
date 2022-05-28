using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DataServer.Interface;
using Library.LogicServer.Interface;

namespace Library.LogicServer.Filters
{
    public class BookIDFilter : IFilter<BookInfo>
    {
        public Guid id { get; }

        public BookIDFilter(Guid id)
        {
            this.id = id;
        }

        public bool Match(BookInfo item)
        {
            return item.id == id;
        }
    }

    public class BookISBNFilter : IFilter<BookInfo>
    {
        private string isbn { get; }

        public BookISBNFilter(string isbn)
        {
            this.isbn = isbn;
        }

        public bool Match(BookInfo item)
        {
            return String.Equals(isbn, item.isbn);
        }
    }

    public class BookAuthorFilter : StringLinguisticFilter<BookInfo>
    {
        public BookAuthorFilter(string pattern) : base(pattern)
        {
        }

        public override string GetString(BookInfo item)
        {
            return item.author;
        }
    }

    public class BookTitleFilter : StringLinguisticFilter<BookInfo>
    {
        public BookTitleFilter(string pattern) : base(pattern)
        {
        }

        public override string GetString(BookInfo item)
        {
            return item.title;
        }
    }

    public class BookAvailabilityFilter : IFilter<BookInfo>
    {
        public bool available { get; }

        public BookAvailabilityFilter(bool available)
        {
            this.available = available;
        }

        public bool Match(BookInfo item)
        {
            return item.isAvailable == available;
        }
    }
}
