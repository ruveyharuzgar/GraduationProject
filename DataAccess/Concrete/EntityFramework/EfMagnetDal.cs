using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMagnetDal : IMagnetDal
    {
        public void Add(Magnet entity)
        {
            using (GraduationDbContext context = new GraduationDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Magnet entity)
        {
            using (GraduationDbContext context = new GraduationDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Magnet Get(Expression<Func<Magnet, bool>> filter)
        {
            using (GraduationDbContext context=new GraduationDbContext())
            {
                return context.Set<Magnet>().SingleOrDefault(filter);
            }
        }

        public List<Magnet> GetAll(Expression<Func<Magnet, bool>> filter = null)
        {
            using (GraduationDbContext context=new GraduationDbContext())
            {
                return filter == null ? context.Set<Magnet>().ToList() : context.Set<Magnet>().Where(filter).ToList();
            }
        }

        public void Update(Magnet entity)
        {
            using (GraduationDbContext context = new GraduationDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
