using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        // SOLID
        // Open Closed Principle  -- Yeni bir özellik eklendiğinde mevcuttaki hiçbir koda dokunamama...
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(item.ProductName + " " + item.UnitPrice);
            }
        }
    }
}
