using AirMonitor.Models.Tables;

namespace AirMonitor.Models
{
    public class Measurement
    {
        public Measurement()
        {
        }

        public Measurement(MeasurementItem measurementItem, Installation installation)
        {
            Current = measurementItem;
            Installation = installation;
        }

        public int CurrentDisplayValue { get; set; }
        public MeasurementItem Current { get; set; }
        public MeasurementItem[] History { get; set; }
        public MeasurementItem[] Forecast { get; set; }
        public Installation Installation { get; set; }
    }
}
