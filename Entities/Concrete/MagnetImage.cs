using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MagnetImage:IEntity
    {
        public int Id { get; set; }
        public int MagnetId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
