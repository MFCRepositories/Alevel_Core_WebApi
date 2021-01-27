using Core.Utilities.ResultType;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductServis
    {
        EntityResult<List<Product>> GetList();
        EntityResult<List<Product>> GetListByCategory(int CategoryId);
        EntityResult<Product> GetById(int id);
        EntityResult Add(Product product);
        EntityResult Delete(Product product);  //Silme İşlemi Düzenlencek 
        EntityResult Update(Product product);

        EntityResult Sell(Product product);//TODO:BU Methos sepet satışı olarak daha sorna igili servisde güncellenecek

    }
}
