using System;

using Xamarin.Forms;

namespace XamarinForms_LocationAware
{
    public class LocationInfoPage : ContentPage
    {
        public LocationInfoPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

