using SQLite;

namespace AirMonitor.Models
{
    public class MeasurementValue
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
