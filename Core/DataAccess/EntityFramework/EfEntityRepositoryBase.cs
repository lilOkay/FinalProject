using Core.Entities;
using Microsoft.EntityFrameworkCore; //DbContext buradan geliyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{//bu yaptıklarımız sayesinde artık ekleme silme güncelleme gibi işleri sadece bir kere yapmış olucaz dieğr heryer de kullanıcaz
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>       //bana bi entity ve context ver çalışacam demekmiş
        where TEntity: class, IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//burada referansı yakalıyoruz
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//bu o işlemi yapar
            }
        }

        

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
                //select * from product dödürüyor
            }
        }

        

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

       
    }
}
