using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>(); 
        }
        public void Add(IRace model)
        {
            races.Add(model); 
        }

        public IReadOnlyCollection<IRace> GetAll() => races;

        public IRace GetByName(string name)
        {
            var race = races.FirstOrDefault(x => x.Name == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model); 
        }
    }
}
