using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Domain.Entities;
using Service.Pattern;

namespace MyFinance.Service
{
    public interface ICategoryService: IServiceGeneric<Category>
    {
        
    }
}
