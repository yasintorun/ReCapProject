using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        /*[ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }*/

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            User user = _userDal.Get(u => u.Id == id);
            if(user != null)
            {
                user.PasswordHash = null;
                user.PasswordSalt = null;
            }
            return new SuccessDataResult<User>(user, Messages.UserGot);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            User current = _userDal.Get(u => u.Id == user.Id);
            if(current == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            user.PasswordHash = current.PasswordHash;
            user.PasswordSalt = current.PasswordSalt;

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        IResult ICrudService<User>.Add(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
