using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Food
    {
        protected Food(int foodQuantity, string type)
        {
            FoodQuantity = foodQuantity;
            Type = type;
        }

        public int FoodQuantity { get; set; }
        public string Type { get; set; }
        
    }
}
