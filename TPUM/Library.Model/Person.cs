using System;

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
