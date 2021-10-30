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
    }
}
