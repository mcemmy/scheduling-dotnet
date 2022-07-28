using System.Text.Json.Serialization;

namespace StaffScheduler.Core.Application.UseCases
{
    public class BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
        
        [JsonIgnore]
        public Status Status { get; set; }

        public BaseResponse(Status status)
        {
            Status = status;
        }

        public BaseResponse(Status status, string message)
        {
            Status = status;
            Message = message;
        }


    }

    public enum Status
    {
        Ok, Created, Accepted, FatalError, NotFound, BadRequest
    }
    

}
