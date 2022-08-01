using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    { 
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public object SrtingBuilder { get; private set; }

        public Car(string model, Engine engine) 
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = "n/a";
        }
        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = "n/a";
        }
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}: ");
            sb.AppendLine($" {Engine.Model}: ");
            sb.AppendLine($"  Power: {Engine.Power} ");
            if (Engine.Displacement == -1)
            {
                sb.AppendLine($"  Displacement: n/a ");
            }
            else
            {
                sb.AppendLine($"  Displacement: {Engine.Displacement} ");
            }
            sb.AppendLine($"  Efficiency: {Engine.Efficiency} ");
            if (Weight == -1)
            {
                sb.AppendLine($" Weight: n/a ");
            }
            else
            {
                sb.AppendLine($" Weight: {Weight} ");
            }
            sb.AppendLine($" Color: {Color} "); 
             
            return sb.ToString().TrimEnd();
        }

    }
}
