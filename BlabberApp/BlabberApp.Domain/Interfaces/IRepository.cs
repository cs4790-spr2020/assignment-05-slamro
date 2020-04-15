using System;
using System.Collections.Generic;
//using BlabberApp.Domain.Entities;

namespace BlabberApp.Domain.Interfaces {
    public interface IRepository<T> where T : IEntity 
    {
       void Add(T entity);
       void Remove(T entity);
       void Update(T entity);
       IEnumerable<T> GetAll();
       T GetById(Guid sysId);
    }
}