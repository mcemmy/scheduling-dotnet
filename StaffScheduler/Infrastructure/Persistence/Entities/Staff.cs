using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffScheduler.Infrastructure.Persistence.Entities
{
    public class StaffEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime JoinedOn { get; set; }
        
        public IdentityUser User { get; set; }
        public List<ScheduleEntity> Schedules { get; set; }

        public StaffEntity()
        {
            User = new IdentityUser();
            Schedules = new List<ScheduleEntity>();
        }
        
    }
}
