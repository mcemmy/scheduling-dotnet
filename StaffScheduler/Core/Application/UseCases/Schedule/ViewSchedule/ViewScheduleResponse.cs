using System.Text.Json.Serialization;

namespace StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule
{
    public class ViewScheduleResponse :BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserName { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Schedule> Schedules { get; set; }

        public ViewScheduleResponse(Status status, string userName, List<Schedule> schedules) : base(status)
        {
            UserName = userName;
            Schedules = schedules;
        }

        public ViewScheduleResponse(Status status, string message) :base(status, message)
        {
            
        }
        
    }

  public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime StartsFrom { get; set; }
        public DateTime EndsAt { get; set; }
        public double DurationInHours { get; set; }

        public Schedule(int scheduleId, DateTime startsFrom, DateTime endsAt, double durationInHours)
        {
            ScheduleId = scheduleId;    
            StartsFrom = startsFrom;
            EndsAt = endsAt;
            DurationInHours = durationInHours;
        }
    }
}
