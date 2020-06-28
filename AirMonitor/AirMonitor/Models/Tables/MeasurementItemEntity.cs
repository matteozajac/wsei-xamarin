using System;
using System.Linq;
using Newtonsoft.Json;
using SQLite;

namespace AirMonitor.Models.Tables
{
    public class MeasurementItemEntity
    {
        public MeasurementItemEntity()
        {
        }

        public MeasurementItemEntity(MeasurementItem measurementItem)
        {
            if (measurementItem == null) return;

            FromDateTime = measurementItem.FromDateTime;
            TillDateTime = measurementItem.TillDateTime;

            MeasurementValueIds = JsonConvert.SerializeObject(measurementItem.Values?.Select(s => s.Id));
            AirQualityIndexIds = JsonConvert.SerializeObject(measurementItem.Indexes?.Select(s => s.Id));
            AirQualityStandardIds = JsonConvert.SerializeObject(measurementItem.Standards?.Select(s => s.Id));
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public string MeasurementValueIds { get; set; }
        public string AirQualityIndexIds { get; set; }
        public string AirQualityStandardIds { get; set; }
    }
}
