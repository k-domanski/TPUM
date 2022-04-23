using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Lending : IEquatable<Lending>
    {
        public Guid userID { get; set; }
        public Guid bookID { get; set; }

        public string userName { get; set; }
        public string userSurname { get; set; }
        public string bookTitle { get; set; }
        public string bookAuthor { get; set; }
        public bool Equals(Lending other)
        {
            return userID == other.userID && bookID == other.bookID;
        }
    }
}
