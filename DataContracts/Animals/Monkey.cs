using System;

namespace DataContracts.Animals
{
    [Serializable]
    public class Monkey : Animal
    {
        public override string ToString()
        {
            return $"Monkey: {Id}";
        }
    }
}
