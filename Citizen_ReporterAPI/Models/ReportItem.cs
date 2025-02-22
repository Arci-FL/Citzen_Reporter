namespace Citizen_ReporterAPI.Models
{
    public class ReportItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string MoreDeets { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Description { get; set; }
        public DateTime Timestamp = DateTime.Now;
    }
}
