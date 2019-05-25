using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinForms_LocationAware.Models;


namespace XamarinForms_LocationAware.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IList<LocationModel> _storedLocations;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
