using System;
using System.Collections.Generic;
using System.Linq;
using Library.LogicServer.Interface;

namespace Library.LogicServer.Filters
{
    public abstract class CompositeFilter<T> : IFilter<T>
    {
        public List<IFilter<T>> filters { get; private set; }

        protected CompositeFilter()
        {
            filters = new List<IFilter<T>>();
        }

        protected CompositeFilter(List<IFilter<T>> filters)
        {
            this.filters = filters;
        }

        public void Add(IFilter<T> filter)
        {
            filters.Add(filter);
        }

        public abstract bool Match(T item);
    }

    public class FilterAll<T> : CompositeFilter<T>
    {
        public FilterAll() : base() { }
        public FilterAll(List<IFilter<T>> filters) : base(filters) { }
        public override bool Match(T item)
        {
            return filters.All(filter => filter.Match(item));
        }
    }

    public class FilterAny<T> : CompositeFilter<T>
    {
        public FilterAny() : base() { }
        public FilterAny(List<IFilter<T>> filters) : base(filters) { }
        public override bool Match(T item)
        {
            return filters.Any(filter => filter.Match(item));
        }
    }

    public class PassFilter<T> : IFilter<T>
    {
        public bool Match(T item)
        {
            return true;
        }
    }

    public class ExactMatchFilter<T> : IFilter<T>
    {
        private T target;
        public ExactMatchFilter(T target)
        {
            this.target = target;
        }

        public bool Match(T item)
        {
            return target.Equals(item);
        }
    }

    public abstract class StringLinguisticFilter<T> : IFilter<T>
    {
        protected string pattern { get; set; }

        protected StringLinguisticFilter(string pattern)
        {
            this.pattern = pattern;
        }

        public bool Match(T item)
        {
            return String.Compare(pattern, GetString(item), StringComparison.InvariantCultureIgnoreCase) <= 0;
        }


        public abstract string GetString(T item);
    }
}
