using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Magnet> GetAll()
        {
            //iş kodları
            return _magnetDal.GetAll();
        }

        public List<Magnet> GetAllByCategoryId(int categoryId)
        {
            return _magnetDal.GetAll(m=>m.CategoryId==categoryId);
        }

        public List<Magnet> GetByPrice(decimal min, decimal max)
        {
            return _magnetDal.GetAll(m=>m.Price>=min && m.Price<=max);
        }
    }
}
