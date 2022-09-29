using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Interfaces;

namespace TestAutoAuctionProject
{
    public class UnitTestVehicle
    {
        DatabaseConnection connection = new DatabaseConnection();
        Database database = new Database();
        Bus newBus = new Bus("NT", 50000, "ab12345", 2020, 2000000, false, 6.2, 11.2, Vehicle.FuelTypeEnum.Diesel,
                new HeavyVehicle.VehicleDimensionsStruct(4, 10000, 9), 70, 0, Vehicle.EnergyClassEnum.D,
                Vehicle.DriversLisenceEnum.D, false);
        Truck newTruck = new Truck("MAN", 50000, "cd67890", 2003, 15000, true, 7.8, 4.4, Vehicle.FuelTypeEnum.Diesel,
            new HeavyVehicle.VehicleDimensionsStruct(4.4, 20000, 15.8), Vehicle.EnergyClassEnum.C, Vehicle.DriversLisenceEnum.CE, 20000);
        PrivatePersonalCar newPrivatePersonalCar = new PrivatePersonalCar("Suzuki", 150000, "ef12345", 2014, 200000, false, 3, 21.2, Vehicle.FuelTypeEnum.Petrol,
            4, new PersonalCar.TrunkDimentionsStruct(0.5, 1, 0.7), true, Vehicle.DriversLisenceEnum.B, Vehicle.EnergyClassEnum.B);
        ProfessionalPersonalCar newProfessioalPersonalCar = new ProfessionalPersonalCar("Isuzu", 540000, "gh67890", 1905, 300, 8.2, 3, Vehicle.FuelTypeEnum.Diesel,
            2, new PersonalCar.TrunkDimentionsStruct(0.5, 1, 2), true, 15, Vehicle.DriversLisenceEnum.BE, Vehicle.EnergyClassEnum.D);

        [Fact]
        private void GetProfessionalPersonalCarsTest()
        {

            List<ProfessionalPersonalCar> proffessionalPersonalCars = database.DatabaseGet(newProfessioalPersonalCar);
            if (proffessionalPersonalCars.Count == 0)
                database.DatabaseCreate(newPrivatePersonalCar);
            proffessionalPersonalCars = database.DatabaseGet(newProfessioalPersonalCar);
            Assert.True(proffessionalPersonalCars.Count > 0);
        }

        [Fact]
        private void CreateDeleteProfessionalPersonalCarTest()
        {
            List<ProfessionalPersonalCar> proffessionalPersonalCars = database.DatabaseGet(newProfessioalPersonalCar);
            int count = proffessionalPersonalCars.Count;
            try
            {
                database.DatabaseCreate(newProfessioalPersonalCar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Assert.Equal(count + 1, proffessionalPersonalCars.Count + 1);
            List<ProfessionalPersonalCar> newList = database.DatabaseGet(newProfessioalPersonalCar);
            ProfessionalPersonalCar cleanUp = newList[newList.Count - 1];
            try
            {
                database.DatabaseDelete(cleanUp.ID, cleanUp);
                newList.RemoveAt(newList.Count - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Assert.Equal(count, newList.Count);
        }

        [Fact]
        private void UpdateSelectProfessionalPersonalCarTest()
        {
            List<ProfessionalPersonalCar> proffessionalPersonalCars = database.DatabaseGet(newProfessioalPersonalCar);
            ProfessionalPersonalCar updatedProffessionalPersonalCar = proffessionalPersonalCars[proffessionalPersonalCars.Count - 1];
            updatedProffessionalPersonalCar.Name = "Opel";
            database.DatabaseUpdate(updatedProffessionalPersonalCar);
            updatedProffessionalPersonalCar = proffessionalPersonalCars[proffessionalPersonalCars.Count - 1];
            updatedProffessionalPersonalCar = database.DatabaseSelect(updatedProffessionalPersonalCar.ID, updatedProffessionalPersonalCar);
            Assert.Equal("Opel", updatedProffessionalPersonalCar.Name);
            updatedProffessionalPersonalCar.Name = "Isuzu";
            database.DatabaseUpdate(updatedProffessionalPersonalCar);
            updatedProffessionalPersonalCar = database.DatabaseSelect(updatedProffessionalPersonalCar.ID, updatedProffessionalPersonalCar);
            Assert.Equal("Isuzu", updatedProffessionalPersonalCar.Name);
        }

        [Fact]
        private void GetPrivatePersonalCarsTest()
        {

            List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(newPrivatePersonalCar);
            if (privatePersonalCars.Count == 0)
                database.DatabaseCreate(newPrivatePersonalCar);
            privatePersonalCars = database.DatabaseGet(newPrivatePersonalCar);
            Assert.True(privatePersonalCars.Count > 0);
        }

        [Fact]
        private void CreateDeletePrivatePersonalCarTest()
        {
            List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(newPrivatePersonalCar);
            int count = privatePersonalCars.Count;
            try
            {
                database.DatabaseCreate(newPrivatePersonalCar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Assert.Equal(count + 1, privatePersonalCars.Count + 1);
            List<PrivatePersonalCar> newList = database.DatabaseGet(newPrivatePersonalCar);
            PrivatePersonalCar cleanUp = newList[newList.Count - 1];
            try
            {
                database.DatabaseDelete(cleanUp.ID, cleanUp);
                newList.RemoveAt(newList.Count - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Assert.Equal(count, newList.Count);
        }

        [Fact]
        private void UpdateSelectPrivatePersonalCarTest()
        {
            List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(newPrivatePersonalCar);
            PrivatePersonalCar updatedPrivatePersonalCar = privatePersonalCars[privatePersonalCars.Count - 1];
            updatedPrivatePersonalCar.Name = "Skoda";
            database.DatabaseUpdate(updatedPrivatePersonalCar);
            updatedPrivatePersonalCar = privatePersonalCars[privatePersonalCars.Count - 1];
            updatedPrivatePersonalCar = database.DatabaseSelect(updatedPrivatePersonalCar.ID, updatedPrivatePersonalCar);
            Assert.Equal("Skoda", updatedPrivatePersonalCar.Name);
            updatedPrivatePersonalCar.Name = "Suzuki";
            database.DatabaseUpdate(updatedPrivatePersonalCar);
            updatedPrivatePersonalCar = database.DatabaseSelect(updatedPrivatePersonalCar.ID, updatedPrivatePersonalCar);
            Assert.Equal("Suzuki", updatedPrivatePersonalCar.Name);
        }

        [Fact]
        private void GetTrucksTest()
        {

            List<Truck> trucks = database.DatabaseGet(newTruck);
            if (trucks.Count == 0)
                database.DatabaseCreate(newTruck);
            trucks = database.DatabaseGet(newTruck);
            Assert.True(trucks.Count > 0);
        }

        [Fact]
        private void CreateDeleteTruckTest()
        {
            List<Truck> trucks = database.DatabaseGet(newTruck);
            int count = trucks.Count;
            try
            {
                database.DatabaseCreate(newTruck);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Assert.Equal(count + 1, trucks.Count + 1);
            List<Truck> newList = database.DatabaseGet(newTruck);
            Truck cleanUp = newList[newList.Count - 1];
            try
            {
                database.DatabaseDelete(cleanUp.ID, cleanUp);
                newList.RemoveAt(newList.Count - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Assert.Equal(count, newList.Count);
        }

        [Fact]
        private void UpdateSelectTruckTest()
        {
            List<Truck> trucks = database.DatabaseGet(newTruck);
            Truck updatedTruck = trucks[trucks.Count - 1];
            updatedTruck.Name = "Scania";
            database.DatabaseUpdate(updatedTruck);
            updatedTruck = trucks[trucks.Count - 1];
            updatedTruck = database.DatabaseSelect(updatedTruck.ID, updatedTruck);
            Assert.Equal("Scania", updatedTruck.Name);
            updatedTruck.Name = "MAN";
            database.DatabaseUpdate(updatedTruck);
            updatedTruck = database.DatabaseSelect(updatedTruck.ID, updatedTruck);
            Assert.Equal("MAN", updatedTruck.Name);
        }


        [Fact]
        private void GetBusesTest()
        {

            List<Bus> buses = database.DatabaseGet(newBus);
            if(buses.Count == 0)
                database.DatabaseCreate(newBus);
            buses = database.DatabaseGet(newBus);
            Assert.True(buses.Count > 0);
        }

        [Fact]
        private void CreateDeleteBusTest()
        {
            List<Bus> buses = database.DatabaseGet(newBus);
            int count = buses.Count;
            try
            {
                database.DatabaseCreate(newBus);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Assert.Equal(count+1, buses.Count+1);
            List<Bus> newList = database.DatabaseGet(newBus);
            Bus cleanUp = newList[newList.Count - 1];
            try
            {
                database.DatabaseDelete(cleanUp.ID, cleanUp);
                newList.RemoveAt(newList.Count - 1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Assert.Equal(count, newList.Count);
        }

        [Fact]
        private void UpdateSelectBusTest()
        {
            List<Bus> buses = database.DatabaseGet(newBus);
            Bus updatedBus = buses[buses.Count - 1];
            updatedBus.Name = "MOVIA";
            database.DatabaseUpdate(updatedBus);
            updatedBus = buses[buses.Count - 1];
            updatedBus = database.DatabaseSelect(updatedBus.ID, updatedBus);
            Assert.Equal("MOVIA",updatedBus.Name);
            updatedBus.Name = "NT";
            database.DatabaseUpdate(updatedBus);
            updatedBus = database.DatabaseSelect(updatedBus.ID, updatedBus);
            Assert.Equal("NT",updatedBus.Name);
        }
    }
}
