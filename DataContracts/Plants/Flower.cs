using System;
using System.Collections.Generic;

namespace DataContracts.Plants
{
    [Serializable]
    public class Flower : Plant
    {
        public Flower()
        {
            Random r = new Random();
            var listOfColors = new List<string> { "Blue", "Red", "Purple", "Yellow" };
            this.GrowthRate = r.Next(8, 10);
            this.Color = listOfColors[r.Next(listOfColors.Count)];
        }

        public override string ToString()
        {
            return $"{Color} Flower: {Id} with growth rate of {GrowthRate}";
        }
    }
}
