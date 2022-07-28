using StaffScheduler.Core.Domain;

namespace StaffScheduler.Core.Application.Interfaces
{
    public interface IStaffRepository
    {
        Task CreateAsync(Staff newStaff);
        Task UpdateAsync(Staff editedStaff);
        Task RemoveAsync(string userName);
        Task<Staff> GetAsync(string userName);
        Task<List<Staff>> GetAllAsync(int periodInMonths);

    }
}
