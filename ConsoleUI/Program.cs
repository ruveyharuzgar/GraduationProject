using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MagnetTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void MagnetTest()
        {
            MagnetManager magnetManager = new MagnetManager(new EfMagnetDal());

            foreach (var magnet in magnetManager.GetMagnetDetails())
            {
                Console.WriteLine(magnet.Text+" "+magnet.Price+" "+magnet.CategoryName+" "+magnet.ColorName+" ");
            }
        }
    }
}
