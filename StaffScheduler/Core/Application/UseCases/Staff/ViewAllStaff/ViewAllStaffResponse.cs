namespace StaffScheduler.Core.Application.UseCases.Staff.ViewAllStaff
{
    public class ViewAllStaffResponse :BaseResponse
    {
        public ViewAllStaffResponse(Status status, List<StaffRecord> records) : base(status)
        {
            Records = records;
           
        }

        public ViewAllStaffResponse(Status status, string message, List<StaffRecord> records) : base(status, message)
        {
            Records = records;
        }

        public ViewAllStaffResponse(Status status) : base(status)
        {
            
        }

        public List<StaffRecord> Records { get; set; }

        public void Order()
        {
            Records.OrderBy(s => s.AccumulatedHours);
        }
       
    }

    public class StaffRecord
    {
        public StaffRecord(string firstName, string lastName, double accumulatedHours)
        {
            FirstName = firstName;
            LastName = lastName;
            AccumulatedHours = accumulatedHours;
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double AccumulatedHours { get; set; }
    }
}
