using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)  
            : base(name, weight, wingSize)
        {
        }
        public override void ProduceASound()
        {
            Console.WriteLine("Cluck");
        }
        public override void Eat(string food, int quantity)
        {
            Weight += quantity * 0.35;
            FoodEaten += quantity;
        }
        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

    }
}
