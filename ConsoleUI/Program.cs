using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MagnetManager magnetManager = new MagnetManager(new InMemoryMagnetDal());

            foreach (var magnet in magnetManager.GetAll())
            {
                Console.WriteLine(magnet.Text);
            }
        }

    }
}
