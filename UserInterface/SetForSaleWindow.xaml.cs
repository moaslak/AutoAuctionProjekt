using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for SetForSaleWindow.xaml
    /// </summary>
    public partial class SetForSaleWindow : Window
    {
        public SetForSaleWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            PrivatePersonalCarRdBtn.IsChecked = true;
            this.MainWindow = mainWindow;
        }

        MainWindow MainWindow { get; set; }

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
            TrunkDepthTxtBox.Visibility= Visibility.Visible;
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
            if(ProfefssionalPersonalCarRdBtn.IsChecked == true)
            {
                PrivatePersonalCarRdBtn.IsChecked = false;
                TruckRdBtn.IsChecked = false;
                BusRdBtn.IsChecked = false;
            }
            ProffessionalCarSelected();
        }

        private void TruckRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(TruckRdBtn.IsChecked == true)
            {
                PrivatePersonalCarRdBtn.IsChecked = false;
                ProfefssionalPersonalCarRdBtn.IsChecked = false;
                BusRdBtn.IsChecked = false;
            }
            TruckSelected();
        }

        private void BusRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(BusRdBtn.IsChecked == true)
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
            MainWindow.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
