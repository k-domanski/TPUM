using System.Collections.Generic;
using System.Diagnostics;
using Library.DataServer.Interface;

namespace Library.LogicServer.Interface
{
    public interface IPersonsManager
    {
        bool CreatePerson(PersonInfo initData);
        List<PersonInfo> GetPersons(IFilter<PersonInfo> filter);
        bool UpdatePerson(PersonInfo original, PersonInfo updated);
        bool RemovePerson(PersonInfo person);
    }
}