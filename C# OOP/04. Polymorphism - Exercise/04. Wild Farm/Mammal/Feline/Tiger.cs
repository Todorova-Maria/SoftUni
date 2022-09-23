using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)  
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceASound()
        {
         Console.WriteLine("ROAR!!!"); 
        }

        public override void Eat(string food, int quantity)
        {
            if (food == "Meat")
            {
                Weight += quantity * 1;
                FoodEaten += quantity;

            }
            else
            {
                Console.WriteLine($"Tiger does not eat {food}!");
            }
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
