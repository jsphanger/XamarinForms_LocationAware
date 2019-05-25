using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms_LocationAware.Models;
using XamarinForms_LocationAware.ViewModels;

namespace XamarinForms_LocationAware
{
    public partial class LocationInformation : Rg.Plugins.Popup.Pages.PopupPage
    {
        public LocationInformation()
        {
            InitializeComponent();
        }

        public LocationInformation(LocationModel lm)
        {
            InitializeComponent();
            BindingContext = new LocationInfoPageViewModel() { Location = lm };
        }
    }
}
