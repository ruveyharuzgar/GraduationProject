using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMagnetDal : EfEntityRepositoryBase<Magnet, GraduationDbContext>, IMagnetDal
    {
        public List<MagnetDetailDto> GetMagnetDetails()
        {
            using (GraduationDbContext context=new GraduationDbContext())
            {
                var result = from m in context.Magnets
                             join ca in context.Categories
                             on m.CategoryId equals ca.CategoryId
                             join co in context.Colors
                             on m.ColorId equals co.ColorId
                             select new MagnetDetailDto
                             {
                                 MagnetId=m.Id,
                                 UnitPrice = m.UnitPrice,
                                 Quantity = m.Quantity,
                                 Text=m.Text,
                                 CategoryName=ca.CategoryName,
                                 ColorName=co.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
