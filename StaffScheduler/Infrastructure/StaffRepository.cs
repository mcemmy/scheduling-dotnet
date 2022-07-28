using Microsoft.EntityFrameworkCore;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;
using StaffScheduler.Core.Domain;
using StaffScheduler.Core.Domain.Extensions;
using StaffScheduler.Infrastructure.Persistence;
using StaffScheduler.Infrastructure.Persistence.Entities;

namespace StaffScheduler.Infrastructure
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StaffRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateAsync(Staff newStaff)
        {
            var staffEntity = new StaffEntity
            {
                FirstName = newStaff.FirstName,
                LastName = newStaff.LastName,
                JoinedOn = DateTime.UtcNow,
                User = newStaff.User
            };

            await _databaseContext.Staff.AddAsync(staffEntity);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Staff editedStaff)
        {
            var staff = await GetByUserNameAsync(editedStaff.User.UserName);

            staff.FirstName = editedStaff.FirstName;
            staff.LastName = editedStaff.LastName;

            await _databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(string userName)
        {
            var staff = await GetByUserNameAsync(userName);

            _databaseContext.Staff.Remove(staff);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<List<Staff>> GetAllAsync(int periodInMonths)
        {
            var withinDate = DateTime.UtcNow.Within(periodInMonths);
            
            var records = await _databaseContext.Staff
                .Where(s =>s.Schedules.Exists(sc => sc.EndsOn >= withinDate))
                .ToListAsync();

            if (!records.Any())
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);
            
            return records.Select(ConvertToDomain).ToList();
        }

        public async Task<Staff> GetAsync(string userName)
        {
            var staffEntity = await GetByUserNameAsync(userName);
            if (staffEntity == null)
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

            return ConvertToDomain(staffEntity);

        }

        private static Staff ConvertToDomain(StaffEntity staffEntity)
        {
            var staff = new Staff
            {
                FirstName = staffEntity.FirstName ?? string.Empty,
                LastName = staffEntity.LastName ?? string.Empty,
                JoinedOn = staffEntity.JoinedOn,
                User = staffEntity.User
            };
            
            if (staffEntity.Schedules?.Count > 0)
            {
                staff.Schedules = staffEntity.Schedules.AsEnumerable()
                    .Select(sc => new Schedule(sc.Id, sc.StartsOn, sc.EndsOn))
                    .ToList();
            }

            return staff;
        }

        private async Task<StaffEntity> GetByUserNameAsync(string userName)
        {
           var staff = await _databaseContext.Staff
                .SingleOrDefaultAsync(s => s.User.UserName.Equals(userName));

            if (staff == null)
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

            return staff;
        }
    }
}
