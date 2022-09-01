using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace Masterchef
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numberOfIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] freshnessLevelOfTheIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<string, int> dishes = new Dictionary<string, int>();
             
            Queue<int> num = new Queue<int>(numberOfIngredients);
            Stack<int> freshness = new Stack<int>(freshnessLevelOfTheIngredients);


            
          
                while (true)
                {
                    if(num.Count == 0 || freshness.Count == 0 )
                {
                    break;
                }  
                        if(num.Peek() == 0)
                {
                    num.Dequeue();
                    continue;
                }
                        if (num.Peek() * freshness.Peek() == 150)
                        {
                            if (!dishes.ContainsKey("Dipping sauce"))
                            {
                                dishes.Add("Dipping sauce", 1);
                            }
                            else
                            {
                                dishes["Dipping sauce"]++;
                            }
                            num.Dequeue();
                            freshness.Pop();
                        }
                        else if (num.Peek() * freshness.Peek() == 250)
                        {
                            if (!dishes.ContainsKey("Green salad"))
                            {
                                dishes.Add("Green salad", 1);
                            }
                            else
                            {
                                dishes["Green salad"]++;
                            }
                            num.Dequeue();
                            freshness.Pop();
                        }
                        else if (num.Peek() * freshness.Peek() == 300)
                        {
                            if (!dishes.ContainsKey("Chocolate cake"))
                            {
                                dishes.Add("Chocolate cake", 1);
                            }
                            else
                            {
                                dishes["Chocolate cake"]++;
                            }
                            num.Dequeue();
                            freshness.Pop();
                        }
                        else if (num.Peek() * freshness.Peek() == 400)
                        {
                            if (!dishes.ContainsKey("Lobster"))
                            {
                                dishes.Add("Lobster", 1);
                            }
                            else
                            {
                                dishes["Lobster"]++;
                            }
                            num.Dequeue();
                            freshness.Pop();
                        }
                        else
                        {
                            freshness.Pop();
                            int n = num.Dequeue() + 5;
                            num.Enqueue(n);
                        }
                    }
                
            
           

            int allDishes = 0;
            int countDishes = 0;
            foreach (var dish in dishes)
            {
                allDishes += dish.Value;
                countDishes++;
            } 
              
            // Print result
            if(allDishes >= 4 && countDishes== 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }  
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
             
            //Print allIngrediants
            if(num.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {num.Sum()}");
            }

            //Print allDishes 

            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($"# {dish.Key} --> {dish.Value}");
            }
        }
    }
}