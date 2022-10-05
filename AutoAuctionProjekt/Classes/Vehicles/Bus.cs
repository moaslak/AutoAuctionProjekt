using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class Bus : HeavyVehicle
    {
        double minEngineSize = 4.2;
        double maxEngineSize = 15;
        public Bus (
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            VehicleDimensionsStruct vehicleDimentions,
            ushort numberOfSeats,
            ushort numberOfSleepingSpaces,
            EnergyClassEnum energyClass,
            DriversLisenceEnum driversLisence,
            bool hasToilet) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions, energyClass, driversLisence)
        {
            this.NumberOfSeats = numberOfSeats;
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            if (this.HasTowbar == true)
                this.DriversLisence = DriversLisenceEnum.DE;
            else
                this.DriversLisence = DriversLisenceEnum.D;
        }

        public Bus(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            VehicleDimensionsStruct vehicleDimentions,
            ushort numberOfSeats,
            ushort numberOfSleepingSpaces,
            bool hasToilet) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            this.NumberOfSeats = numberOfSeats;
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            if (this.HasTowbar == true)
                this.DriversLisence = DriversLisenceEnum.DE;
            else
                this.DriversLisence = DriversLisenceEnum.D;
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        private double engineSize;
        public override double EngineSize
        {
            
            get { return engineSize; }
            set
            {
                //V7 - TODO value must be between 4.2 and 15.0 L or cast an out of range exection.
                if (value >= maxEngineSize || value <= minEngineSize)
                    throw new ArgumentOutOfRangeException();
                else
                    engineSize = value;
            }
        }
        /// <summary>
        /// NumberOfSeats proberty
        /// </summary>
        public ushort NumberOfSeats { get; set; }
        /// <summary>
        /// NumberOfSeats proberty
        /// </summary>
        public ushort NumberOfSleepingSpaces { get; set; }
        /// Towbar proberty
        /// </summary>
        public bool HasToilet { get; set; }
        /// <summary>
        /// Returns the Bus in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + ", Number of seats: " + this.NumberOfSeats + ", Number of sleeping spaces: " +
                this.NumberOfSleepingSpaces + ", Has toilet: " + this.HasToilet;
        }
    }
}
