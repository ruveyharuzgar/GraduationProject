using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
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

        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(MagnetValidator))]
        [CacheRemoveAspect("IMagnetService.Get")]
        public IResult Add(Magnet magnet)
        {
            _magnetDal.Add(magnet);
            return new SuccessResult(Messages.MagnetAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Magnet magnet)
        {
            _magnetDal.Update(magnet);
            _magnetDal.Add(magnet);
            return new SuccessResult(Messages.MagnetUpdated);
        }

        public IResult Delete(Magnet magnet)
        {
            _magnetDal.Delete(magnet);
            return new SuccessResult(Messages.MagnetDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Magnet>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
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

        [CacheAspect]
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

        [ValidationAspect(typeof(MagnetValidator))]
        [CacheRemoveAspect("IMagnetService.Get")]
        public IResult Update(Magnet magnet)
        {
            _magnetDal.Update(magnet);
            return new SuccessResult(Messages.MagnetUpdated);
        }
    }
}
