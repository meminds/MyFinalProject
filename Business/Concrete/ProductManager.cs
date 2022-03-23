using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();  // InMemory veritabanımız. EntityFramework'e döndürdüğümüzde bu kodları manuel olarak değişmek zorunda kalırız.
            // Bu yüzden yukarıda yazdığımız cons.'ı kullanırız.
            return _productDal.GetAll();
        }
    }
}
