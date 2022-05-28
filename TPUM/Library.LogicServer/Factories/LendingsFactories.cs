using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataServer;
using Library.DataServer.Interface;

namespace Library.LogicServer.Factories
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
