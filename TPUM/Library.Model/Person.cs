using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Person : IEquatable<Person>
    {
        public Guid id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        public bool Equals(Person other)
        {
            return id == other.id;
        }
    }
}
