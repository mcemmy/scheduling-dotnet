using System.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Domain.Extensions;

namespace StaffScheduler.Core.Domain
{
    public class Staff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn { get; set; }
        
        public IdentityUser User { get; set; }
        public List<Schedule> Schedules { get; set; }
        

        public Staff()
        {
            
        }
        public Staff(IdentityUser user, string firstName, string lastName)
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
        }

        public double AccumulatedHours()
        {
            return Schedules.Sum(sch => sch.DurationInHours);
        }
    }
}
