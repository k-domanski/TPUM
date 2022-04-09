using System.Collections.Generic;
using System.Diagnostics;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface IPersonsManager
    {
        bool CreatePerson(PersonInitData initData);
        List<IPerson> GetPersons(IFilter<IPerson> filter);
        bool UpdatePerson(IPerson person, IPersonFactory personFactory);
        bool RemovePerson(IPerson person);
    }
}