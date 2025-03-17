using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.DataAccess.Repository.IRepository
{
   public interface IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; }
        void Save();
    }
}
