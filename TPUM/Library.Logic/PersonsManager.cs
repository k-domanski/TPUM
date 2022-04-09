using System.Collections.Generic;
using Library.Data.Interface;
using Library.Logic.Factories;
using Library.Logic.Interface;

namespace Library.Logic
{
    public class PersonsManager : IPersonsManager
    {
        private Library _library;
        public PersonsManager(Library library)
        {
            _library = library;
        }

        public bool CreatePerson(PersonInfo initData)
        {
            CreatePersonFactory factory = new CreatePersonFactory(initData);
            return _library.dataLayer.GetPersonsRepository().AddPerson(factory.Create());
        }

        public List<IPerson> GetPersons(IFilter<IPerson> filter)
        {
            return _library.dataLayer.GetPersonsRepository().FindPersonByPredicate(filter.Match);
        }

        public bool UpdatePerson(IPerson person, IPersonFactory personFactory)
        {
            IPersonsRepository repository = _library.dataLayer.GetPersonsRepository();
            bool removed = repository.RemovePerson(person);
            if (!removed)
            {
                return false;
            }

            return repository.AddPerson(personFactory.Create());
        }

        public bool RemovePerson(IPerson person)
        {
            return _library.dataLayer.GetPersonsRepository().RemovePerson(person);
        }
    }
}