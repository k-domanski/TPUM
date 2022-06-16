using System;

namespace Library.LogicServer.Interface
{
    public interface IPersonInfo
    {
        Guid id { get; set; }
        string firstName { get; set; }
        string surname { get; set; }
    }
}