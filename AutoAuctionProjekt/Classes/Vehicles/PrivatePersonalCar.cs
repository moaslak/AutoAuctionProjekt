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
            //TODO: V20 - Add to database and set ID
            throw new NotImplementedException();
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
            return "Name: " + this.Name + ", Km: " + this.Km + ", Registation number: " + this.RegistrationNumber + ", Year: " + this.Year +
                ", New price: " + this.NewPrice + ", Engine size: " + this.EngineSize + ", Km/L: " + this.KmPerLiter + ", Fuel type: " + this.FuelType +
                ", Number of seats: " + this.NumberOfSeat + ", Drivers license: " + this.DriversLisence + ", Trunk height: " + this.TrunkDimentions.Height +
                ", Trunk width: " + this.TrunkDimentions.Width + ", Trunk depth: " + this.TrunkDimentions.Depth + ", Has IsoFix fittings: " + this.HasIsofixFittings;
        }
    }
}
