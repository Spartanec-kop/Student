using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetId(Int64 id);
        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        Task<int> recordCount(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(Int64 id);
        void Save();
    }
}
