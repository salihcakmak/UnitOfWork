using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication37.DAL.Repository
{
   public  interface IGenericRepository<T>where T:class
    {
        IQueryable<T> GetAll();
        T Find(Guid Id);
        T Add(T entity);
        T Update(T entityToUpdate);
        void Delete(Guid Id);
        void Delete(T entityToDelete);
        
    }
}
