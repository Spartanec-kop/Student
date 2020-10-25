using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
