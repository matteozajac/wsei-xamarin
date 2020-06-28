using System;
using Newtonsoft.Json;
using SQLite;

namespace AirMonitor.Models.Tables
{
    public class InstallationEntity
    {
        public InstallationEntity()
        {
        }

        public InstallationEntity(Installation installation)
        {
            if (installation == null) return;

            Id = installation.Id;
            LocationString = JsonConvert.SerializeObject(installation.Location);
            AddressString = JsonConvert.SerializeObject(installation.Address);
            Elevation = installation.Elevation;
            IsAirlyInstallation = installation.IsAirlyInstallation;
        }

        [PrimaryKey]
        public string Id { get; set; }
        public string LocationString { get; set; }
        public string AddressString { get; set; }
        public double Elevation { get; set; }
        public bool IsAirlyInstallation { get; set; }
    }
}
