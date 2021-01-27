using Business.Concrete;
using Core.Utilities.ResultType;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Test.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(new AlevelDbContext()));
            //Product product = new Product()
            //{
            //    CategoryID = 1,
            //    ProductName = "Elmacı",
            //    QuantityPerUnit = "Deneme",
            //    UnitPrice = 100M,
            //    UnitsInStock = 10,
            //    SupplierID = 80
            //};
            //EntityResult<List<Product>> result = productManager.GetListByCategory(1);
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
        }
    }
}
