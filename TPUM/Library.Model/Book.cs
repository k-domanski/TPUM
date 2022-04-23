using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public Guid id { get; set; }
        public string isbn { get; set; }

        public string author { get; set; }

        public string title { get; set; }

        // Count should be calculated based on the content in data layer - ILibrary.GetBooksManager().GetBooks(new GetBooksWithISBNFilter()).Count;
        public int count { get; set; }
    }
}
