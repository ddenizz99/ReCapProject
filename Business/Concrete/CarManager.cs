using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public void Add(Car car)
        {
            try
            {
                carDal.Add(car);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Car car)
        {
            try
            {
                carDal.Delete(car);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            return carDal.GetById(Id);
        }

        public void Update(Car car)
        {
            try
            {
                carDal.Update(car);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
