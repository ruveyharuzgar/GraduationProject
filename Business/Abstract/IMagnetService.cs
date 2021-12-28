using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMagnetService
    {
        IDataResult<List<Magnet>> GetAll();
        IDataResult<List<Magnet>> GetAllByCategoryId(int categoryId);
        IDataResult<List<Magnet>> GetByPrice(decimal min, decimal max);
        IDataResult<List<MagnetDetailDto>> GetMagnetDetails();
        IDataResult<Magnet> GetById(int magnetId);
        IResult Add(Magnet magnet);
        IResult Delete(Magnet magnet);
        IResult Update(Magnet magnet);
        IResult AddTransactionalTest(Magnet magnet);
    }
}
