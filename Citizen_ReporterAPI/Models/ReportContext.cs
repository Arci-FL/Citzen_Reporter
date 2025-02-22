using Microsoft.EntityFrameworkCore;

namespace Citizen_ReporterAPI.Models
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
        : base(options)
        {
        }

        public DbSet<ReportItem> ReportItems { get; set; } = null!;
    }
}
