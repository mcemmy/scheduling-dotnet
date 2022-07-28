using Microsoft.Identity.Client;
using StaffScheduler.Core.Application.Interfaces;
using StaffScheduler.Infrastructure;

namespace StaffScheduler
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            return services;
        }

        
    }
}
