using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.ResultType;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServis productServis;
        public ProductsController(IProductServis productServis)
        {
            this.productServis = productServis;
        }
        [HttpPost("add")]
        public ActionResult Add(Product product)
        {
            EntityResult result = productServis.Add(product);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    break;
                case ResultType.Info:
                    break;
                case ResultType.Error:
                    break;
                case ResultType.Notfound:
                    break;
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    break;
            }
            return new AcceptedResult();
        }
     
        [HttpGet("getall")]     
        public ActionResult<List<Product>> GetAll()
        {
            EntityResult<List<Product>> result = productServis.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return result.Data;
                case ResultType.Info:
                    break;
                case ResultType.Error:
                    return BadRequest();
                case ResultType.Notfound:
                    break;
                case ResultType.Warning:
                    break;
                default:
                    break;
            }
            return result.Data;
        }
       
        [HttpGet("getbycategory/{id}")]
        public ActionResult<List<Product>> GetListByCategory(int id)
        {
            EntityResult<List<Product>> result = productServis.GetListByCategory(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return result.Data;
                case ResultType.Info:
                    return BadRequest("Bilgi");
                case ResultType.Error:
                    return BadRequest("Hata");
                case ResultType.Notfound:
                    return BadRequest("Bulunmadı");
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    break;
            }
            return result.Data;
        }
    }
}