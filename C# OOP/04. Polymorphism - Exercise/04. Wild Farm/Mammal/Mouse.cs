using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)  
            : base(name, weight, livingRegion)
        {
        }
        public override void ProduceASound()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(string food, int quantity)
        {
            if(food == "Vegetable" || food == "Fruit")
            {
                Weight += quantity * 0.1; 
                FoodEaten += quantity;
                    
            }  
            else
            {
                Console.WriteLine($"Mouse does not eat {food}!"); 
            }
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
