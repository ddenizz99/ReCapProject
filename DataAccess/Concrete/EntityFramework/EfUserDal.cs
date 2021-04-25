using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public UserDetailDto GetByIdUserDetails(int Id)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from users in context.Users
                             join customer in context.Customers
                             on users.Id equals customer.UserId
                             where users.Id == Id
                             select new UserDetailDto
                             {
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CompanyName = customer.CompanyName

                             };
                return (UserDetailDto) result;
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from users in context.Users
                             join customer in context.Customers
                             on users.Id equals customer.UserId
                             select new UserDetailDto
                             {
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CompanyName = customer.CompanyName

                             };
                return  result.ToList();
            }
        }
    }
}
