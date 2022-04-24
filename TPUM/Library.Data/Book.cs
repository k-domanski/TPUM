using System;
using Library.Data.Interface;

namespace Library.Data
{
    public class Book : IBook
    {
        private Guid _id;
        private string _isbn;
        private string _author;
        private string _title;
        public bool isAvailable { get; set; } = true;

        public Book(Guid id, string isbn, string author, string title, bool available)
        {
            _id = id;
            _isbn = isbn;
            _author = author;
            _title = title;
            isAvailable = available;
        }

        public Guid GetBookID()
        {
            return _id;
        }

        public string GetISBN()
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

        public bool IsAvailable()
        {
            return isAvailable;
        }

        public bool Equals(IBook other)
        {
            if (other == null)
            {
                return false;
            }

            return GetBookID() == other.GetBookID();
        }
    }
}
