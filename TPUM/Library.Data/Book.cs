using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interface;

namespace Library.Data
{
    public class Book : IBook
    {
        private Guid _isbn;
        private string _author;
        private string _title;

        public Book(Guid isbn, string author, string title)
        {
            _isbn = isbn;
            _author = author;
            _title = title;
        }

        public Guid GetISBN()
        {
            return _isbn;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}
