using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Domain.Entities;
using MyFinance.Data.Configurations;

namespace MyFinance.Data
{
    public class MyContext:DbContext
    {

        public MyContext() :base("Name=DBMyFinanceRevisionV2")
        {
          //  Database.SetInitializer<MyContext>(new InitializerContext());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new AdressConfiguration());
        
        

    }
}

    public class InitializerContext : System.Data.Entity.DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var listeCategory = new List<Category>
            {
                new Category { name= "Vetements" },
                new Category { name= "Chaussures" }
            };

            context.Categories.AddRange(listeCategory);
            Console.WriteLine("helo");
            context.SaveChanges();
        }
    }

}
