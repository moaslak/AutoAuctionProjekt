using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class Truck : HeavyVehicle
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
            EnergyClassEnum energyClass,
            DriversLisenceEnum driversLisence,
            double LoadCapacity) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions, energyClass, driversLisence)
        {
            if (this.HasTowbar == true)
                this.DriversLisence = DriversLisenceEnum.CE;
            else
                this.DriversLisence = DriversLisenceEnum.C;
            //TODO: V11 - Add to database and set ID
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
                if (value < 4.2 || value > 15)
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
            throw new NotImplementedException();
                //return base.ToString() + ", Engine size: " + this.EngineSize + ", Load capacity: " + this.LoadCapacity;
        }
    }
}
