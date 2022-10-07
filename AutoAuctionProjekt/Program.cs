using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Classes
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Makes a string of vehicles from a list.
        /// </summary>
        /// <param name="vehicles"></param>
        /// <returns> A string of vehicle information </returns>
        public static string PrintVehicleList(List<Vehicle> vehicles)
        {
            vehicles.Clear();
            Database database = new Database();
            Truck t = null;
            Bus b = null;
            ProfessionalPersonalCar ppc = null;
            PrivatePersonalCar privateCar = null;
            string outputString = "";
            List<Truck> trucks = database.DatabaseGet(t);
            List<Bus> buses = database.DatabaseGet(b);
            List<ProfessionalPersonalCar> professionalPersonalCars = database.DatabaseGet(ppc);
            List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(privateCar);
            
            Console.Write("Number of trucks: " + trucks.Count);
            Console.WriteLine();
            foreach (Truck truck in trucks)
                vehicles.Add(truck);
            
            Console.Write("Number of buses: " + buses.Count);
            Console.WriteLine();
            foreach (Bus bus in buses)
                vehicles.Add(bus);
            
            Console.Write("Number of professional personal cars: " + professionalPersonalCars.Count);
            Console.WriteLine();
            foreach (ProfessionalPersonalCar professionalPersonalCar in professionalPersonalCars)
                vehicles.Add(professionalPersonalCar);

            Console.Write("Number of private personal cars : " + privatePersonalCars.Count);
            Console.WriteLine();
            foreach (PrivatePersonalCar privatePersonalCar in privatePersonalCars)
                vehicles.Add(privatePersonalCar);

            foreach(Vehicle vehicle in vehicles)
                outputString = outputString + vehicle.ToString() + "\n";

            return outputString;
        }
        /// <summary>
        /// Makes a string of ISellers from a list.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static string PrintISellerList(List<ISeller> users)
        {
            //TODO: return formatted string with users from list
            throw new NotImplementedException();
        }
    }
}
