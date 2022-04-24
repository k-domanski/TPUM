using System;

namespace Library.Model
{
    public class Book : IEquatable<Book>
    {
        public Guid id { get; set; }

        public string isbn { get; set; }

        public string author { get; set; }

        public string title { get; set; }

        public bool isAvailable { get; set; }

        public string availability { get; set; } = "Dostępna";

        public bool Equals(Book other)
        {
            return id == other.id;
        }
    }
}
