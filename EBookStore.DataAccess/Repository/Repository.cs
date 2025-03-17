using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EBookStore.DataAccess.Repository;
using EBookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
namespace EBookStore.DataAccess.Repository
{
     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext db;
        private DbSet<TEntity> Dbset;
        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.Dbset = db.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> Filter)
        {
            IQueryable<TEntity> query = Dbset.Where(Filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Dbset.ToList();
        }

        public void Remove(TEntity entity)
        {
           Dbset.Remove(entity);
        }

        public void RemoveRang(IEnumerable<TEntity> entities)
        {
           Dbset.RemoveRange(entities);
        }
    }
}
