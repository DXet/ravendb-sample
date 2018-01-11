using RavenExample.Infrastructure.Entities;

namespace RavenExample.Animals
{
    public class Animal : Entity
    {
        public Animal(string name, string kind)
        {
            Name = name;
            Kind = kind;
        }

        public string Name { get; }
        public string Kind { get; }
    }
}
