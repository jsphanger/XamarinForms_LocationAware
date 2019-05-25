using System;
using System.Collections;
using System.Collections.Generic;
using XamarinForms_LocationAware.Models;

namespace XamarinForms_LocationAware.Services.DataSource.SavedLocations
{
    public class SavedLocationsRepository : ISavedLocationsRepository
    {
        public IList<LocationModel> GetSavedLocations()
        {
            return new List<LocationModel>
            {
                new LocationModel
                {
                    Latitude = 0.0,
                    Longitude = 0.0,
                    Name = "Pat's House"
                }
            };
        }

        public void SaveLocation(LocationModel model)
        {
            // fake save model
        }
    }
}
