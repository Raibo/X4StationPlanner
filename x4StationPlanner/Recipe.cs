using System.Collections.Generic;

namespace x4StationPlanner
{
    public class Recipe
    {
        public double WorkforceMultiplier;
        public int WorkforceCapacity;
        public int Amount;
        public Dictionary<string, double> Ingredients;
    }
}
