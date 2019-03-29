using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication37.DAL.Repository;

namespace WebApplication37.DAL.UnitOfWork
{
   public interface IUnitofWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        bool BeginNewTransaction();
        bool RollBackTransaction();
        int SaveChanges();

    }
}
