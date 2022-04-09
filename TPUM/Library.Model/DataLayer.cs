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
    }
}
