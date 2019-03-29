using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication37.DAL.Repository;

namespace WebApplication37.DAL.UnitOfWork
{
   
        public class UnitofWork : IUnitofWork
        {
           
            private readonly BlogContext _context;
            private DbContextTransaction _transation;
            private bool _disposed;
           
            public UnitofWork(BlogContext context)
            {
                _context = context;
            }
           
            public IGenericRepository<T> GetRepository<T>() where T : class
            {
                return new GenericRepository<T>(_context);
            }

         
            public bool BeginNewTransaction()
            {
                try
                {
                    _transation = _context.Database.BeginTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

          
            public bool RollBackTransaction()
            {
                try
                {
                    _transation.Rollback();
                    _transation = null;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        
            public int SaveChanges()
            {
                var transaction = _transation != null ? _transation : _context.Database.BeginTransaction();
                using (transaction)
                {
                    try
                    {
                        
                        if (_context == null)
                        {
                            throw new ArgumentException("Context is null");
                        }
                      
                        int result = _context.SaveChanges();

                       
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                      
                        transaction.Rollback();
                        throw new Exception("Error on save changes ", ex);
                    }
                }
            }
          
            protected virtual void Dispose(bool disposing)
            {
                if (!this._disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                this._disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            
        }
    }
