using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());

            Console.WriteLine("Yeni araç ekle : ");
            carService.Add(new Car { Id = 9, BrandId = 4, ColorId = 3, ModelYear = 1999, DailyPrice = 85, Description = "F30 Kasa" });
            var lastCar = carService.GetById(9);
            Console.WriteLine("Son Eklenen Araç ; Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", lastCar.BrandId, lastCar.Description, lastCar.ModelYear, lastCar.DailyPrice);

            Console.WriteLine("Araç Sil :");
            carService.Delete(new Car { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2016, DailyPrice = 170, Description = "Yaris B Segment" });

            Console.WriteLine("Araç Güncelle :");
            carService.Update(new Car { Id = 6, BrandId = 4, ColorId = 1, ModelYear = 2019, DailyPrice = 410, Description = "420i" });

            Console.WriteLine("Araçları Listele :");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine("Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", car.BrandId, car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("Id si 1 olan araç : ");
            var carId1 = carService.GetById(1);
            Console.WriteLine("1 Id li Araç ; Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", carId1.BrandId, carId1.Description, carId1.ModelYear, carId1.DailyPrice);

            Console.ReadKey();
        }
    }
}
