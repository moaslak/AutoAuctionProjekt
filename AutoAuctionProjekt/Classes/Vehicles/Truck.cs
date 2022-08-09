using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    class Truck : HeavyVehicle
    {
        public Truck(
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
            double LoadCapacity) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            if (this.HasTowbar == true)
                this.DriversLisence = DriversLisenceEnum.CE;
            else
                this.DriversLisence = DriversLisenceEnum.C;
            //TODO: V11 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        /// <returns>The size the the engine as a double</returns>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                if (value > 15 || value < 4.2)
                    throw new ArgumentOutOfRangeException();

                EngineSize = value;
            }
        }
        /// <summary>
        /// Load Capacity field and proberty
        /// </summary>
        public double LoadCapacity { get; set; }
        /// <summary>
        /// Returns the Truck in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            //TODO: V12 - ToString for Truck 
            throw new NotImplementedException();
        }
    }
}
