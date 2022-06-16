using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO
{
    public class BookDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public bool isAvailable { get; set; }
    }

    public class PersonDTO
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
    }

    public class LendingDTO
    {
        public Guid personID { get; set; }
        public Guid bookID { get; set; }
    }
}
