using Core.Entity.Concrete;
using Core.Utilities.ResultType;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        EntityResult<User> GetById (int id);
        EntityResult<List<User>> GetAll();
        EntityResult<List<OperationClaims>> GetClaims(User user);
        EntityResult<User> GetByEmail(string email);
        EntityResult Add(User user);
        EntityResult Delete(User user);//Silme İşlemi Düzenlencek
        EntityResult Update(User user);

    }
}
