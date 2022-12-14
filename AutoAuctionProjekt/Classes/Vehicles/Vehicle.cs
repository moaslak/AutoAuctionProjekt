using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public abstract class Vehicle
    {
        protected Vehicle(string name,
            double km,
            string registrationNumber,
            int year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            DriversLisenceEnum driversLisence,
            EnergyClassEnum energyClass)
        {
            this.Name = name;
            this.Km = km;
            this.RegistrationNumber = registrationNumber;
            this.Year = year;
            this.NewPrice = newPrice;
            this.HasTowbar = hasTowbar;
            this.EngineSize = engineSize;
            this.KmPerLiter = kmPerLiter;
            this.FuelType = fuelType;
            this.EnergyClass = energyClass;
            this.DriversLisence = driversLisence;
        }

        protected Vehicle(string name, double km, string registrationNumber, ushort year, decimal newPrice, bool hasTowbar, double engineSize, double kmPerLiter, FuelTypeEnum fuelType)
        {
            this.Name = name;
            this.Km = km;
            this.RegistrationNumber = registrationNumber;
            this.Year = year;
            this.NewPrice = newPrice;
            this.HasTowbar = hasTowbar;
            this.EngineSize = engineSize;
            this.KmPerLiter = kmPerLiter;
            this.FuelType = fuelType;
            this.EnergyClass = energyClass;
        }
        /// <summary>
        /// ID field and proberty
        /// </summary>
        public uint ID { get; private set; }
        
        public void SetId(uint Id)
        {
            this.ID = Id;
        }

        /// <summary>
        /// Name field and proberty
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Km field and proberty
        /// </summary>
        public double Km { get; set; }
        /// <summary>
        /// Registration number field and proberty
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Year field and proberty
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// New price field and proberty
        /// </summary>
        public decimal NewPrice { get; set; }
        /// <summary>
        /// Towbar field and proberty
        /// </summary>
        public bool HasTowbar { get; set; }
        /// <summary>
        /// Engine size field and proberty
        /// </summary>
        public virtual double EngineSize { get; set; }
        /// <summary>
        /// Km per liter field and proberty
        /// </summary>
        public double KmPerLiter { get; set; }
        /// <summary>
        /// Drivers lisence Enum, field and proberty
        /// </summary>
        public DriversLisenceEnum DriversLisence { get; set; }
        public enum DriversLisenceEnum
        {
            A,
            B,
            C,
            D,
            BE,
            CE,
            DE
        }
        /// <summary>
        /// NFuel type Enum, field and proberty
        /// </summary>
        public FuelTypeEnum FuelType { get; set; }
        public enum FuelTypeEnum
        {
            Diesel,
            Petrol
        }
        /// <summary>
        /// Engery class Enum, field and proberty
        /// </summary>

        private EnergyClassEnum energyClass;
        public EnergyClassEnum EnergyClass { get { return energyClass; } set => GetEnergyClass(); }
        public enum EnergyClassEnum
        {
            A,
            B,
            C,
            D
        }
        /// <summary>
        /// Engery class is calculated bassed on year of the car and the efficiancy in km/L.
        /// </summary>
        /// <returns>
        /// Returns the energy class in EnergyClassEnum (A,B,C,D)
        /// </returns>
        private EnergyClassEnum GetEnergyClass()
        {
            byte aClassOldDiesel = 23;
            byte bClassOldDiesel = 18;
            byte cClassOldDiesel = 13;
            byte aClassOldPetrol = 18;
            byte bClassOldPetrol = 14;
            byte cClassOldPetrol = 10;

            byte aClassNewDiesel = 25;
            byte bClassNewDiesel = 20;
            byte cClassNewDiesel = 15;
            byte aClassNewPetrol = 20;
            byte bClassNewPetrol = 16;
            byte cClassNewPetrol = 12;


            if(this.Year < 2010)
            {
                if(this.FuelType == FuelTypeEnum.Diesel)
                {
                    if (this.KmPerLiter >= aClassOldDiesel)
                        this.energyClass = EnergyClassEnum.A;
                    if (this.KmPerLiter < aClassOldDiesel && this.KmPerLiter >= bClassOldDiesel)
                        this.energyClass = EnergyClassEnum.B;
                    if (this.KmPerLiter < bClassOldDiesel && this.KmPerLiter >= cClassOldDiesel)
                        this.energyClass = EnergyClassEnum.C;
                    else
                        this.energyClass = EnergyClassEnum.D;
                }
                else if (this.FuelType == FuelTypeEnum.Petrol)
                {
                    if (this.KmPerLiter >= aClassOldPetrol)
                        this.energyClass = EnergyClassEnum.A;
                    if (KmPerLiter < aClassOldPetrol && this.KmPerLiter >= bClassOldPetrol)
                        this.energyClass = EnergyClassEnum.B;
                    if (this.KmPerLiter < bClassOldPetrol && this.KmPerLiter >= cClassOldPetrol)
                        this.energyClass = EnergyClassEnum.C;
                    else
                        this.energyClass = EnergyClassEnum.D;
                }
            }
            else if (this.Year >= 2010)
            {
                if (this.FuelType == FuelTypeEnum.Diesel)
                {
                    if (this.KmPerLiter >= aClassNewDiesel)
                        this.energyClass = EnergyClassEnum.A;
                    if (this.KmPerLiter < aClassNewDiesel && this.KmPerLiter >= bClassNewDiesel)
                        this.energyClass = EnergyClassEnum.B;
                    if (this.KmPerLiter < bClassNewDiesel && this.KmPerLiter >= cClassNewDiesel)
                        this.energyClass = EnergyClassEnum.C;
                    else
                        this.energyClass = EnergyClassEnum.D;
                }
                else if (this.FuelType == FuelTypeEnum.Petrol)
                {
                    if (this.KmPerLiter >= aClassNewPetrol)
                        this.energyClass = EnergyClassEnum.A;
                    if (this.KmPerLiter < aClassNewPetrol && this.KmPerLiter >= bClassNewPetrol)
                        this.energyClass = EnergyClassEnum.B;
                    if (this.KmPerLiter < bClassNewPetrol && this.KmPerLiter >= cClassNewPetrol)
                        this.energyClass = EnergyClassEnum.C;
                    else
                        this.energyClass = EnergyClassEnum.D;
                }
            }
            return EnergyClassEnum.A;
        }
        /// <summary>
        /// Returns the vehicle in a string with relivant information.
        /// </summary>
        /// <returns>The Veihcle as a string</returns>
        public new virtual string ToString()
        {
            return("ID: " + ID +
                   ", Name: " + Name +
                   ", Number of km: " + Km +
                   ", Registration number: " + RegistrationNumber +
                   ", Year: " + Year +
                   ", New price: " + NewPrice +
                   ", Tow bar: " + HasTowbar +
                   ", Engine size: " + EngineSize +
                   ", Km/l: " + KmPerLiter +
                   ", Fuel type: " + FuelType);
        }
    }
}
