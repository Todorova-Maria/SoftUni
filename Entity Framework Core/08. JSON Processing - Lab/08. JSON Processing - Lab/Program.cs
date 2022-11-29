using _08._JSON_Processing___Lab;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDemo
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Model = "Golf",
                Vendor = "VW",
                Price = 12000.00M,
                Engine = new Engine { Volume = 1.6M, HorsePower = 80 },
            };
            File.WriteAllText("myCar.json", JsonSerializer.Serialize(car)); 
        }
    }
}
