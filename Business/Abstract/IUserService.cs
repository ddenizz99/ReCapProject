using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int Id);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDetailDto>> GetAllDetails();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
