using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Interface;

namespace Library.Logic.Factories
{
    public class CreateLendingFactory : ILendingFactory
    {
        private LendingInfo lending;

        public CreateLendingFactory(LendingInfo initData)
        {
            lending = initData;
        }

        public ILending Create()
        {
            return new Lending(lending.personID, lending.bookID);
        }
    }
}
