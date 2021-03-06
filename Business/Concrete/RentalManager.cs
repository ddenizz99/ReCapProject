using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CanACaBeRented(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.RentalDeletedError);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                var result = _rentalDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Rental>>(result);
                }
                return new ErrorDataResult<List<Rental>>(Messages.NoRental);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Rental>>(Messages.CarGetAllError);
            }
        }

        public IDataResult<Rental> GetById(int Id)
        {
            try
            {
                var result = _rentalDal.Get(r => r.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Rental>(result);
                }
                return new ErrorDataResult<Rental>(Messages.GetByIdNull);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Rental>(Messages.GetAllError);
            }
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            try
            {
                var result = _rentalDal.GetAll(r => r.CarId == carId);
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Rental>>(result);
                }
                return new ErrorDataResult<List<Rental>>(Messages.RentalCarGetByIdNull);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Rental>>(Messages.GetAllError);
            }
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.RentalUpdatedError);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            try
            {
                var result = _rentalDal.GetRentalDetails();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<RentalDetailDto>>(result);
                }
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoRental);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.CarGetAllError);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetByCarIdRentalDetails(int carId)
        {
            try
            {
                var result = _rentalDal.GetByCarIdRentalDetails(carId);
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<RentalDetailDto>>(result);
                }
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.RentalCarGetByIdNull);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.GetAllError);
            }
        }

        //Business Codes

        private IResult CanACaBeRented(int carId)
        {
            var result = GetByCarId(carId);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    if (item.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.CarRental);
                    }
                }
            }
            return new SuccessResult();
        }
    }
}
