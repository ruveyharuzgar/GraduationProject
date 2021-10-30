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
            MagnetManager magnetManager = new MagnetManager(new EfMagnetDal());

            foreach (var magnet in magnetManager.GetByPrice(10,20))
            {
                Console.WriteLine(magnet.Text);
            }
        }

    }
}
