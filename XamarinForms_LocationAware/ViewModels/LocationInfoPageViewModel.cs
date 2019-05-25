using System;
using System.Linq;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinForms_LocationAware.Models;
namespace XamarinForms_LocationAware.ViewModels
{
    public class LocationInfoPageViewModel : BaseViewModel
    {
        private LocationModel _location = new LocationModel();
        public LocationModel Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }

        private string _errorMessage = string.Empty;
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public string LatitudeDisplay { get { return "Latitude: " + _location.Latitude.ToString("0.###"); } }
        public string LongitudeDisplay { get { return "Longitude: " + _location.Longitude.ToString("0.###"); } }
        public bool EditMode { get { return !String.IsNullOrEmpty(_location.Name); } }

        public ICommand CloseModalCommand => new Command(() =>
        {
            // Close the current modal window
            PopupNavigation.Instance.PopAsync();
        });

        public ICommand SaveLocationCommand => new Command(async () =>
        {
            // Save the current location into our favorites
            if (!String.IsNullOrEmpty(Location.Name))
            {
                //save our location
                if(Location.Id == Guid.Empty){
                    Location.Id = Guid.NewGuid();
                }

                await App.Database.SaveLocationAsync(Location);
                
                //close the modal
                await PopupNavigation.Instance.PopAsync();

                Application.Current.MainPage = new MainPage();
            }
            else
            {
                ErrorMessage = "* Name is required.";
            }
        });

        public ICommand RemoveLocationCommand => new Command(async () =>
        {
            // Remove the current location from our favorites
            await App.Database.DeleteLocationAsync(Location);

            //close the modal
            await PopupNavigation.Instance.PopAsync();

            Application.Current.MainPage = new MainPage();
        });

        public LocationInfoPageViewModel()
        {
            //Adds a new location information object
        }
    }
}
