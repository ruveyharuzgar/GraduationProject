using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, GraduationDbContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (GraduationDbContext context=new GraduationDbContext())
            {
                var result = from o in context.Orders
                             join m in context.Magnets on o.MagnetId equals m.Id
                             join c in context.Customers on o.CustomerId equals c.Id

                             select new OrderDetailDto
                             {
                                 
                                 OrderId=o.Id,
                                 MagnetId=m.Id,
                                 CustomerId=c.Id,
                                 UnitPrice=m.UnitPrice,
                                 Quantity=m.Quantity,
                                 Text=m.Text,
                                 OrderDate=o.OrderDate,
                                 ShippedDate=o.ShippedDate
                             };
                return result.ToList();
            }
        }
    }
}
