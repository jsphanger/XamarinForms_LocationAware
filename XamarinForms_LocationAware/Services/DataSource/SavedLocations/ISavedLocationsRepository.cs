using System;
using System.Collections.Generic;
using XamarinForms_LocationAware.Models;

namespace XamarinForms_LocationAware.Services.DataSource.SavedLocations
{
    public interface ISavedLocationsRepository
    {
        IList<LocationModel> GetSavedLocations();
        void SaveLocation(LocationModel model);
    }
}
