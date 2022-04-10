using System.Collections.Generic;
using System.Diagnostics;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface IPersonsManager
    {
        bool CreatePerson(PersonInfo initData);
        List<PersonInfo> GetPersons(IFilter<PersonInfo> filter);
        bool UpdatePerson(PersonInfo original, PersonInfo updated);
        bool RemovePerson(PersonInfo person);
    }
}