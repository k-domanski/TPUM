using System;
using Library.LogicServer.Interface;

namespace Library.LogicServer.Filters
{
    public class PersonIDFilter : IFilter<PersonInfo>
    {
        private Guid _id;
        public PersonIDFilter(Guid id)
        {
            _id = id;
        }
        public bool Match(PersonInfo item)
        {
            return item.id == _id;
        }
    }

}