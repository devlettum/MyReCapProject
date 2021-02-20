using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint --> generic kısıt
    //class : referans tip olabilir
    //IEntity : IEntity olabilir,veya onu impelemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı,IEntity newlenemez.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //List<T> GetById(int id);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); //filtre vererek tek bir ürün çağırma
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
