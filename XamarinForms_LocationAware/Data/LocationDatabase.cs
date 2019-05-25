using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamarinForms_LocationAware.Models;

namespace XamarinForms_LocationAware.Data
{
    public class LocationDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocationDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<LocationModel>().Wait();
        }

        public async Task<List<LocationModel>> GetLocationsAsync()
        {
            return await database.Table<LocationModel>().ToListAsync();
        }

        public async Task<LocationModel> GetLocationAsync(Guid id)
        {
            return await database.Table<LocationModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveLocationAsync(LocationModel location)
        {
            var loc = await GetLocationAsync(location.Id);

            if(loc == null){
                return await database.InsertAsync(location);
            }
            else{
                return await database.UpdateAsync(location);
            }
        }

        public async Task<int> DeleteLocationAsync(LocationModel location)
        {
            return await database.DeleteAsync(location);
        }
    }
}
