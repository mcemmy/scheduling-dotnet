using StaffScheduler.Core.Domain;

namespace StaffScheduler.Core.Application.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>?> GetByUserNameAsync(string username, int withPeriodInMonths);
        Task CreateAsync(Schedule schedule, string userName);
        Task UpdateAsync(Schedule schedule);
        Task RemoveAsync(int scheduleId);
    }
}
