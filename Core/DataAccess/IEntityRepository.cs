using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class,IEntity,new()   // T'yi sınırlandırmak gerekiyor  generic constraint   Generic kısıt demek
    {                                                                    // class,IEntity,new() :: IEntty implement eden ve new'lenebilir olmalı
        // Generic repository tasarım deseni kullanıyoeeuz.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        //List<T> GetAllByCategory(int categoryId);  // Yukarıda Expression kullandık ve bu fonks'a ihtiyacımız kalmadı.
    }
}
