using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Business.Abstracts
{
    public interface IManager<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        void Update(T entitiy, int id);
    }
}
