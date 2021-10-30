using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryMagnetDal : IMagnetDal
    {
        List<Magnet> _magnets;
        public InMemoryMagnetDal()
        {
            _magnets = new List<Magnet>
            {
                new Magnet{Id=1,CategoryId=1,ColorId=1,Description="doğum",Price=10,Text="Rüveyha Doğdu" },
                new Magnet{Id=2,CategoryId=3,ColorId=1,Description="düğün",Price=10,Text="ü evlendi" },
                new Magnet{Id=3,CategoryId=2,ColorId=1,Description="diş",Price=10,Text="v diş çıkardı" },
                new Magnet{Id=4,CategoryId=4,ColorId=1,Description="nişan",Price=10,Text="o nişanlandı" }

            };
        }
        public void Add(Magnet magnet)
        {
            _magnets.Add(magnet);
        }

        public void Delete(Magnet magnet)
        {
            Magnet magnetToDelete;
            magnetToDelete = _magnets.SingleOrDefault(m => m.Id == magnet.Id);
            _magnets.Remove(magnetToDelete);
        }

        public Magnet Get(Expression<Func<Magnet, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Magnet> GetAll()
        {
            return _magnets;
        }

        public List<Magnet> GetAll(Expression<Func<Magnet, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Magnet> GetAllByCategory(int categoryId)
        {
            return _magnets.Where(m => m.CategoryId == categoryId).ToList();
        }
        public void Update(Magnet magnet)
        {
            Magnet magnetToUpdate;
            magnetToUpdate = _magnets.FirstOrDefault(m => m.Id == magnet.Id);
            magnetToUpdate.ColorId=magnet.ColorId;
            magnetToUpdate.CategoryId = magnet.CategoryId;
            magnetToUpdate.Description = magnet.Description;
            magnetToUpdate.Price = magnet.Price;
            magnetToUpdate.Text = magnet.Text;
        }
    }
}
