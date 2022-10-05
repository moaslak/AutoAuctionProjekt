using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static AutoAuctionProjekt.Classes.Vehicle;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for SetForSaleWindow.xaml
    /// </summary>
    public partial class SetForSaleWindow : Window
    {
        //TODO: SET KM PR L, drivers license, energy class
        public SetForSaleWindow(User user)
        {
            InitializeComponent();
            PrivatePersonalCarRdBtn.IsChecked = true;
            this.User = user;
        }

        private User User { get; set; }

        private List<Auction> Auctions { get; set; }
        private List<Auction> MyAuctions { get; set; }
        private Auction Auction { get; set; }

        Database database = new Database();

        private void HeavyVehicleSelected()
        {
            TrunkDimensionLbl.Visibility = Visibility.Hidden;
            TrunkHeightTxtBoxLbl.Visibility = Visibility.Hidden;
            TrunkHeightTxtBox.Visibility = Visibility.Hidden;
            TrunkWidthTxtBoxLbl.Visibility = Visibility.Hidden;
            TrunkWidthTxtBox.Visibility = Visibility.Hidden;
            TrunkDepthTxtBoxLbl.Visibility = Visibility.Hidden;
            TrunkDepthTxtBox.Visibility = Visibility.Hidden;
            NumberOfSeatsLbl.Visibility = Visibility.Hidden;
            NumberOfSeatsTxtBox.Visibility = Visibility.Hidden;
            HasISOFittingsLbl.Visibility = Visibility.Hidden;
            HasISOFittingCheckBox.Visibility = Visibility.Hidden;

            VehicleDimensionLbl.Visibility = Visibility.Visible;
            LengthTxtBoxLbl.Visibility = Visibility.Visible;
            LengthTxtBox.Visibility = Visibility.Visible;
            HeightTxtBoxLbl.Visibility = Visibility.Visible;
            HeightTxtBox.Visibility = Visibility.Visible;
            WeightTxtBoxLbl.Visibility = Visibility.Visible;
            WeightTxtBox.Visibility = Visibility.Visible;
        }

        private void PersonalCarSelected()
        {
            VehicleDimensionLbl.Visibility = Visibility.Hidden;
            LengthTxtBoxLbl.Visibility = Visibility.Hidden;
            LengthTxtBox.Visibility = Visibility.Hidden;
            HeightTxtBoxLbl.Visibility = Visibility.Hidden;
            HeightTxtBox.Visibility = Visibility.Hidden;
            WeightTxtBoxLbl.Visibility = Visibility.Hidden;
            WeightTxtBox.Visibility = Visibility.Hidden;
            NumberOfSleepingSpacesLbl.Visibility = Visibility.Hidden;
            NumberOfSleepingSpacesTxtbox.Visibility = Visibility.Hidden;
            HasToiletlbl.Visibility = Visibility.Hidden;
            HasToiletCheckBox.Visibility = Visibility.Hidden;

            TrunkDimensionLbl.Visibility = Visibility.Visible;
            TrunkHeightTxtBoxLbl.Visibility = Visibility.Visible;
            TrunkHeightTxtBox.Visibility = Visibility.Visible;
            TrunkWidthTxtBoxLbl.Visibility = Visibility.Visible;
            TrunkWidthTxtBox.Visibility = Visibility.Visible;
            TrunkDepthTxtBoxLbl.Visibility = Visibility.Visible;
            TrunkDepthTxtBox.Visibility = Visibility.Visible;
            NumberOfSeatsLbl.Visibility = Visibility.Visible;
            NumberOfSeatsTxtBox.Visibility = Visibility.Visible;
        }

        private void TruckSelected()
        {
            HeavyVehicleSelected();
            NumberOfSeatsLbl.Visibility = Visibility.Hidden;
            NumberOfSeatsTxtBox.Visibility = Visibility.Hidden;
            NumberOfSleepingSpacesLbl.Visibility = Visibility.Hidden;
            NumberOfSleepingSpacesTxtbox.Visibility = Visibility.Hidden;
            HasToiletlbl.Visibility = Visibility.Hidden;
            HasToiletCheckBox.Visibility = Visibility.Hidden;

            LoadCapacityLbl.Visibility = Visibility.Visible;
            LoadCapacityTxtBox.Visibility = Visibility.Visible;
        }

        private void BusSelected()
        {
            HeavyVehicleSelected();
            LoadCapacityLbl.Visibility = Visibility.Hidden;
            LoadCapacityTxtBox.Visibility = Visibility.Hidden;
            HasSaftyBarLbl.Visibility = Visibility.Hidden;
            HasSaftyBarCheckBox.Visibility = Visibility.Hidden;

            NumberOfSeatsLbl.Visibility = Visibility.Visible;
            NumberOfSeatsTxtBox.Visibility = Visibility.Visible;
            NumberOfSleepingSpacesLbl.Visibility = Visibility.Visible;
            NumberOfSleepingSpacesTxtbox.Visibility = Visibility.Visible;
            HasToiletlbl.Visibility = Visibility.Visible;
            HasToiletCheckBox.Visibility = Visibility.Visible;
        }

        private void PrivateCarSelected()
        {
            PersonalCarSelected();

            HasSaftyBarLbl.Visibility = Visibility.Hidden;
            HasSaftyBarCheckBox.Visibility = Visibility.Hidden;
            LoadCapacityLbl.Visibility = Visibility.Hidden;
            LoadCapacityTxtBox.Visibility = Visibility.Hidden;

            HasISOFittingsLbl.Visibility = Visibility.Visible;
            HasISOFittingCheckBox.Visibility = Visibility.Visible;
        }

        private void ProffessionalCarSelected()
        {
            PersonalCarSelected();
            HasISOFittingsLbl.Visibility = Visibility.Hidden;
            HasISOFittingCheckBox.Visibility = Visibility.Hidden;

            HasSaftyBarLbl.Visibility = Visibility.Visible;
            HasSaftyBarCheckBox.Visibility = Visibility.Visible;
            LoadCapacityLbl.Visibility = Visibility.Visible;
            LoadCapacityTxtBox.Visibility = Visibility.Visible;
        }

        private void PrivatePersonalCarRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (PrivatePersonalCarRdBtn.IsChecked == true)
            {
                ProfefssionalPersonalCarRdBtn.IsChecked = false;
                TruckRdBtn.IsChecked = false;
                BusRdBtn.IsChecked = false;
            }

            PrivateCarSelected();
        }

        private void ProfefssionalPersonalCarRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ProfefssionalPersonalCarRdBtn.IsChecked == true)
            {
                PrivatePersonalCarRdBtn.IsChecked = false;
                TruckRdBtn.IsChecked = false;
                BusRdBtn.IsChecked = false;
            }
            ProffessionalCarSelected();
        }

        private void TruckRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (TruckRdBtn.IsChecked == true)
            {
                PrivatePersonalCarRdBtn.IsChecked = false;
                ProfefssionalPersonalCarRdBtn.IsChecked = false;
                BusRdBtn.IsChecked = false;
            }
            TruckSelected();
        }

        private void BusRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (BusRdBtn.IsChecked == true)
            {
                PrivatePersonalCarRdBtn.IsChecked = false;
                ProfefssionalPersonalCarRdBtn.IsChecked = false;
                TruckRdBtn.IsChecked = false;
            }
            BusSelected();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MyAuctions = database.DatabaseGetForUser(Auction, User);
            Auctions = database.DatabaseGet(Auction);
            //MainWindow mainWindow = new MainWindow(User, Auctions, MyAuctions);
            MainWindow mainWindow = new MainWindow(User);
            mainWindow.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateAuctionBtn_Click(object sender, RoutedEventArgs e)
        {
            bool SUCCES = false;

            if (EngineSizeTxtBox.Text == "")
                EngineSizeTxtBox.Text = "0";
            double minEngineSizeHeavy = 4.2;
            double maxEngineSizeHeavy = 15;
            double minEngineSizePersonal = 0.7;
            double maxEngineSizePersoanl = 10;

            bool hasTowBar = false;
            if (TowBarCheckBox.IsChecked == true)
                hasTowBar = true;
            bool hasISOFittings = false;
            if (HasISOFittingCheckBox.IsChecked == true)
                hasISOFittings = true;
            bool hasToilet = false;
            if (HasToiletCheckBox.IsChecked == true)
                hasToilet = true;
            bool hasSaftyBar = false;
            if (HasSaftyBarCheckBox.IsChecked == true)
                hasSaftyBar = true;

            PrivatePersonalCar.FuelTypeEnum fuelType = new Vehicle.FuelTypeEnum();
            if (FuelTypeComboBox.Text == "Diesel")
                fuelType = Vehicle.FuelTypeEnum.Diesel;
            if (FuelTypeComboBox.Text == "Petrol")
                fuelType = Vehicle.FuelTypeEnum.Petrol;

            if (PrivatePersonalCarRdBtn.IsChecked == true)
            {
                if (Convert.ToDouble(EngineSizeTxtBox.Text) > maxEngineSizePersoanl || Convert.ToDouble(EngineSizeTxtBox.Text) < minEngineSizePersonal)
                {
                    MessageBox.Show("Engine size MUST be between " + minEngineSizePersonal + " L and " + maxEngineSizePersoanl + " L!");
                    EngineSizeTxtBox.Text = "";
                }

                if (!(NameTxtBox.Text == "" || MilageTxtBox.Text == "" || RegNumTxtBox.Text == "" || YearTxtBox.Text == "" || MinPriceTxtBox.Text == ""
                    || ClosingDateTxtBox.Text == "" || TrunkHeightTxtBox.Text == "" || TrunkWidthTxtBox.Text == "" || TrunkDepthTxtBox.Text == ""
                    || EngineSizeTxtBox.Text == "" || NumberOfSeatsTxtBox.Text == ""))
                {
                    PrivatePersonalCar privatePersonalCar = new PrivatePersonalCar(NameTxtBox.Text, Convert.ToDouble(MilageTxtBox.Text), RegNumTxtBox.Text, Convert.ToUInt16(YearTxtBox.Text),
                        Convert.ToDecimal(MinPriceTxtBox.Text), hasTowBar, Convert.ToDouble(EngineSizeTxtBox.Text), Convert.ToDouble(KmLTextbox.Text), fuelType, Convert.ToUInt16(NumberOfSeatsTxtBox.Text),
                        new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(TrunkHeightTxtBox.Text), Convert.ToDouble(TrunkWidthTxtBox.Text), Convert.ToDouble(TrunkDepthTxtBox.Text)),
                        hasISOFittings, DriversLisenceEnum.B, EnergyClassEnum.A);
                    database.DatabaseCreate(privatePersonalCar);
                    List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(privatePersonalCar);
                    privatePersonalCar = privatePersonalCars[privatePersonalCars.Count - 1];
                    Auction newAuction = new Auction(privatePersonalCar, User, privatePersonalCar.NewPrice, Convert.ToDateTime(ClosingDateTxtBox.Text));
                    newAuction.Seller.UserName = User.UserName;
                    database.DatabaseCreate(newAuction);
                    MessageBox.Show("Auction created");
                    SUCCES = true;
                }
                else
                    MessageBox.Show("ALL fields must be filled!");

            }
            if (ProfefssionalPersonalCarRdBtn.IsChecked == true)
            {
                if (Convert.ToDouble(EngineSizeTxtBox.Text) > maxEngineSizePersoanl || Convert.ToDouble(EngineSizeTxtBox.Text) < minEngineSizePersonal)
                {
                    MessageBox.Show("Engine size MUST be between " + minEngineSizePersonal + " L and " + maxEngineSizePersoanl + " L!");
                    EngineSizeTxtBox.Text = "";
                }

                if (!(NameTxtBox.Text == "" || MilageTxtBox.Text == "" || RegNumTxtBox.Text == "" || YearTxtBox.Text == "" || MinPriceTxtBox.Text == ""
                    || ClosingDateTxtBox.Text == "" || TrunkHeightTxtBox.Text == "" || TrunkWidthTxtBox.Text == "" || TrunkDepthTxtBox.Text == ""
                    || EngineSizeTxtBox.Text == "" || NumberOfSeatsTxtBox.Text == "" || LoadCapacityTxtBox.Text == ""))
                {
                    ProfessionalPersonalCar professionalPersonalCar = new ProfessionalPersonalCar(NameTxtBox.Text, Convert.ToDouble(MilageTxtBox.Text), RegNumTxtBox.Text, Convert.ToUInt16(YearTxtBox.Text),
                        Convert.ToDecimal(MinPriceTxtBox.Text), Convert.ToDouble(EngineSizeTxtBox.Text), 0, fuelType, Convert.ToUInt16(NumberOfSeatsTxtBox.Text),
                        new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(TrunkHeightTxtBox.Text), Convert.ToDouble(TrunkWidthTxtBox.Text), Convert.ToDouble(TrunkDepthTxtBox.Text)), hasSaftyBar,
                        Convert.ToDouble(LoadCapacityTxtBox.Text), Vehicle.DriversLisenceEnum.A, Vehicle.EnergyClassEnum.A);
                    database.DatabaseCreate(professionalPersonalCar);
                    List<ProfessionalPersonalCar> professionalPersonalCars = database.DatabaseGet(professionalPersonalCar);
                    professionalPersonalCar = professionalPersonalCars[professionalPersonalCars.Count - 1];
                    Auction newAuction = new Auction(professionalPersonalCar, User, professionalPersonalCar.NewPrice, Convert.ToDateTime(ClosingDateTxtBox.Text));
                    newAuction.Seller.UserName = User.UserName;
                    database.DatabaseCreate(newAuction);
                    MessageBox.Show("Auction created");
                    SUCCES = true;
                }
                else
                    MessageBox.Show("ALL fields must be filled!");

            }
            if (TruckRdBtn.IsChecked == true)
            {
                if (Convert.ToDouble(EngineSizeTxtBox.Text) > maxEngineSizeHeavy || Convert.ToDouble(EngineSizeTxtBox.Text) < minEngineSizeHeavy)
                {
                    MessageBox.Show("Engine size MUST be between " + minEngineSizeHeavy + " L and " + maxEngineSizeHeavy + " L!");
                    EngineSizeTxtBox.Text = "";
                }

                if (!(NameTxtBox.Text == "" || MilageTxtBox.Text == "" || RegNumTxtBox.Text == "" || YearTxtBox.Text == "" || MinPriceTxtBox.Text == ""
                   || ClosingDateTxtBox.Text == "" || HeightTxtBox.Text == "" || LengthTxtBox.Text == "" || WeightTxtBox.Text == "" || EngineSizeTxtBox.Text == ""
                   || LoadCapacityTxtBox.Text == ""))
                {
                    Truck truck = new Truck(NameTxtBox.Text, Convert.ToDouble(MilageTxtBox.Text), RegNumTxtBox.Text, Convert.ToUInt16(YearTxtBox.Text), Convert.ToDecimal(MinPriceTxtBox.Text), hasTowBar,
                        Convert.ToDouble(EngineSizeTxtBox.Text), 0, fuelType, new HeavyVehicle.VehicleDimensionsStruct(Convert.ToDouble(HeightTxtBox.Text), Convert.ToDouble(WeightTxtBox.Text), Convert.ToDouble(LengthTxtBox.Text)),
                        Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, Convert.ToDouble(LoadCapacityTxtBox.Text));
                    database.DatabaseCreate(truck);
                    List<Truck> trucks = database.DatabaseGet(truck);
                    truck = trucks[trucks.Count - 1];
                    Auction newAuction = new Auction(truck, User, truck.NewPrice, Convert.ToDateTime(ClosingDateTxtBox.Text));
                    newAuction.Seller.UserName = User.UserName;
                    database.DatabaseCreate(newAuction);
                    MessageBox.Show("Auction created");
                    SUCCES = true;
                }
                else
                    MessageBox.Show("ALL fields must be filled!");
            }
            if (BusRdBtn.IsChecked == true)
            {
                if (Convert.ToDouble(EngineSizeTxtBox.Text) > maxEngineSizeHeavy || Convert.ToDouble(EngineSizeTxtBox.Text) < minEngineSizeHeavy)
                {
                    MessageBox.Show("Engine size MUST be between " + minEngineSizeHeavy + " L and " + maxEngineSizeHeavy + " L!");
                    EngineSizeTxtBox.Text = "";
                }

                if (!(NameTxtBox.Text == "" || MilageTxtBox.Text == "" || RegNumTxtBox.Text == "" || YearTxtBox.Text == "" || MinPriceTxtBox.Text == ""
                   || ClosingDateTxtBox.Text == "" || HeightTxtBox.Text == "" || LengthTxtBox.Text == "" || WeightTxtBox.Text == "" || EngineSizeTxtBox.Text == ""
                   || NumberOfSeatsTxtBox.Text == "" || NumberOfSleepingSpacesTxtbox.Text == ""))
                {
                    Bus bus = new Bus(NameTxtBox.Text, Convert.ToDouble(MilageTxtBox.Text), RegNumTxtBox.Text, Convert.ToUInt16(YearTxtBox.Text), Convert.ToDecimal(MinPriceTxtBox.Text),
                        hasTowBar, Convert.ToDouble(EngineSizeTxtBox.Text), 0, fuelType, new HeavyVehicle.VehicleDimensionsStruct(Convert.ToDouble(HeightTxtBox.Text), Convert.ToDouble(WeightTxtBox.Text), Convert.ToDouble(LengthTxtBox.Text)),
                        Convert.ToUInt16(NumberOfSeatsTxtBox.Text), Convert.ToUInt16(NumberOfSleepingSpacesTxtbox.Text), Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, hasToilet);
                    database.DatabaseCreate(bus);
                    List<Bus> buses = database.DatabaseGet(bus);
                    bus = buses[buses.Count - 1];
                    Auction newAuction = new Auction(bus, User, bus.NewPrice, Convert.ToDateTime(ClosingDateTxtBox.Text));
                    newAuction.Seller.UserName = User.UserName;
                    database.DatabaseCreate(newAuction);
                    MessageBox.Show("Auction created");
                    SUCCES = true;
                }
                else
                    MessageBox.Show("ALL fields must be filled!");
            }
            if (SUCCES)
            {
                Auctions = database.DatabaseGet(Auction);
                this.Close();
                MyAuctions = database.DatabaseGetForUser(Auction, User);
                Auctions = database.DatabaseGet(Auction);
                //MainWindow mainWindow = new MainWindow(User,Auctions, MyAuctions);
                MainWindow mainWindow = new MainWindow(User);
                mainWindow.Show();
            }

        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "," && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void EngineSizeTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (EngineSizeTxtBox.Text.Contains(","))
            {
                string[] strs = EngineSizeTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                EngineSizeTxtBox.Text = num + "," + dec;
            }
        }

        private void MilageTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (MilageTxtBox.Text.Contains(","))
            {
                string[] strs = MilageTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                MilageTxtBox.Text = num + "," + dec;
            }
        }

        private void MinPriceTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (MinPriceTxtBox.Text.Contains(","))
            {
                string[] strs = MinPriceTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                MinPriceTxtBox.Text = num + "," + dec;
            }
        }

        private void TrunkHeightTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (TrunkHeightTxtBox.Text.Contains(","))
            {
                string[] strs = TrunkHeightTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                TrunkHeightTxtBox.Text = num + "," + dec;
            }
        }

        private void TrunkWidthTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (TrunkWidthTxtBox.Text.Contains(","))
            {
                string[] strs = TrunkWidthTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                TrunkWidthTxtBox.Text = num + "," + dec;
            }
        }

        private void TrunkDepthTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (TrunkDepthTxtBox.Text.Contains(","))
            {
                string[] strs = TrunkDepthTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                TrunkDepthTxtBox.Text = num + "," + dec;
            }
        }

        private void HeightTextBox_TextChange(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (HeightTxtBox.Text.Contains(","))
            {
                string[] strs = HeightTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                HeightTxtBox.Text = num + "," + dec;
            }
        }

        private void WeightTextBox_TextChange(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (WeightTxtBox.Text.Contains(","))
            {
                string[] strs = WeightTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                WeightTxtBox.Text = num + "," + dec;
            }
        }

        private void LengthTextBox_TextChange(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (LengthTxtBox.Text.Contains(","))
            {
                string[] strs = LengthTxtBox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                LengthTxtBox.Text = num + "," + dec;
            }
        }

        private void KmLTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string num = "";
            string dec = "";

            if (KmLTextbox.Text.Contains(","))
            {
                string[] strs = KmLTextbox.Text.Split(",");
                num = strs[0];
                char[] chars = new char[2];
                int count = 0;
                do
                {
                    chars = strs[1].ToCharArray();

                    count++;
                } while (count < 2);
                if (chars.Length == 0)
                {

                }
                else if (chars.Length < 2)
                    dec = chars[0].ToString();
                else
                    dec = chars[0].ToString() + chars[1].ToString();

                KmLTextbox.Text = num + "," + dec;
            }
        }
    }
}
