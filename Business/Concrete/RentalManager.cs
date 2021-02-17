using Business.Abstract;
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

        public IResult Add(Rental rental)
        {
            var result = GetByCarId(rental.CarId);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    if (item.ReturnDate == null)
                    {
                        return new ErrorResult();
                    }
                }
                _rentalDal.Add(rental);
                return new SuccessResult();
            }          
            _rentalDal.Add(rental);
            return new SuccessResult();           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            var result = _rentalDal.Get(r => r.Id == Id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>();
            }
            else
            {
                return new SuccessDataResult<Rental>(result);
            }
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>();
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(result);
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetByCarIdRentalDetails(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetByCarIdRentalDetails(carId));
        }
    }
}
