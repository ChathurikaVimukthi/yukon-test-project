using Microsoft.EntityFrameworkCore;
using YukonTest.Models;

namespace YukonTest.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<PeriodByDay> PeriodByDays { get; set; }
        public DbSet<Absent> Absents { get; set; }
    }
}