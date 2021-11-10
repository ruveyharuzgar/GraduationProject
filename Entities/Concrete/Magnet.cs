using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Magnet:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        //ürün açıklaması
        public string Text { get; set; }
        //ürünün üstüne yazılacak olan metinsel açıklama
    }
}
