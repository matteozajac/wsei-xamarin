using System;
using AirMonitor.Models.Tables;

namespace AirMonitor.Models
{
    public class MeasurementItem
    {
        public MeasurementItem()
        {
        }

        public MeasurementItem(MeasurementItemEntity entity, MeasurementValue[] values, AirQualityIndex[] indexes, AirQualityStandard[] standards)
        {
            FromDateTime = entity.FromDateTime;
            TillDateTime = entity.TillDateTime;
            Values = values;
            Indexes = indexes;
            Standards = standards;
        }

        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public MeasurementValue[] Values { get; set; }
        public AirQualityIndex[] Indexes { get; set; }
        public AirQualityStandard[] Standards { get; set; }
    }
}
