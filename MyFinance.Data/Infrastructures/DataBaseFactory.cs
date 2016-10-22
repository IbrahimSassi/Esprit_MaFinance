using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Infrastructures
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
        private MyContext context;

        public MyContext DBcontext { get { return context; } }

        public DataBaseFactory()
        {
            this.context = new MyContext();
        }

        protected override void DisposeCore()
        {
            if (DBcontext != null)
                DBcontext.Dispose();
        }

    }
}
