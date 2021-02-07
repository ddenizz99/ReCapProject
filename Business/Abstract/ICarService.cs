using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car Get(int Id);
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarDetails();
        List<Car> GetCarsByColorId(int colorId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
