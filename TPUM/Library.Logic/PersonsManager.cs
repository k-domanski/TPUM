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

        public List<PersonInfo> GetPersons(IFilter<PersonInfo> filter)
        {
            return _library.dataLayer.GetPersonsRepository().GetPersons().ConvertAll(Library.ToPersonInfo)
                .FindAll(filter.Match);
        }

        public bool UpdatePerson(PersonInfo original, PersonInfo updated)
        {
            IPersonsRepository repository = _library.dataLayer.GetPersonsRepository();
            if (updated.id != original.id)
            {
                bool exists = repository.FindPersonsByPredicate(item => item.GetID() == updated.id).Count > 0;
                if (exists)
                {
                    return false;
                }
            }

            List<IPerson> oldPerson = repository.FindPersonsByPredicate(item => item.GetID() == original.id);
            if (oldPerson.Count != 1)
            {
                return false;
            }

            /* ++++ Atomic Operation ++++ */
            bool removed = repository.RemovePerson(oldPerson[0]);
            if (!removed)
            {
                return false;
            }
            bool added = repository.AddPerson(Library.ToPerson(updated));
            /* ---- Atomic Operation ---- */
            return added;
        }

        public bool RemovePerson(PersonInfo person)
        {
            List<IPerson> target = _library.dataLayer.GetPersonsRepository().FindPersonsByPredicate(item => item.GetID() == person.id);
            if (target.Count != 1)
            {
                return false;
            }
            return _library.dataLayer.GetPersonsRepository().RemovePerson(target[0]);
        }
    }
}