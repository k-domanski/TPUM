using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataServer;
using Library.DataServer.Interface;

namespace Library.LogicServer.Factories
{
    public class CreateBookFactory : IBookFactory
    {
        private BookInfo bookData;
        public CreateBookFactory(BookInfo initData)
        {
            bookData = initData;
        }

        public IBook Create()
        {
            return new Book(Guid.NewGuid(), bookData.isbn, bookData.author, bookData.title, true);
        }
    }
}
