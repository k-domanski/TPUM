using System;

namespace Library.Data.Interface
{
    public interface IPersonFactory
    {
        IPerson CreatePerson(Guid id, string firstName, string surname);
    }
}