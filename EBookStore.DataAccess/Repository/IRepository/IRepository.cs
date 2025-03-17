using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.DataAccess.Repository.IRepository
{
     public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity,bool>> Filter);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRang(IEnumerable<TEntity> entities);
    }
}
