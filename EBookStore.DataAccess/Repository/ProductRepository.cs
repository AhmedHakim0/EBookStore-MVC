using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EBookStore.DataAccess.Repository.IRepository;
using EBookStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EBookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
        }
    }
}
