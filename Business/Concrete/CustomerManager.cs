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
            try
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.AddedError);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.DeletedError);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                var result = _customerDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Customer>>(result);
                }
                return new ErrorDataResult<List<Customer>>(Messages.EmptyData);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Customer>>(Messages.GetAllError);
            }
        }

        public IDataResult<Customer> GetById(int Id)
        {
            try
            {
                var result = _customerDal.Get(c => c.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Customer>(result);
                }
                return new ErrorDataResult<Customer>(Messages.GetByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Customer>(Messages.GetAllError);
            }
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UpdatedError);
            }
        }
    }
}
