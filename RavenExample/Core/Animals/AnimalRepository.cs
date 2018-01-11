using System;
using System.Collections.Immutable;
using Raven.Client.Documents.Linq;
using RavenExample.Infrastructure.Extensions;
using RavenExample.Infrastructure.Storage;
using static RavenExample.Infrastructure.Storage.RavenSessionHelper;

namespace RavenExample.Animals
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
    }

    public interface IAnimalRepository : IRepository<Animal>
    {
    }

    public interface IAnimalCreateThirdOfLionsService
    {
        void Perform();
    }

    public class AnimalCreateThirdOfLionsService : IAnimalCreateThirdOfLionsService
    {
        public void Perform() => Do(session =>
        {
            session.Store(new Animal("leo4", "lion"));
            session.Store(new Animal("leo5", "lion"));
            session.Store(new Animal("leo6", "lion"));

            session.SaveChanges();
        });
    }

    public interface IAnimalGetCreatedToday
    {
        ImmutableList<Animal> Perform();
    }

    public class AnimalGetCreatedToday : IAnimalGetCreatedToday
    {
        public ImmutableList<Animal> Perform() => Open(session =>
            //session.Advanced.DocumentQuery<Animal>()
            //.WhereGreaterThanOrEqual(animal => animal.Timestamp, DateTime.Now.StartOfDay())
            //.WhereLessThan(animal => animal.Timestamp, DateTime.Now.NextDay())
            //.ToImmutableList()

            session.Query<Animal>()
                .Where(animal => animal.Timestamp >= DateTime.Now.StartOfDay())
                .Where(animal => animal.Timestamp < DateTime.Now.NextDay())
                .ToImmutableList()
        );
    }
}
