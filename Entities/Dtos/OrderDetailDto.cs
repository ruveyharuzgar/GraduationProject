using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDetailDto:IDto
    {
        public int OrderId { get; set; }
        public int MagnetId { get; set; }
        public int CustomerId { get; set; }
       // public string CategoryName { get; set; }
       // public string ColorName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Text { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
