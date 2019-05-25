using System;
using System.Collections.Generic;
using System.Windows.Input;

using Rg.Plugins.Popup.Services;

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
            PopupNavigation.Instance.PushAsync(new LocationInformation());
        });

        public ICommand CheckInCommand => new Command(() =>
        {
            // when user taps 'check in' button
        });

        public ICommand LocationTapCommand => new Command<ItemTappedEventArgs>((ItemTappedEventArgs args) =>
        {
            var loc = (LocationModel)args.Item;
            PopupNavigation.Instance.PushAsync(new LocationInformation(loc));
        });

        public MainPageViewModel()
        {
            _savedLocationRepository = new SavedLocationsRepository();
            StoredLocations = _savedLocationRepository.GetSavedLocations();
        }

    }
}
