using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMagnetImageService
    {
        IDataResult<List<MagnetImage>> GetAll();
        IDataResult<MagnetImage> Get(int id);
        IDataResult<MagnetImage> GetById(int magnetImageId);
        IDataResult<List<MagnetImage>> GetImagesByMagnetId(int id);
        IResult Add(IFormFile file, MagnetImage magnetImage);
        IResult Update(IFormFile file, MagnetImage magnetImage);
        IResult Delete(MagnetImage magnetImage);
    }
}
