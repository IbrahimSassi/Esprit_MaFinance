using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data;
using MyFinance.Domain.Entities;
using MyFinance.Service;

namespace MyFinance.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Begin");

            ICategoryService categoryService = new CategoryService();

             //MyContext context = new MyContext();
            


             Category category = new Category() { name = "Ibraaa" };
            categoryService.Add(category);
            categoryService.commit();
            //context.Categories.Add(category);
            //context.SaveChanges();

            System.Console.WriteLine("End");

            System.Console.ReadKey();
        }
    }
}
