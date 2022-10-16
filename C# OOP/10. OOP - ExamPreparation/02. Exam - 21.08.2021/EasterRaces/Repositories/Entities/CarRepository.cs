using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>(); 
        }
        
        public void Add(ICar model)
        {
           //ShouldAddException 
            cars.Add(model); 
        }

        public IReadOnlyCollection<ICar> GetAll() => cars; 
        

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(x => x.Model == name); 
            return car;
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model); 
        }
    }
}
