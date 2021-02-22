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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {         
            try
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.AddedError);
            }
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.DeletedError);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                var result = _brandDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Brand>>(result);
                }
                return new ErrorDataResult<List<Brand>>(Messages.EmptyData);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Brand>>(Messages.GetAllError);
            }
        }

        public IDataResult<Brand> GetById(int Id)
        {
            try
            {
                var result = _brandDal.Get(b => b.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Brand>(result);
                }
                return new ErrorDataResult<Brand>(Messages.GetByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Brand>(Messages.GetAllError);
            }
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UpdatedError);
            }
        }
    }
}
