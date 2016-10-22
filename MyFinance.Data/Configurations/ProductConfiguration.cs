using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Domain.Entities;

namespace MyFinance.Data.Configurations
{
    public class ProductConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            //Relation Avec Category Many To OneOrZero
            HasOptional<Category>(p => p.maCategory)
                .WithMany(c => c.ListProduct)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            //Relation Avec Providers Many To Many
            HasMany(p => p.providers)
                .WithMany(p => p.products)
                .Map
                    (rslt =>
                        {
                            rslt.ToTable("MyProductsProviders")
                            .MapLeftKey("CleProd")
                            .MapRightKey("CleProv");
                        }
                    );

            //Heritage
            Map<Biological>(prop => prop.Requires("IsBiological").HasValue(1));
            Map<Chemical>(prop => prop.Requires("IsBiological").HasValue(0));


        }
    }
}
