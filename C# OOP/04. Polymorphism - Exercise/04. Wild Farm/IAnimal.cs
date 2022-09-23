using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public void ProduceASound();

        public void Eat(string food, int quantity);
    }
}
