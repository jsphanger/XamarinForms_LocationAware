using System;
namespace XamarinForms_LocationAware.Models
{
    public class LocationModel
    {
        [SQLite.PrimaryKey]
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }
}
