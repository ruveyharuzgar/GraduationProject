using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMagnetService
    {
        List<Magnet> GetAll();
        List<Magnet> GetAllByCategoryId(int categoryId);
        List<Magnet> GetByPrice(decimal min, decimal max);
        List<MagnetDetailDto> GetMagnetDetails();
    }
}
