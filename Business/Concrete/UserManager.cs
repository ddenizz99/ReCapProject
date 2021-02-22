using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {       
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.AddedError);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.DeletedError);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                var result = _userDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<User>>(result);
                }
                return new ErrorDataResult<List<User>>(Messages.EmptyData);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<User>>(Messages.GetAllError);
            }
        }

        public IDataResult<List<UserDetailDto>> GetAllDetails()
        {          
            try
            {
                var result = _userDal.GetUserDetails();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<UserDetailDto>>(result);
                }
                return new ErrorDataResult<List<UserDetailDto>>(Messages.EmptyData);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserDetailDto>>(Messages.GetAllError);
            }
        }

        public IDataResult<User> GetById(int Id)
        {
            try
            {
                var result = _userDal.Get(u => u.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<User>(result);
                }
                return new ErrorDataResult<User>(Messages.GetByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<User>(Messages.GetAllError);
            }
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UpdatedError);
            }
        }
    }
}
