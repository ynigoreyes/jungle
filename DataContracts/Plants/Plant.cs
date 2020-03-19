using System;
namespace DataContracts.Plants
{
    [Serializable]
    public abstract class Plant
    {
        public Guid Id { get; private set; }
        public int GrowthRate { get; protected set; }
        public string Color { get; protected set; }

        public Plant()
        {
            Id = Guid.NewGuid();
        }
    }
}
