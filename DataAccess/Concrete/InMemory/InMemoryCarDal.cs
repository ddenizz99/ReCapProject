using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars = new List<Car> 
        {
            new Car { Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2017, DailyPrice = 250, Description = "Cerato C Segment" },
            new Car { Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2014, DailyPrice = 200, Description = "Corolla C Segment" },
            new Car { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2016, DailyPrice = 170, Description = "Yaris B Segment" },
            new Car { Id = 4, BrandId = 1, ColorId = 1, ModelYear = 2018, DailyPrice = 220, Description = "Rio B Segment" },
            new Car { Id = 5, BrandId = 1, ColorId = 3, ModelYear = 2020, DailyPrice = 420, Description = "Sportage 4x4" },
            new Car { Id = 6, BrandId = 4, ColorId = 3, ModelYear = 2019, DailyPrice = 450, Description = "420i" },
            new Car { Id = 7, BrandId = 3, ColorId = 2, ModelYear = 2010, DailyPrice = 100, Description = "Civic D Segment" }
        };
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            cars.Remove(GetById(car.Id));
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int Id)
        {
            return cars.Find(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            var result = GetById(car.Id);
            result.ColorId = car.ColorId;
            result.BrandId = car.BrandId;
            result.ModelYear = car.ModelYear;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;
        }
    }
}
