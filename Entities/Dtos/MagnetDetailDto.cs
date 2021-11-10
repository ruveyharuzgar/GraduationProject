using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class MagnetDetailDto:IDto
    {
        public int MagnetId { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string Text { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
