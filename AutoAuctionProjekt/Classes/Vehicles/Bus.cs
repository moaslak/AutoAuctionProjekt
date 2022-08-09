using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    class Bus : HeavyVehicle
    {
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
            bool hasToilet) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            this.NumberOfSeats = numberOfSeats;
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            if (this.HasTowbar == true)
                this.DriversLisence = DriversLisenceEnum.DE;
            else
                this.DriversLisence = DriversLisenceEnum.D;
            //TODO: V8 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                //V7 - TODO value must be between 4.2 and 15.0 L or cast an out of range exection.
                throw new NotImplementedException();
                EngineSize = value;
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
            return "Name: " + this.Name + ", Km: " + this.Km + ", Registarion number: " + this.RegistrationNumber + ", Year: " + this.Year +
                ", New price: " + this.NewPrice + ", Has towbar: " + this.HasTowbar + ", Engine size: " + this.EngineSize + ", Km/L: " + this.KmPerLiter +
                ", Fuel type: " + this.FuelType + ", Number of seat: " + this.NumberOfSeats + ", Number of sleeping spaces: " + this.NumberOfSleepingSpaces +
                ", Vehicle height: " + this.VehicleDimensions.Height + ", Vehicle length: " + this.VehicleDimensions.Length + ", Vehicle weight: " + this.VehicleDimensions.Weight;
        }
    }
}
