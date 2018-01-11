using System;
using RavenExample.Infrastructure.Entities;
using static RavenExample.Infrastructure.Storage.RavenSessionHelper;

namespace RavenExample.Infrastructure.Storage
{
    public abstract class Repository<T> : IRepository<T> 
        where T : Entity
    {
        public T Get(string id) => Open(session => session.Load<T>(id));

        public string Create(T entity) => Open(session =>
        {
            entity.Timestamp = DateTime.Now;

            session.Store(entity);
            session.SaveChanges();

            return entity.Id;
        });

        public void Delete(T entity) => Do(session =>
        {
            session.Delete(entity);
            session.SaveChanges();
        });

        public void Delete(string id) => Do(session =>
        {
            session.Delete(id);
            session.SaveChanges();
        });

        //public void SaveChanges() => Perform(session => session.SaveChanges());
    }
}
