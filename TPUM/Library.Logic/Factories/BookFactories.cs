using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Interface;

namespace Library.Logic.Factories
{
    internal class CreateBookFactory : IBookFactory
    {
        private BookInitData bookData;
        internal CreateBookFactory(BookInitData initData)
        {
            bookData = initData;
        }

        public IBook Create()
        {
            return new Book(Guid.NewGuid(), bookData.author, bookData.title);
        }
    }
}
