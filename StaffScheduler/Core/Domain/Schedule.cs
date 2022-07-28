namespace StaffScheduler.Core.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public double DurationInHours { get; set; }

        public Schedule(int id, DateTime startsOn, DateTime endsOn)
        {
            Id = id;
            StartsOn = startsOn;
            EndsOn = endsOn;
            DurationInHours = (endsOn - startsOn).TotalHours;
        }

        public Schedule(DateTime startsOn, double durationInHours)
        {
            StartsOn = startsOn;
            DurationInHours = durationInHours;
            EndsOn = startsOn.AddHours(durationInHours);
        }

        public Schedule(int id, DateTime startsOn, double durationInHours)
        {
            Id = id;
            StartsOn = startsOn;
            DurationInHours = durationInHours;
            EndsOn = startsOn.AddHours(durationInHours);
        }

    }
}
