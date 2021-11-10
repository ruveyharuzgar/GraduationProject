using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MagnetManager : IMagnetService
    {
        IMagnetDal _magnetDal;

        public MagnetManager(IMagnetDal magnetDal)
        {
            _magnetDal = magnetDal;
        }

        public IResult Add(Magnet magnet)
        {
            _magnetDal.Add(magnet);
            return new Result(true,Messages.MagnetAdded);
        }

        public IResult Delete(Magnet magnet)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Magnet>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Magnet>>(Messages.MaintenanceTime);
            }
            //iş kodları
            return new SuccessDataResult<List<Magnet>>(_magnetDal.GetAll(),Messages.MagnetsListed);
        }

        public IDataResult<List<Magnet>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Magnet>>(_magnetDal.GetAll(m=>m.CategoryId==categoryId));
        }

        public IDataResult<Magnet> GetById(int magnetId)
        {
            return new SuccessDataResult<Magnet>(_magnetDal.Get(m => m.Id == magnetId));
        }

        public IDataResult<List<Magnet>> GetByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Magnet>>(_magnetDal.GetAll(m=>m.UnitPrice >=min && m.UnitPrice<=max));
        }

        public IDataResult<List<MagnetDetailDto>> GetMagnetDetails()
        {

            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<MagnetDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<MagnetDetailDto>>(_magnetDal.GetMagnetDetails());
        }

        public IResult Update(Magnet magnet)
        {
            throw new NotImplementedException();
        }
    }
}
