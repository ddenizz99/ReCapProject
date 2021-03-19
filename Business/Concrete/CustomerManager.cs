using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Customer>>(result);
            }
            return new ErrorDataResult<List<Customer>>(Messages.EmptyData);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            var result = _customerDal.Get(c => c.Id == Id);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return new ErrorDataResult<Customer>(Messages.GetByIdNull);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
