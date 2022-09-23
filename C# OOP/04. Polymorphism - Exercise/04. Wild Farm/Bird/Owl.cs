using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)  
            : base(name, weight, wingSize)
        {
        }

        public override void ProduceASound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(string food, int quantity)
        {
            if (food == "Meat")
            {
                Weight += quantity * 0.25;
                FoodEaten += quantity;

            }
            else
            {
                Console.WriteLine($"Owl does not eat {food}!");
            }
        }
        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
