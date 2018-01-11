using RavenExample.Infrastructure.Entities;

namespace RavenExample.Infrastructure.Storage
{
    public interface IRepository<T> 
        where T : Entity
    {
        T Get(string id);

        string Create(T entity);

        void Delete(T entity);

        void Delete(string id);

        //void SaveChanges();
    }
}
