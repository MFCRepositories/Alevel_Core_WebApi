using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Constans;
using Core.Utilities.ResultType;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager
        : IUserService
    {
        private readonly IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public EntityResult Add(User user)
        {
            EntityResult result = null;
            try
            {
                int resultDatabase = userDal.Add(user);
                if (resultDatabase > 0)
                    return result = new EntityResult(message: Message.AddSuccess);
                else
                    return result = new EntityResult(ResultType.Info, Message.AddInfo);
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, Message.AddError + " " + ex.Message);
            }
        }
        public EntityResult Delete(User user)
        {
            EntityResult result = null;
            try
            {
                int resultDatabase = userDal.Delete(user);
                if (resultDatabase > 0)
                    return result = new EntityResult(message: Message.DeleteSuccess);
                else
                    return result = new EntityResult(ResultType.Info, Message.DeleteInfo);
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, Message.DeleteError + " " + ex.Message);
            }
        }
        public EntityResult<List<User>> GetAll()
        {
            EntityResult<List<User>> result = null;
            try
            {
                Task<List<User>> users = userDal.GetAllAsync();
                if (users != null)
                    return result = new EntityResult<List<User>>(data: users.Result, message: Message.GetSuccess);
                else
                    return result = new EntityResult<List<User>>(null, ResultType.Notfound, message: Message.GetNotFound);
            }
            catch (Exception ex)
            {
                return result = new EntityResult<List<User>>(null, ResultType.Error, message: Message.AddError + " " + ex.Message);
            }
        }
        public EntityResult<User> GetByEmail(string email)
        {
            try
            {
                Task<User> user = userDal.GetAsync(x => x.Email == email);
                if (user.Result != null)
                {
                    return new EntityResult<User>(user.Result);
                }
                return new EntityResult<User>(null, ResultType.Notfound, Message.GetNotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<User>(null,ResultType.Error,Message.GetError+" "+ex.Message);
            }

        }
        public EntityResult<User> GetById(int id)
        {
            try
            {
                Task<User> user = userDal.GetAsync(x => x.Id == id);
                if (user.Result != null)
                {
                    return new EntityResult<User>(user.Result);
                }
                return new EntityResult<User>(null, ResultType.Notfound, Message.GetNotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<User>(null, ResultType.Error, Message.GetError + " " + ex.Message);
            }
        }
        public EntityResult<List<OperationClaims>> GetClaims(User user)
        {
            try
            {
                List<OperationClaims> claims = userDal.GetClaims(user);
                if (claims != null)
                {
                    return new EntityResult<List<OperationClaims>>(claims);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public EntityResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
