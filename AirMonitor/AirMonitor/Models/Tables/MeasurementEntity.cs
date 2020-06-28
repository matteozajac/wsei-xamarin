using System;
using Newtonsoft.Json;
using SQLite;

namespace AirMonitor.Models.Tables
{
    public class MeasurementEntity
    {
        public MeasurementEntity()
        {
        }

        public MeasurementEntity(int currentMeasurementItemId, string installationId)
        {
            CurrentMeasurementItemId = currentMeasurementItemId;
            InstallationId = installationId;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CurrentMeasurementItemId { get; set; }
        public string InstallationId { get; set; }
    }
}
