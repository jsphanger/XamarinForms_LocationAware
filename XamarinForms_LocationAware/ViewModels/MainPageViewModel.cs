using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinForms_LocationAware.Models;
using XamarinForms_LocationAware.Services.DataSource.SavedLocations;

namespace XamarinForms_LocationAware.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IList<LocationModel> _storedLocations;
        private ISavedLocationsRepository _savedLocationRepository;

        public IList<LocationModel> StoredLocations
        {
            get => _storedLocations;
            set { _storedLocations = value;  OnPropertyChanged(nameof(StoredLocations)); }
        }

        public ICommand AddLocationCommand => new Command(() =>
        {
            // when user taps 'add' button
            // prompt user to input a name
        });

        public ICommand CheckInCommand => new Command(() =>
        {
            // when user taps 'check in' button
        });

        public ICommand LocationTapCommand => new Command(() =>
        {
            // when the user taps a saved location
        });

        public MainPageViewModel()
        {
            _savedLocationRepository = new SavedLocationsRepository();
            StoredLocations = _savedLocationRepository.GetSavedLocations();
        }

    }
}
