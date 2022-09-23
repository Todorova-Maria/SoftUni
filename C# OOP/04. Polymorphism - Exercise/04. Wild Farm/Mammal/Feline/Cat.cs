using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)  
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceASound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(string food, int quantity)
        {
            if (food == "Vegetable" || food == "Meat")
            {
                Weight += quantity * 0.3;
                FoodEaten += quantity;

            }
            else
            {
                Console.WriteLine($"Cat does not eat {food}!");
            }
        }

        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
