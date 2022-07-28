using StaffScheduler.Core.Application.Interfaces;
using StaffScheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Domain;
using StaffScheduler.Core.Domain.Extensions;
using StaffScheduler.Infrastructure.Persistence.Entities;

namespace StaffScheduler.Infrastructure
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ScheduleRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Schedule>?> GetByUserNameAsync(string username, int periodInMonths)
        {
            //get the limit (in duration) of record to retrieve 
            var dateRange = DateTime.UtcNow.Within(periodInMonths); 

            var records = await _databaseContext.Staff
                 .Where(s => s.User.UserName.Equals(username))
                 .Select(sc => sc.Schedules.Where(m => m.EndsOn >= dateRange))
                 .SingleOrDefaultAsync();

            return records == null ? null : Get(records);
        }

        public async Task CreateAsync(Schedule schedule, string userName)
        {
            var staff = await _databaseContext.Staff.Where(s => s.User.UserName.Equals(userName))
                .SingleOrDefaultAsync();

            if (staff == null)
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

            staff.Schedules.Add(new ScheduleEntity
            {
                StartsOn = schedule.StartsOn,
                EndsOn = schedule.EndsOn,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow
            });

            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            var oldSchedule = await GetScheduleAsync(schedule.Id);

            oldSchedule.CreatedOn = schedule.StartsOn;
            oldSchedule.EndsOn = schedule.EndsOn;
            oldSchedule.ModifiedOn = DateTime.UtcNow;

            await _databaseContext.SaveChangesAsync();
        }
        
        public async Task RemoveAsync(int scheduleId)
        {
            var schedule = await GetScheduleAsync(scheduleId);

            _databaseContext.Schedules.Remove(schedule);

            await _databaseContext.SaveChangesAsync();
        }

        private async Task<ScheduleEntity> GetScheduleAsync(int scheduleId)
        {
            var schedule = await _databaseContext.Schedules
                .Where(sc => sc.Id.Equals(scheduleId))
                .SingleOrDefaultAsync();

            if (schedule == null)
                throw new RecordNotFoundException(ExceptionMessages.ScheduleRecordNotFound);

            return schedule;
        }

        private static List<Schedule>? Get(IEnumerable<ScheduleEntity> records)
        {
            List<Schedule>? schedules = new();

            schedules.AddRange(
                records.Select(schedule
                        => new Schedule(schedule.Id, schedule.StartsOn, schedule.EndsOn)));

            return schedules;

        }
    }
}
