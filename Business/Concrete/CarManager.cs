using Business.Abstract;
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
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                try
                {
                    _carDal.Add(car);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli fiyat giriniz.");
            }         

        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car Get(int Id)
        {
            return _carDal.Get(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            try
            {
                _carDal.Update(car);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
