using System;

namespace DataContracts.Animals
{
    [Serializable]
    public abstract class Animal
    {
        public Guid Id { get; protected set; }

        public Animal()
        {
            Id = Guid.NewGuid();
        }
    }
}
