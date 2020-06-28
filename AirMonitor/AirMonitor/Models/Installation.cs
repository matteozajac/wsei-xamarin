using System;
using AirMonitor.Models.Tables;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace AirMonitor.Models
{
    public class Installation
    {
        public Installation(InstallationEntity installationEntity)
        {
            if (installationEntity == null) return;

            Id = installationEntity.Id;
            Location = JsonConvert.DeserializeObject<Location>(installationEntity.LocationString);
            Address = JsonConvert.DeserializeObject<Address>(installationEntity.AddressString);
            Elevation = installationEntity.Elevation;
            IsAirlyInstallation = installationEntity.IsAirlyInstallation;
        }

        public string Id { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
        public double Elevation { get; set; }
        [JsonProperty(PropertyName = "airly")]
        public bool IsAirlyInstallation { get; set; }
    }
}
