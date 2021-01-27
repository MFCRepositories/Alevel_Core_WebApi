using Core.DataAccsess.EntityFramework;
using Core.Entity.Concrete;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework.Context;
using System.Collections.Generic;
using System.Linq;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfUserDal
        : EfEntityRepository<User, AlevelDbContext>, IUserDal
    {
        public EfUserDal(AlevelDbContext context) : base(context) { }

        public List<OperationClaims> GetClaims(User user)
        {
            using (var con = Context)
            {
                var OperationClaims = from OperationClaim in con.OperationClaims
                                      join UserOperationClaim in con.UserOperationClaims
                                      on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                                      where UserOperationClaim.UserId == user.Id
                                      select new OperationClaims
                                      {
                                          Id = OperationClaim.Id,
                                          Name = OperationClaim.Name
                                      };
                return OperationClaims.ToList();
            }

        }
    }
}
