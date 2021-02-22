﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {      
            try
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.AddedError);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.DeletedError);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                var result = _colorDal.GetAll();
                if (result.Count != 0)
                {
                    return new SuccessDataResult<List<Color>>(result);
                }
                return new ErrorDataResult<List<Color>>(Messages.EmptyData);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Color>>(Messages.GetAllError);
            }
        }

        public IDataResult<Color> GetById(int Id)
        {
            try
            {
                var result = _colorDal.Get(c => c.Id == Id);
                if (result != null)
                {
                    return new SuccessDataResult<Color>(result);
                }
                return new ErrorDataResult<Color>(Messages.GetByIdNull);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Color>(Messages.GetAllError);
            }
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UpdatedError);
            }
        }
    }
}
