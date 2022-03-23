using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{ProductId = 1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId = 2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=30},
                new Product{ProductId = 3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=150},
                new Product{ProductId = 4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=8},
                new Product{ProductId = 5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); // Çalışmaz asla new'lendiği için adresler farklıdır. ProductId leri eşitleyip bulurız
            /*
            // LINQ (Language Integrated Query) kullanmadan
            Product productToDelete = null;
            foreach (var item in _products)
            {
                if (product.ProductId == item.ProductId)
                {
                    productToDelete = item;
                }
            }
            _products.Remove(productToDelete);
            */
            // With LINQ   çok kısa fonks ile yazılır
            Product productToDelete = _products.SingleOrDefault(item => item.ProductId == product.ProductId); // First gibi alternatiflrei de var yukarrıda foreach de yaptığımmızı yapar. Ürunleri tek tek dolanır
            _products.Remove(productToDelete); 
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(item => item.CategoryId == categoryId).ToList();
        }   // ÖR. CategoryId 5 olanları getir.

        public void Update(Product product)
        {
            // gönderilen ürüne ait ıd i bul ki güncelleyebilesin...
            Product productToUpdate = _products.SingleOrDefault(item => item.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        // Add Delete Update fonksiyonlarındaki yapılan işlemler işin mantığıdır. EntityFramewrokk da bu işlemleri bizim yerimize yapacak.
    }
}
