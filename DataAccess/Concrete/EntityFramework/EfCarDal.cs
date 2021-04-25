using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public CarDetailDto GetCarDetailById(int carId)
        {
            using (var context = new ReCapProjectContext())
            {
                //var result = from cars in context.Cars
                //             join colors in context.Colors
                //             on cars.ColorId equals colors.Id
                //             join brands in context.Brands
                //             on cars.BrandId equals brands.Id
                //             where cars.Id == carId
                //             select new CarDetailDto
                //             {
                //                 CarId = cars.Id,
                //                 BrandName = brands.BrandName,
                //                 ColorName = colors.ColorName,
                //                 Description = cars.Description,
                //                 DailyPrice = cars.DailyPrice
                //             };
                //return (CarDetailDto) result;
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 BrandName = brands.BrandName,
                                 ColorName = colors.ColorName,
                                 Description = cars.Description,
                                 DailyPrice = cars.DailyPrice,
                                 CoverPhotoPath = context.CarImages.
                                 FirstOrDefault(i => i.CarId == cars.Id && i.CoverPhoto == true).ImagePath ?? "/Images/default.png"
                             };
                return result.FirstOrDefault(c => c.CarId == carId);
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             select new CarDetailDto 
                             { 
                                CarId = cars.Id, BrandName = brands.BrandName, ColorName = colors.ColorName,
                                Description = cars.Description, DailyPrice = cars.DailyPrice,
                                 CoverPhotoPath = context.CarImages.
                                 FirstOrDefault(i => i.CarId == cars.Id && i.CoverPhoto == true).ImagePath ?? "/Images/default.png"
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             where brands.Id == brandId
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 BrandName = brands.BrandName,
                                 ColorName = colors.ColorName,
                                 Description = cars.Description,
                                 DailyPrice = cars.DailyPrice,
                                 CoverPhotoPath = context.CarImages.
                                 FirstOrDefault(i => i.CarId == cars.Id && i.CoverPhoto == true).ImagePath ?? "/Images/default.png"
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             where colors.Id == colorId
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 BrandName = brands.BrandName,
                                 ColorName = colors.ColorName,
                                 Description = cars.Description,
                                 DailyPrice = cars.DailyPrice,
                                 CoverPhotoPath = context.CarImages.
                                 FirstOrDefault(i => i.CarId == cars.Id && i.CoverPhoto == true).ImagePath ?? "/Images/default.png"
                             };
                return result.ToList();
            }
        }
    }
}
