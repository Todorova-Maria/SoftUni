using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        
        
        [Test]
        public void CreateUnitCar()
        {
            UnitCar car = new UnitCar("Toyota", 100, 50);

            Assert.AreEqual(car.Model, "Toyota");
            Assert.AreEqual(car.HorsePower, 100);
            Assert.AreEqual(car.CubicCentimeters, 50); 
        }

        [Test]
        public void CreateUnitDriver()

        {
            UnitCar car = new UnitCar("Toyota", 100, 50);
            UnitDriver driver = new UnitDriver("Pesho", car);

            Assert.AreEqual(driver.Name, "Pesho");
            Assert.AreEqual(driver.Car.Model, "Toyota");
        }

        [Test]

        public void AddMethod_ThrowException_BecauseOfNoDriver()
        {
            UnitCar car = new UnitCar("Car", 100, 40);
            UnitDriver driver = null;
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(()
                => race.AddDriver(driver));
        }

        [Test]
        public void AddMethod_ThrowsException_AddingAnExistingDriver()
        {
            UnitCar car = new UnitCar("Car", 100, 40);
            UnitDriver driver = new UnitDriver("Pesho", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver); 

            Assert.Throws<InvalidOperationException> (()
                => race.AddDriver(driver));
        }

        [Test] 
        public void AddMethod_CorrectlyAddedDiver()
        {
            UnitCar car = new UnitCar("Car", 100, 40);
            UnitDriver driver = new UnitDriver("Pesho", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.AreEqual(race.Counter, 1); 
        }

        [Test]

        public void CalculateAverageHorsePower_ThrowsException()
        {
            UnitCar car = new UnitCar("Car", 100, 40);
            UnitDriver driver = new UnitDriver("Pesho", car);
         
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);


            Assert.Throws<InvalidOperationException>(()
                => race.CalculateAverageHorsePower()); 
        }

        [Test] 
        public void CalculateAverageHorsePower()
        {
            UnitCar car = new UnitCar("Car", 100, 10);
            UnitDriver driver = new UnitDriver("Pesho", car);

            UnitCar car2 = new UnitCar("Car2", 50, 10);
            UnitDriver driver2 = new UnitDriver("Filip", car2);

            UnitCar car3 = new UnitCar("Car3", 30, 10);
            UnitDriver driver3 = new UnitDriver("Gosho", car3);

            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);
            race.AddDriver(driver2); 
            race.AddDriver(driver3);


            Assert.AreEqual(race.CalculateAverageHorsePower(), 60);
        }
    }
}