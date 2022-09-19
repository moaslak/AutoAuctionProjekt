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
        Database database = new AutoAuctionProjekt.Classes.Database();
        Bus newBus = new Bus("NT", 50000, "ab12345", 2020, 2000000, false, 6.2, 11.2, Vehicle.FuelTypeEnum.Diesel,
                new HeavyVehicle.VehicleDimensionsStruct(4, 10000, 9), 70, 0, Vehicle.EnergyClassEnum.D,
                Vehicle.DriversLisenceEnum.D, false);
        [Fact]
        private void GetBusesTest()
        {

            List<Bus> buses = database.DatabaseGet(newBus);
            Assert.True(buses.Count > 0);

            database.DatabaseCreate(newBus);
        }

        [Fact]
        private void CreateBusTest()
        {
            try
            {
                database.DatabaseCreate(newBus);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }

        [Fact]
        private void UpdateBusTest()
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
