using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Infra.Repos
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
