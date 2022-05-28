using System;

namespace Library.DataServer.Interface
{
    public interface ILending : IEquatable<ILending>
    {
        Guid GetPersonID();
        Guid GetBookID();
    }
}