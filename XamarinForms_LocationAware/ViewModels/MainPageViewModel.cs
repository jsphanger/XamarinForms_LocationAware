using System;
using System.Collections.Generic;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinForms_LocationAware.Models;

namespace XamarinForms_LocationAware.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IList<LocationModel> _storedLocations;
        public IList<LocationModel> StoredLocations
        {
            get => _storedLocations;
            set { _storedLocations = value;  OnPropertyChanged(nameof(StoredLocations)); }
        }

        public ICommand AddLocationCommand => new Command(async () =>
        {
            // when user taps 'add' button
            // prompt user to input a name
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location == null)
                {
                    var lastKnown = await Geolocation.GetLastKnownLocationAsync();
                    location = lastKnown == null ? new Location() { Latitude = 0, Longitude = 0 } : await Geolocation.GetLastKnownLocationAsync();
                }

                LocationModel loc = new LocationModel() { Latitude = location.Latitude, Longitude = location.Longitude };
                await PopupNavigation.Instance.PushAsync(new LocationInformation(loc));
            }
            catch(PermissionException)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not access the GPS location features.  Please enable permissions for this app in your device settings.", "OK");
            }
            catch(Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not retreive the location of this device at this time.", "OK");
            }

        });

        public ICommand CheckInCommand => new Command(async () =>
        {
            try 
            { 
                // when user taps 'check in' button check to see if we are near any of our saved locations
                LocationModel closestLocation = new LocationModel();
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location == null)
                {
                    var lastKnown = await Geolocation.GetLastKnownLocationAsync();
                    location = lastKnown == null ? new Location() { Latitude = 0, Longitude = 0 } : await Geolocation.GetLastKnownLocationAsync();
                }

                double bestMillage = 0.0;
                foreach(var local in StoredLocations)
                {
                    var localLoc = new Location() { Latitude = local.Latitude, Longitude = local.Longitude };
                    var miles = Location.CalculateDistance(location, localLoc, DistanceUnits.Miles);

                    if(miles < bestMillage || bestMillage == 0.0)
                    {
                        bestMillage = miles;
                        closestLocation = local;
                    }
                }

                //if you are within a quarter mile radius of any location it will check you in.
                if(StoredLocations.Count == 0){
                    await Application.Current.MainPage.DisplayAlert("Locations", "You are not within the check-in radius of any saved locations.  To record a new location press the target icon in the top right corner!", "OK");
                }
                else if(bestMillage >= 0.0 && bestMillage < 0.25){
                    await Application.Current.MainPage.DisplayAlert("Locations", String.Format("You are {0} miles from {1} and have been automatically checked in.", bestMillage.ToString("0.##"), closestLocation.Name ), "OK");
                }
                else{
                    //not near anything
                    await Application.Current.MainPage.DisplayAlert("Locations", "You are not within the check-in radius of any saved locations.", "OK");
                }
            }
            catch (PermissionException)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not access the GPS location features.  Please enable permissions for this app in your device settings.", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not retreive the location of this device at this time.", "OK");
            }
        });

        public ICommand LocationTapCommand => new Command<ItemTappedEventArgs>((ItemTappedEventArgs args) =>
        {
            var loc = (LocationModel)args.Item;
            PopupNavigation.Instance.PushAsync(new LocationInformation(loc));
        });

        public MainPageViewModel()
        {
            LoadLocations();
        }

        public async void LoadLocations()
        {
            StoredLocations = await App.Database.GetLocationsAsync();
        }
    }
}
