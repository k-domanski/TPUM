using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class DataLayer
    {
        public IEnumerable<Book> book
        {
            get
            {
                List<Book> books = new List<Book>()
                {
                    new Book() {isbn = Guid.NewGuid(), author = "Adam Mickiewicz", title = "Pan Tadeusz", count = 5 },
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 3},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 4},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 1},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 5},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 3},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 6},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 1},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 2},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 2},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 3},
                    new Book() {isbn = Guid.NewGuid(), author = "Stefan Żeromski", title = "Ludzie bezdomni", count = 5}
                };
                return books;
            }
        }

        public IEnumerable<Person> user
        {
            get
            {
                List<Person> people = new List<Person>()
                {
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"},
                    new Person() {id = Guid.NewGuid(), firstName = "Stefan", lastName = "Kowalski"}
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
                    new Lending() {userID = user.ToList()[0].id, bookISBN = book.ToList()[0].isbn},
                    new Lending() {userID = user.ToList()[1].id, bookISBN = book.ToList()[1].isbn},
                    new Lending() {userID = user.ToList()[2].id, bookISBN = book.ToList()[2].isbn},
                    new Lending() {userID = user.ToList()[3].id, bookISBN = book.ToList()[3].isbn},
                    new Lending() {userID = user.ToList()[4].id, bookISBN = book.ToList()[4].isbn}
                };
                return lendings;
            }
        }
    }
}
