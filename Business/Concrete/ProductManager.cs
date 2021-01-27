using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transcation;
using Core.Aspects.Autofac.Validation;
using Core.CrosCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Extensions;
using Core.Utilities.ResultType;
using DataAccsess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductServis
    {
        private readonly IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        
        //[ValidationAspect(typeof(ProductValidation),Priority =1)]
        //[CacheRemoveAspect("IProductService.Get")]
        //[CacheRemoveAspect("ICategoryService.Get")]
        public EntityResult Add(Product product)
        {
           // GlobalValidation.Val(new ProductValidation(), product);
            try
            {
                var resultDataBase = productDal.Add(product);
                if (resultDataBase > 0)
                    return new EntityResult();
                else
                    return new EntityResult(ResultType.Info, "Ekleme İşlemi Yapılamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Hata Aldınız" + " " + ex.ToInnest());
            }
        }
        public EntityResult Delete(Product product)
        {
            EntityResult result = null;
            try
            {
                var resultDataBase = productDal.Delete(product);
                if (resultDataBase > 0)
                    return result = new EntityResult();
                else
                    return result = new EntityResult(ResultType.Info, "Silme İşlemi Yapılamadı");
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, "Hata Aldınız" + " " + ex.Message);
            }
        }
        public EntityResult Update(Product product)
        {
            EntityResult result = null;
            try
            {
                var resultDataBase = productDal.Update(product);
                if (resultDataBase > 0)
                    return result = new EntityResult();
                else
                    return result = new EntityResult(ResultType.Info, "Güncelleme İşlemi Yapılamadı");
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, "Hata Aldınız" + " " + ex.Message);
            }
        }
        public EntityResult<Product> GetById(int id)
        {
            EntityResult<Product> result = null;
            try
            {
                Task<Product> product = productDal.GetAsync(x => x.Id == id);
                if (product.Result != null)
                {
                    return result = new EntityResult<Product>(product.Result);
                }
                else
                    return result = new EntityResult<Product>(null, ResultType.Warning, "Kayıt Bulunmadı");
            }
            catch (Exception)
            {

                return result = new EntityResult<Product>(null, ResultType.Error, "Hata Aldınız");
            }
        }

        //[SecuredOperation("Product.List,Admin")]
        //[PerformanceAspect(1)]
        //[LogAspect(typeof(FileLogger))]
        public EntityResult<List<Product>> GetList()
        {
            EntityResult<List<Product>> result = null;
            try
            {
                Task<List<Product>> product = productDal.GetAllAsync();
                if (product.Result != null)
                {
                    return result = new EntityResult<List<Product>>(product.Result);
                }
                else
                    return result = new EntityResult<List<Product>>(null, ResultType.Warning, "Kayıt Bulunmadı");
            }
            catch (Exception)
            {

                return result = new EntityResult<List<Product>>(null, ResultType.Error, "Hata Aldınız");
            }
        }

        //[SecuredOperation("Product.List,Admin")]
        //[CachAspect(duration: 30)]
        //[LogAspect(typeof(DatabaseLogger))]
        //TODO: Database logger çalışmadı!!!!!
        //[LogAspect(typeof(FileLogger))]
        public EntityResult<List<Product>> GetListByCategory(int CategoryId)
        {
            EntityResult<List<Product>> result = null;
            try
            {
                Task<List<Product>> product = productDal.GetAllAsync(x => x.CategoryID == CategoryId);
                if (product.Result != null)
                {
                    return result = new EntityResult<List<Product>>(product.Result);
                }
                else
                    return result = new EntityResult<List<Product>>(null, ResultType.Warning, "Kayıt Bulunmadı");
            }
            catch (Exception)
            {

                return result = new EntityResult<List<Product>>(null, ResultType.Error, "Hata Aldınız");
            }
        }

        [TranscationScopeAspect]
        public EntityResult Sell(Product product)
        {
            productDal.Update(product);
            return null;
            //TODO:BAK

        }
    }
}
