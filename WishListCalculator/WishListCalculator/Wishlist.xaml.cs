using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WishListCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wishlist : ContentPage
    {
        public Wishlist()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            // Initial setup
            Application.Current.Properties["Name1"] = "";
            Application.Current.Properties["Time1"] = "";
            Application.Current.Properties["Name2"] = "";
            Application.Current.Properties["Time2"] = "";
            Application.Current.Properties["Name3"] = "";
            Application.Current.Properties["Time3"] = "";
            Application.Current.Properties["Name4"] = "";
            Application.Current.Properties["Time4"] = "";
            Application.Current.Properties["Name5"] = "";
            Application.Current.Properties["Time5"] = "";
        }

        private void BtnRefresh_Clicked(object sender, EventArgs e)
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

            // Refresh
            var viewModel = BindingContext;
            BindingContext = null;
            InitializeComponent();
            BindingContext = viewModel;

            // Assign saved to wishlist
            Name1.Text = Application.Current.Properties["Name1"].ToString();
            Price1.Text = Application.Current.Properties["Time1"].ToString();
            Name2.Text = Application.Current.Properties["Name2"].ToString();
            Price2.Text = Application.Current.Properties["Time2"].ToString();
            Name3.Text = Application.Current.Properties["Name3"].ToString();
            Price3.Text = Application.Current.Properties["Time3"].ToString();
            Name4.Text = Application.Current.Properties["Name4"].ToString();
            Price4.Text = Application.Current.Properties["Time4"].ToString();
            Name5.Text = Application.Current.Properties["Name5"].ToString();
            Price5.Text = Application.Current.Properties["Time5"].ToString();
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
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

            // Reset Local Storage
            Application.Current.Properties["Name1"] = "";
            Application.Current.Properties["Time1"] = "";
            Application.Current.Properties["Name2"] = "";
            Application.Current.Properties["Time2"] = "";
            Application.Current.Properties["Name3"] = "";
            Application.Current.Properties["Time3"] = "";
            Application.Current.Properties["Name4"] = "";
            Application.Current.Properties["Time4"] = "";
            Application.Current.Properties["Name5"] = "";
            Application.Current.Properties["Time5"] = "";

            // Refresh
            var viewModel = BindingContext;
            BindingContext = null;
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}