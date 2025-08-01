﻿using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey , T> where T : class //TKey type id and T is Entity
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        bool Exists(  Expression<  Func<T , bool> >   expression     );
        void SaveChange();
    }
}
