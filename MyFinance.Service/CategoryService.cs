using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructures;
using MyFinance.Domain.Entities;

namespace MyFinance.Service
{
    public class CategoryService: ServiceGeneric<Category> ,ICategoryService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork iutw = new UnitOfWork(dbfac);

        public CategoryService() : base(iutw)
        {

        }



    }
}
