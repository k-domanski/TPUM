using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Logic;
using Library.Logic.Filters;

namespace Library.Model
{
    public class ModelLayer
    {
        public static ModelLayer CreateDefault()
        {
            return new ModelLayer(Logic.Library.CreateDefault());
        }

        public ILibrary library { get; }
        public ModelLayer(ILibrary library)
        {
            this.library = library;
        }

        public IEnumerable<Book> book => library.GetBooksManager().GetBooks(new PassFilter<BookInfo>()).ConvertAll(ModelLayer.ToBook);

        public IEnumerable<Person> user => library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>()).ConvertAll(ModelLayer.ToPerson);

        public IEnumerable<Lending> lending => library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>()).ConvertAll(ModelLayer.ToLending);

        public void CreateBook(Book book)
        {
            library.GetBooksManager().CreateBook(ToBookInfo(book));
        }

        internal static Book ToBook(BookInfo bookInfo)
        {
            return new Book { id = bookInfo.id, author = bookInfo.author, title = bookInfo.title, isbn = bookInfo.isbn };
        }

        internal static BookInfo ToBookInfo(Book book)
        {
            return new BookInfo { author = book.author, title = book.title, id = book.id, isbn = book.isbn, isAvailable = true };
        }

        internal static Person ToPerson(PersonInfo personInfo)
        {
            return new Person { id = personInfo.id, firstName = personInfo.firstName, lastName = personInfo.surname };
        }

        internal static Lending ToLending(LendingInfo lendingInfo)
        {
            return new Lending { bookID = lendingInfo.bookID, userID = lendingInfo.personID };
        }
    }
}
