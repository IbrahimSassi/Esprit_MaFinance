using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String name { get; set; }
        public virtual ICollection<Product> ListProduct { get; set; }
    }
}
