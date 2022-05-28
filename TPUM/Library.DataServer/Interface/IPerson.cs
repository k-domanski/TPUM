using System;

namespace Library.DataServer.Interface
{
    public interface IPerson : IEquatable<IPerson>
    {
        Guid GetID();
        string GetFirstName();
        string GetSurname();
    }
}
