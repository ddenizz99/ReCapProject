using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {         
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted); 
        }

        [CacheAspect(30)]
        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Brand>>(result);
            }
            return new ErrorDataResult<List<Brand>>(Messages.EmptyData); 
        }

        public IDataResult<Brand> GetById(int Id)
        {
                var result = _brandDal.Get(b => b.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Brand>(result);
                }
                return new ErrorDataResult<Brand>(Messages.GetByIdNull);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Updated);
        }
    }
}
