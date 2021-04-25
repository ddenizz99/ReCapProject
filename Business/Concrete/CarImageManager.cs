using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run
                (
                    CheckImageLimitExceeded(carImage.CarId),
                    IsImage(file)
                    //Test(file)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return result;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            //return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == Id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run
                (
                    IsImage(file)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.Updated);
        }

        //Business Codes

        private IResult CheckImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult IsImage(IFormFile file) //Resim dosyası mı?
        {
            var getExtension = Path.GetExtension(file.FileName).ToLower();
            string[] extensions = { ".jpg", ".jpeg", ".png" };
            if (extensions.Contains(getExtension))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bu bir resim değil.");
        }

        private IResult Test(IFormFile file) //Dosya boyutu ne?
        {
            //var sourcepath = Path.GetTempFileName();
            //FileInfo fileInfo = new FileInfo(sourcepath);
            //long fileLength = fileInfo.Length;
            
            return new ErrorResult("Dosya boyutu : " + FileLength.CalculateLength(file.Length));
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = "/images/default.png";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = carId,
                        ImagePath = path,
                        Date = DateTime.Now
                    }
                };
            }
            return _carImageDal.GetAll(c => c.CarId == carId);
        }
    }
}
