using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        CarRepository cars;
        DriverRepository drivers;
        RaceRepository races; 
        public ChampionshipController()
        {
            cars = new CarRepository(); 
            drivers = new DriverRepository();
            races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            drivers.Add(driver);
            return $"Driver {driverName} is created.";


        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;

            if(type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else 
            {
                car = new SportsCar(model, horsePower);
            }
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            cars.Add(car);
            return $"{car.GetType().Name} {car.Model} is created.";

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car; 
            IDriver driver;
            car = cars.GetByName(carModel);
            driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            
            driver.AddCar(car);
            return $"Driver {driver.Name} received car {car.Model}.";
        }


        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName); 

            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driver.Name} added in {race.Name} race.";
        }



        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps); 
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            races.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
           
            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            
           
           var winners = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            races.Remove(race);

            return string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, race.Name) +
                Environment.NewLine +
                string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, race.Name) +
                Environment.NewLine +
                string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, race.Name);

            
        }
    }
}
