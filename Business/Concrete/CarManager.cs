using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);          
        }

        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarDeletedError);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                var result = _carDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Car>>(result);
                }
                return new ErrorDataResult<List<Car>>(Messages.NoCar);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(Messages.CarGetAllError);
            }

        }

        public IDataResult<Car> Get(int Id)
        {
            try
            {
                var result = _carDal.Get(c => c.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Car>(result);
                }
                return new ErrorDataResult<Car>(Messages.CarGetByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Car>(Messages.CarGetAllError);
            }
        }

        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarUpdatedError);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            try
            {
                var result = _carDal.GetAll(c => c.BrandId == brandId);
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Car>>(result);
                }
                return new ErrorDataResult<List<Car>>(Messages.CarGetBrandByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(Messages.CarGetAllError);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            try
            {
                var result = _carDal.GetAll(c => c.ColorId == colorId);
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Car>>(result);
                }
                return new ErrorDataResult<List<Car>>(Messages.CarGetByColorIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(Messages.CarGetAllError);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                var result = _carDal.GetCarDetails();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<CarDetailDto>>(result);
                }
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCar);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarGetAllError);
            }
            
        }
    }
}
