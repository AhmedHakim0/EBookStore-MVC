using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EBookStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public ICategoryRepository categoryRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            categoryRepository = new CategoryRepository(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
