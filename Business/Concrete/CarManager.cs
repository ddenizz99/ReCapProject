using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheAspect(30)]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);          
        }

        public IResult Delete(Car car)
        {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoCar);
        }

        [CacheAspect]
        public IDataResult<Car> Get(int Id)
        {   
            var result = _carDal.Get(c => c.Id == Id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(Messages.CarGetByIdNull); 
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        { 
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);     
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        { 
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(Messages.CarGetBrandByIdNull); 
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(Messages.CarGetByColorIdNull);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {  
            var result = _carDal.GetCarDetails();
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCar); 
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetailsByBrandId(brandId);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarGetBrandByIdNull);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetailsByColorId(colorId);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarGetBrandByIdNull);
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetailById(int carId)
        {
            var result = _carDal.GetCarDetailById(carId);
            if (result != null)
            {
                return new SuccessDataResult<CarDetailDto>(result);
            }
            return new ErrorDataResult<CarDetailDto>(Messages.NoCar);
        }
    }
}
