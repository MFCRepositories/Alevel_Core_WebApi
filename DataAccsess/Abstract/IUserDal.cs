using Core.DataAccsess;
using Core.Entity.Concrete;
using System.Collections.Generic;

namespace DataAccsess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaims> GetClaims(User user);
    }
}
