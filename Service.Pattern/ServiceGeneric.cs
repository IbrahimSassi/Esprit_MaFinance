using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructures;

namespace Service.Pattern
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
    {
        private IUnitOfWork iutw;

        protected ServiceGeneric(IUnitOfWork iutw)
        {
            this.iutw = iutw;
        }
        public virtual void Add(T t)
        {
            iutw.getRepository<T>().Add(t);
        }

        public virtual void Delete(T t)
        {
            iutw.getRepository<T>().Delete(t);
        }

        public virtual void DeletebyCondition(Expression<Func<T, bool>> condition)
        {
            iutw.getRepository<T>().DeletebyCondition(condition);
        }

        public virtual void Dispose()
        {
            iutw.Dispose();
        }

        public virtual T GetById(string id)
        {
            return iutw.getRepository<T>().GetById(id);
        }

        public virtual T GetById(int id)
        {
            return iutw.getRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return iutw.getRepository<T>().GetMany(condition, orderBy);
        }

        public virtual void Update(T t)
        {
            iutw.getRepository<T>().Update(t);
        }

        public virtual void commit()
        {
            iutw.commit();
        }

    }
}
