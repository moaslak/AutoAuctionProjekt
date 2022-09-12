using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivatePersonalCar : PersonalCar
    {
        public PrivatePersonalCar(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            ushort numberOfSeat,
            TrunkDimentionsStruct trunkDimentions,
            bool hasIsofixFittings,
            DriversLisenceEnum driversLisence, 
            EnergyClassEnum energyClass)
            : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeat, trunkDimentions, driversLisence, energyClass)
        {
            this.DriversLisence = DriversLisenceEnum.B;
        }
        /// <summary>
        /// Isofix Fittings proberty
        /// </summary>
        public bool HasIsofixFittings { get; set; }
        /// <summary>
        /// Returns the PrivatePersonalCar in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + ", Has iso fix fitting: " + this.HasIsofixFittings;
        }
    }
}
