using System;
using System.Linq;
using XamarinForms_LocationAware.Models;
using XamarinForms_LocationAware.Services.DataSource.SavedLocations;

namespace XamarinForms_LocationAware.ViewModels
{
    public class LocationInfoPageViewModel : BaseViewModel
    {
        private LocationModel _location = new LocationModel();
        public LocationModel Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }

        public LocationInfoPageViewModel()
        {
            //Adds a new location information object
        }
    }
}
