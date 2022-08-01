using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 2)
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]));
                    allEngines.Add(engine);
                }
                else if (input.Length == 3 && char.IsDigit(input[2][0]))
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]));
                    allEngines.Add(engine);
                }
                else if (input.Length == 3 && char.IsLetter(input[2][0]))
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]), input[2]);
                    allEngines.Add(engine);
                }
                else if (input.Length == 4)
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]) 
                        ,int.Parse(input[2]), input[3]);
                    allEngines.Add(engine);
                }
            }

            int n1 = int.Parse(Console.ReadLine());
            for (int i = 0; i < n1; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = input[1];
                Engine engine = new Engine(); 
                 

                foreach (var currentEngine in allEngines)
                {
                    if (currentEngine.Model == engineModel)
                    {
                        engine = currentEngine; 
                    }
                }
                if (input.Length == 2)
                {
                    Car car = new Car (input[0], engine);
                    allCars.Add(car);
                }
                else if (input.Length == 3 && char.IsDigit(input[2][0]))
                {
                    Car car = new Car(input[0], engine, int.Parse(input[2]));
                    allCars.Add(car);
                }
                else if (input.Length == 3 && char.IsLetter(input[2][0]))
                {
                    Car car = new Car(input[0], engine, input[2]);
                    allCars.Add(car);
                }
                else if (input.Length == 4)
                {
                    Car car = new Car(input[0], engine
                        , int.Parse(input[2]), input[3]);
                    allCars.Add(car);
                }
            }

            foreach (var car in allCars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}