using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T,TContext>:IGenericDal<T> 
        where T: class,new()
        where TContext :DbContext,new()
    {

        public void Delete(T t)
        {
           using(TContext context=new TContext())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T t)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(T t)
        {

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
