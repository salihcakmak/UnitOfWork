using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication37.DAL.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private BlogContext _context;
        private DbSet<T> _dbset;
        public GenericRepository(BlogContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbset;
        }
        public T Find (Guid Id)
        {
            return _dbset.Find(Id);
        }
        public T Update(T entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }
        public T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }

        public void Delete(Guid Id)
        {
            Delete(Find(Id));
        }

        public void Delete(T entityToDelete)
        {
           
            _dbset.Remove(entityToDelete);
        }

       
    }
}