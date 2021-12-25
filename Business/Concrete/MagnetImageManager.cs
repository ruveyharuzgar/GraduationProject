using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
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
    public class MagnetImageManager : IMagnetImageService
    {
        IMagnetImageDal _magnetImageDal;

        public MagnetImageManager(IMagnetImageDal magnetImageDal)
        {
            _magnetImageDal = magnetImageDal;
        }

        [ValidationAspect(typeof(MagnetImageValidator))]
        public IResult Add(IFormFile file, MagnetImage magnetImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitEx(magnetImage.MagnetId));
            if (result != null)
            {
                return result;
            }
            magnetImage.ImagePath = FileHelper.Add(file);
            magnetImage.Date = DateTime.Now;
            _magnetImageDal.Add(magnetImage);
            return new SuccessResult(Messages.MagnetImageAdded);
        }

        [ValidationAspect(typeof(MagnetImageValidator))]
        public IResult Delete(MagnetImage magnetImage)
        {
            IResult result = BusinessRules.Run(MagnetImageDelete(magnetImage));
            if (result != null)
            {
                return result;
            }
            _magnetImageDal.Delete(magnetImage);
            return new SuccessResult(Messages.MagnetImageDeleted);
        }
     
        public IDataResult<List<MagnetImage>> GetAll()
        {
            return new SuccessDataResult<List<MagnetImage>>(_magnetImageDal.GetAll(), Messages.MagnetImageListed);
        }
        public IDataResult<MagnetImage> Get(int id)
        {
            return new SuccessDataResult<MagnetImage>(_magnetImageDal.Get(m => m.Id == id));
        }

        public IDataResult<MagnetImage> GetById(int magnetImageId)
        {
            return new SuccessDataResult<MagnetImage>(_magnetImageDal.Get(m => m.Id == magnetImageId));
        }

        public IDataResult<List<MagnetImage>> GetImagesByMagnetId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfMagnetImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<MagnetImage>>(result.Message);
            }

            return new SuccessDataResult<List<MagnetImage>>(CheckIfMagnetImageNull(id).Data);
        }

        [ValidationAspect(typeof(MagnetImageValidator))]
        public IResult Update(IFormFile file, MagnetImage magnetImage)
        {
            magnetImage.ImagePath = FileHelper.Update(_magnetImageDal.Get(m => m.Id == magnetImage.Id).ImagePath, file);
            magnetImage.Date = DateTime.Now;
            _magnetImageDal.Update(magnetImage);
            return new SuccessResult(Messages.MagnetImageUpdated);
        }
        private IResult MagnetImageDelete(MagnetImage magnetImage)
        {
            try
            {
                var result = magnetImage.ImagePath;
                File.Delete(result);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private IDataResult<List<MagnetImage>> CheckIfMagnetImageNull(int id)
        {
            try
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\wwwroot\Images\default.jpg");
                var result = _magnetImageDal.GetAll(m => m.MagnetId == id).Any();
                if (!result)
                {
                    List<MagnetImage> magnetImage = new List<MagnetImage>();
                    magnetImage.Add(new MagnetImage { MagnetId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<MagnetImage>>(magnetImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<MagnetImage>>(exception.Message);
            }

            return new SuccessDataResult<List<MagnetImage>>(_magnetImageDal.GetAll(m => m.MagnetId == id).ToList());
        }

        private IResult CheckIfImageLimitEx(int magnetId)
        {
            var magnetImagecount = _magnetImageDal.GetAll(m => m.MagnetId == magnetId).Count;
            if (magnetImagecount >= 1)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }
            return new SuccessResult();
        }
    }
}
