using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //ProductTest();
            //UserTest();
            RentalTest();
            Console.ReadKey();
        }

        private static void RentalTest()
        {
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var addRental = rentalService.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now });
            if (addRental.Success)
            {
                Console.WriteLine("Araç kiraya verildi.");
            }
            else
            {
                Console.WriteLine("Araç zaten şuanda kirada.");
            }
            //rentalService.Update(new Rental { Id = 3, CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 5, 1, 8, 30, 52), ReturnDate = DateTime.Now });
            //rentalService.Delete(new Rental { Id = 4 });
            Console.WriteLine("Rental Table :");
            var detailDto = rentalService.GetRentalDetails();
            foreach (var item in detailDto.Data)
            {
                Console.WriteLine("Marka : {0}, Araç : {1}, Müşteri Ad Soyad : {2} {3}, Müşteri Şirket Adı : {4}, Kiralama Tarihi : {5}, Teslim Tarihi : {6}-",
                    item.BrandName, item.CarDescription, item.CustomerFirstName, item.CustomerLastName, item.CustomerCompanyName, item.RentDate, item.ReturnDate);
            }
        }

        private static void UserTest()
        {
            IUserService userService = new UserManager(new EfUserDal());
            //var userAdd = userService.Add(new User { FirstName = "Ali", LastName = "Veli", Email = "aliveli@hotmail.com", Password = "password" });
            //if (userAdd.Success)
            //{
            //    Console.WriteLine("Yeni kişi eklendi :");
            //}

            //Console.WriteLine("Kişiler :");
            //foreach (var user in userService.GetAll().Data)
            //{
            //    Console.WriteLine("ID : " + user.Id + " Ad Soyad : " + user.FirstName + " " + user.LastName + " E-Posta : " + user.Email + " Şifre : " + user.Password);
            //}
            Console.WriteLine("Details Test :");
            var data = userService.GetAllDetails();
            if (data.Success)
            {
                foreach (var user in data.Data)
                {
                    Console.WriteLine("Ad : {0}, Soyad : {1}, Şirket Adı : {2}", user.FirstName, user.LastName, user.CompanyName);
                }
            }
        }

        private static void CarTest()
        {
            ICarService carService = new CarManager(new EfCarDal());

            //Console.WriteLine("Yeni araç ekle : ");
            //carService.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = "1999", DailyPrice = 80, Description = "F30 Kasa" });

            //Console.WriteLine("Araç güncelle ;");
            //carService.Update(new Car { Id = 1002, BrandId = 1, ColorId = 2, ModelYear = "2009", DailyPrice = 180, Description = "Toros" });

            //Console.WriteLine("Araç Sil ;");
            //carService.Delete(new Car { Id = 2002, BrandId = 3, ColorId = 3, ModelYear = "1999", DailyPrice = 80, Description = "F30 Kasa" });

            Console.WriteLine("Araçları Listele :");
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine("Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", car.BrandId, car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("Id si 2 olan araç : ");
            var carId1 = carService.Get(3).Data;
            Console.WriteLine("3 Id li Araç ; Marka : {0}, Açıklama : {1}, Model : {2}, Günlük Fiyat : {3} TL", carId1.BrandId, carId1.Description, carId1.ModelYear, carId1.DailyPrice);

            Console.WriteLine("Araç detaylı sıralama : ");
            foreach (var car in carService.GetCarDetails().Data)
            {
                Console.WriteLine("Marka : {0}, Renk : {1}, Açıklama : {2}, Günlük Fiyat : {3} TL", car.BrandName, car.ColorName, car.Description, car.DailyPrice);
            }

        }

        private static void ColorTest()
        {
            IColorService colorService = new ColorManager(new EfColorDal());
            //Console.WriteLine("Kırmızı rengi ekle ve renkleri göster : ");

            //colorService.Add(new Color { ColorName = "Turuncu" });

            foreach (var color in colorService.GetAll().Data)
            {
                Console.WriteLine("Renk : " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            //Console.WriteLine("KIA markasını ekle ve tüm markaları göster : ");
            //brandService.Add(new Brand { BrandName = "KIA" });
            foreach (var color in brandService.GetAll().Data)
            {
                Console.WriteLine("Marka : " + color.BrandName);
            }
        }

        private static void ProductTest()
        {
            IProductService productService = new ProductManager(new EfProductDal());
            List<Product> addList = new List<Product>
            {
                new Product
                {
                    ProductName = "Bilgisayar",
                    UnitPrice = 1855.65m
                },

                new Product
                {
                    ProductName = "Motorsiklet",
                    UnitPrice = 20000
                },

                new Product
                {
                    ProductName = "Telefon",
                    UnitPrice = 2055.75m
                },

                new Product
                {
                    ProductName = "Kulaklık",
                    UnitPrice = 185
                }
            };

            productService.MultipleInsertion(addList);
            Console.WriteLine("Ürünleri Listele");
            foreach (var product in productService.GetAll().Data)
            {
                Console.WriteLine("ID : {0}, Ürün : {1}, Fiyat : {2} TL", product.Id, product.ProductName, product.UnitPrice);
            }
        }
    }
}
