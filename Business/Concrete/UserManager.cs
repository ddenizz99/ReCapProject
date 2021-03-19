using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
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

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
