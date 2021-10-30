using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IMagnetDal
    {
        List<Magnet> GetAll();
        void Add(Magnet magnet);
        void Delete(Magnet magnet);
        void Update(Magnet magnet);
        List<Magnet> GetAllByCategory(int categoryId);
    }
}
