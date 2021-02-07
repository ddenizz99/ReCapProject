using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            Console.ReadKey();
        }

        private static void CarTest()
        {
            ICarService carService = new CarManager(new EfCarDal());

            Console.WriteLine("Yeni araç ekle : ");
            carService.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = "1999", DailyPrice = 80, Description = "F30 Kasa" });

            Console.WriteLine("Araç güncelle ;");
            carService.Update(new Car { Id = 1002, BrandId = 1, ColorId = 2, ModelYear = "2009", DailyPrice = 180, Description = "Toros" });

            Console.WriteLine("Araç Sil ;");
            carService.Delete(new Car { Id = 2002, BrandId = 3, ColorId = 3, ModelYear = "1999", DailyPrice = 80, Description = "F30 Kasa" });

            Console.WriteLine("Araçları Listele :");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine("Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", car.BrandId, car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("Id si 2 olan araç : ");
            var carId1 = carService.Get(2);
            Console.WriteLine("2 Id li Araç ; Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", carId1.BrandId, carId1.Description, carId1.ModelYear, carId1.DailyPrice);

            Console.WriteLine("Araç detaylı sıralama : ");
            foreach (var car in carService.GetCarDetails())
            {
                Console.WriteLine("Marka : {0}, Renk : {1}, Açıklama : {2}, Günlük Fiyat : {3} TL", car.BrandName, car.ColorName, car.Description, car.DailyPrice);
            }

        }

        private static void ColorTest()
        {
            IColorService colorService = new ColorManager(new EfColorDal());
            Console.WriteLine("Kırmızı rengi ekle ve renkleri göster : ");

            colorService.Add(new Color { ColorName = "Turuncu" });

            foreach (var color in colorService.GetAll())
            {
                Console.WriteLine("Renk : " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            Console.WriteLine("KIA markasını ekle ve tüm markaları göster : ");
            brandService.Add(new Brand { BrandName = "KIA" });
            foreach (var color in brandService.GetAll())
            {
                Console.WriteLine("Marka : " + color.BrandName);
            }
        }
    }
}
