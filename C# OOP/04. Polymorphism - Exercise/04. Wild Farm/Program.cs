using System;
using System.Collections.Generic;

namespace WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IAnimal> animals = new List<IAnimal>();  

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string[] foodInfo = Console.ReadLine().Split();
                string food = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                if (info[0] == "Hen")
                {
                    Bird hen = new Hen(info[1], double.Parse(info[2]), double.Parse(info[3]));
                    hen.ProduceASound();
                    hen.Eat(food, quantity); 
                    animals.Add(hen); 
                    
                }
                else if (info[0] == "Owl")
                {
                    Bird owl = new Owl(info[1], double.Parse(info[2]),double.Parse(info[3]));
                    owl.ProduceASound();
                    owl.Eat(food, quantity);
                    animals.Add(owl);
                }
                else if (info[0] == "Dog")
                {
                    Mammal dog = new Dog(info[1], double.Parse(info[2]), info[3]);
                    dog.ProduceASound();
                    dog.Eat(food, quantity);
                    animals.Add(dog);
                }
                else if (info[0] == "Mouse")
                {
                    Mammal mouse = new Mouse(info[1], double.Parse(info[2]),  info[3]);
                    mouse.ProduceASound();
                    mouse.Eat(food, quantity);
                    animals.Add(mouse);
                }
                else if (info[0] == "Cat")
                {
                    Feline cat = new Cat(info[1], double.Parse(info[2]), info[3], info[4]);
                    cat.ProduceASound();
                    cat.Eat(food, quantity);
                    animals.Add(cat);
                }
                else if (info[0] == "Tiger")
                {
                    Feline tiger = new Tiger(info[1], double.Parse(info[2]), info[3], info[4]);
                    tiger.ProduceASound();
                    tiger.Eat(food, quantity);
                    animals.Add(tiger);
                }
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
