using System;
using System.Linq;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinForms_LocationAware.Models;
using XamarinForms_LocationAware.Services.DataSource.SavedLocations;

namespace XamarinForms_LocationAware.ViewModels
{
    public class LocationInfoPageViewModel : BaseViewModel
    {
        private LocationModel _location = new LocationModel();
        public LocationModel Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }

        public string LatitudeDisplay { get { return "Latitude: " + _location.Latitude; } }
        public string LongitudeDisplay { get { return "Longitude: " + _location.Longitude; } }
        public bool EditMode { get { return !String.IsNullOrEmpty(_location.Name); } }

        public ICommand CloseModalCommand => new Command(() =>
        {
            // Close the current modal window
            PopupNavigation.Instance.PopAsync();
        });

        public LocationInfoPageViewModel()
        {
            //Adds a new location information object
        }
    }
}
