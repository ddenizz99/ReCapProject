using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailDto> GetUserDetails();
        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetByIdUserDetails(int Id);
    }
}
