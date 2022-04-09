using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Logic.Interface;

namespace Library.Logic.Filters
{
    public class BookISBNFilter : IFilter<IBook>
    {
        public Guid isbn { get; }

        public BookISBNFilter(Guid isbn)
        {
            this.isbn = isbn;
        }

        public bool Match(IBook item)
        {
            return item.GetISBN() == isbn;
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

}
