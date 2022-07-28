using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffScheduler.Infrastructure.Persistence.Entities;

namespace StaffScheduler.Infrastructure.Persistence
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

      
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<ScheduleEntity> Schedules { get; set; }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
        }
    }
}
