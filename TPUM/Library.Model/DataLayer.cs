using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Logic;
using Library.Logic.Filters;

namespace Library.Model
{
    public class DataLayer
    {
        public static DataLayer CreateDefault()
        {
            return new DataLayer(Logic.Library.CreateDefault());
        }

        private ILibrary library;
        public DataLayer(ILibrary library)
        {
            this.library = library;
        }

        public IEnumerable<Book> book => library.GetBooksManager().GetBooks(new PassFilter<BookInfo>()).ConvertAll(DataLayer.ToBook);

        public IEnumerable<Person> user
        {
            get
            {
                List<Person> people = new List<Person>()
                {
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    //new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"}
                };
                return people;
            }
        }

        public IEnumerable<Lending> lending
        {
            get
            {
                List<Lending> lendings = new List<Lending>()
                {
                    //new Lending() {userID = user.ToList()[0].id, bookID = book.ToList()[0].id},
                    //new Lending() {userID = user.ToList()[1].id, bookID = book.ToList()[1].id},
                    //new Lending() {userID = user.ToList()[2].id, bookID = book.ToList()[2].id},
                    //new Lending() {userID = user.ToList()[3].id, bookID = book.ToList()[3].id},
                    //new Lending() {userID = user.ToList()[4].id, bookID = book.ToList()[4].id}
                };
                return lendings;
            }
        }

        internal static Book ToBook(BookInfo bookInfo)
        {
            return new Book() { id = bookInfo.id, author = bookInfo.author, title = bookInfo.title, isbn = bookInfo.isbn};
        }
    }
}
