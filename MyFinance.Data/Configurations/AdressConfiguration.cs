using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Domain.Entities;

namespace MyFinance.Data.Configurations
{
    public class AdressConfiguration:ComplexTypeConfiguration<Adress>
    {
        public AdressConfiguration()
        {
            Property(p => p.City).IsRequired();
            Property(p => p.StreetAdress).IsOptional().HasMaxLength(50);

        }
    }
}
