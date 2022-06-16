using System;
using Library.Logic.Interface;

namespace Library.Logic
{
    public struct PersonInfo : IPersonInfo
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
    }
}