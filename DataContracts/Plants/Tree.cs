using System;
using System.Collections.Generic;

namespace DataContracts.Plants
{
    [Serializable]
    public class Tree : Plant
    {

        public Tree()
        {
            Random r = new Random();
            var listOfColors = new List<string> { "Green", "Brown", "Orange" };
            this.GrowthRate = r.Next(1, 4);
            this.Color = listOfColors[r.Next(listOfColors.Count)];
        }

        public override string ToString()
        {
            return $"{Color} Tree: {Id} with growth rate of {GrowthRate}";
        }
    }
}
