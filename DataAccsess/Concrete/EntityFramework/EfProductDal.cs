using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepository<Product, AlevelDbContext>, IProductDal
    {
        public EfProductDal(AlevelDbContext context) : base(context)
        {
        }
    }
}
