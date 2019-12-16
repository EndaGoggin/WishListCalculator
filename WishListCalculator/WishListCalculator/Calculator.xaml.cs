using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace WishListCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
            Visible();
        }

        public static string TimeConverter(decimal Hours)
        {
            decimal hours = Math.Floor(Hours);
            decimal minutes = (Hours - hours) * 60.0M;
            int D = (int)Math.Floor(Hours / 24);
            int H = (int)Math.Floor(hours - (D * 24));
            int M = (int)Math.Floor(minutes);
            string timeFormat = String.Format("{0:00}:{1:00}:{2:00}", D, H, M);
            return timeFormat;
        }

        private void BtnCalculate_Clicked(object sender, EventArgs e)
        {
            try
            {           
                // Vibration
                var duration = TimeSpan.FromSeconds(0.1);
                Vibration.Vibrate(duration);
            }
            catch(Exception ex)
            {
                
            }
            // Variables
            String name = Name.Text;
            int price = int.Parse(Price.Text);
            float hourlyRate = float.Parse(HourlyRate.Text);
            float ans;

            // Calculation
            ans = price / hourlyRate;

            // Changing label to answer/Output
            Label label = sender as Label;
            RateAns.Text = "Time Work Nedded For Item\n dd/hh/mm: " + TimeConverter((decimal)ans);

            // Make button visible
            RateAns.Opacity = 1;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Vibration
                var duration = TimeSpan.FromSeconds(0.1);
                Vibration.Vibrate(duration);
            }
            catch (Exception ex)
            {

            }

            // Variables
            String name = Name.Text;
            int price = int.Parse(Price.Text);
            float hourlyRate = float.Parse(HourlyRate.Text);
            float ans;

            // Calculation
            ans = price / hourlyRate;

            // Local Storage
            if (Application.Current.Properties["Name1"] == "")
            {
                Application.Current.Properties["Name1"] = name;
                Application.Current.Properties["Time1"] = TimeConverter((decimal)ans);
            }
            else if (Application.Current.Properties["Name2"] == "")
            {
                Application.Current.Properties["Name2"] = name;
                Application.Current.Properties["Time2"] = TimeConverter((decimal)ans);
            }
            else if (Application.Current.Properties["Name3"] == "")
            {
                Application.Current.Properties["Name3"] = name;
                Application.Current.Properties["Time3"] = TimeConverter((decimal)ans);
            }
            else if (Application.Current.Properties["Name4"] == "")
            {
                Application.Current.Properties["Name4"] = name;
                Application.Current.Properties["Time4"] = TimeConverter((decimal)ans);
            }
            else if (Application.Current.Properties["Name5"] == "")
            {
                Application.Current.Properties["Name5"] = name;
                Application.Current.Properties["Time5"] = TimeConverter((decimal)ans);
            }
            Application.Current.SavePropertiesAsync();

            // Refresh after save
            var viewModel = BindingContext;
            BindingContext = null;
            InitializeComponent();
            BindingContext = viewModel;

            // Remove button on clear
            RateAns.Opacity = 0;
        }

        // Sets answer box to invisible 
        public void Visible()
        {
            RateAns.Opacity = 0;
        }
    }
}