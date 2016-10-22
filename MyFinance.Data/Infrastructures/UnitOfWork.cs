using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Infrastructures
{
    public class UnitOfWork:IUnitOfWork
    {

        private MyContext context;
        IDataBaseFactory _dataBaseFactory;

        public UnitOfWork(IDataBaseFactory dataBaseFactory)
        {
            this._dataBaseFactory = dataBaseFactory;
            context = dataBaseFactory.DBcontext;
        }

        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            return new RepositoryBase<T>(context);
        }
        public void commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            //liberer l'espace memoire du context
            context.Dispose();
        }
    }
}
