using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public Guid isbn { get; set; }

        public string author { get; set; }

        public string title { get; set; }

        public int count { get; set; }
    }
}
