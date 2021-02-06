using Core.Entities;//core entitiesten geliyor
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//core herkese referans verir ama kimseden almaz bu kadar kral biri
namespace Core.DataAccess//core katmanı diğer katmanları referans almaz eğer alırsa sen o katmana bağımlısın demektir :)
{
    //Generic constraint
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new :new lwnebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //bu expressionn u genelde sadece birkez kullanılır bir dahada ihtiyacımız olmazmış
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); artık ihtiyacımız yok o koda
    }
}
