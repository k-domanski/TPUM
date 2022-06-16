using System;

namespace Library.Logic.Interface
{
    public interface IBookInfo
    {
        Guid id { get; set; }
        string isbn { get; set; }
        string author { get; set; }
        string title { get; set; }
        bool isAvailable { get; set; }
    }
}