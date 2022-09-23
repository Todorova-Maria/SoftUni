using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)  
            : base(name, weight, livingRegion)
        {
        }

        public override void ProduceASound()
        {
            Console.WriteLine("Woof!");      
        }

        public override void Eat(string food, int quantity)
        {
            if (food == "Meat")
            {
                Weight += quantity * 0.4;
                FoodEaten += quantity;

            }
            else
            {
                Console.WriteLine($"Dog does not eat {food}!");
            }
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
