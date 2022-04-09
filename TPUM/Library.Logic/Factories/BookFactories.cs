using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Interface;

namespace Library.Logic.Factories
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
            return new Book(Guid.NewGuid(), bookData.author, bookData.title);
        }
    }
}
