using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public abstract class PersonalCar : Vehicle
    {
        protected PersonalCar(
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
            DriversLisenceEnum driversLisence)
            : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType)
        {
            this.NumberOfSeat = numberOfSeat;
            this.TrunkDimentions = trunkDimentions;
            this.DriversLisence = driversLisence;
            this.Name = name;
            this.Year = year;
            this.Km = km;
            this.RegistrationNumber = registrationNumber;
            this.NewPrice = newPrice;
            this.HasTowbar = hasTowbar;
            this.EngineSize = engineSize;
            this.KmPerLiter = kmPerLiter;
            this.FuelType = fuelType;
            this.Year = year;
        }
        /// <summary>
        /// Number of seat proberty
        /// </summary>
        public ushort NumberOfSeat { get; set; }
        /// <summary>
        /// Trunk dimentions proberty and struct
        /// </summary>
        public TrunkDimentionsStruct TrunkDimentions { get; set; }
        public readonly struct TrunkDimentionsStruct
        {
            public TrunkDimentionsStruct(double height, double width, double depth)
            {
                Height = height;
                Width = width;
                Depth = depth;
            }
            public double Height { get; }
            public double Width { get; }
            public double Depth { get; }
            public override string ToString() => $"(Height: {Height}, Width: {Width}, Depth: {Depth})";
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 0.7 and 10.0 L or cast an out of range exection.
        /// </summary>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                //TODO: V13 - EngineSize: must be between 0.7 and 10.0 L or cast an out of range exection.
                if(EngineSize <= 0.7 && EngineSize >= 10.0)
                    EngineSize = value;
                else
                    throw new ArgumentOutOfRangeException();

            }
        }
        public int DriversLicenceClass(DriversLisenceEnum driver)
        {
            driver = DriversLisenceEnum.B;
        }
        /// <summary>
        /// Returns the PersonalCar in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            return "Name: " + this.Name + ", Km: " + this.Km + ", Registation number: " + this.RegistrationNumber + ", Year: " + this.Year +
                ", New price: " + this.NewPrice + ", Has towbar: " + this.HasTowbar + ", Engine size: " + this.EngineSize + ", Km/L: " + this.KmPerLiter +
                ", Fuel type: " + this.FuelType + ", Number of seats: " + this.NumberOfSeat + ", Trunk height: " + this.TrunkDimentions.Height +
                ", Trunk width: " + this.TrunkDimentions.Width + ", Trunk depth: " + this.TrunkDimentions.Depth;
        }
    }
}