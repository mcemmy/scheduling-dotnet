using Azure;
using MediatR;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Schedule.RemoveSchedule
{
    public class RemoveScheduleUseCase : IRequestHandler<RemoveScheduleRequest, RemoveScheduleResponse>
    {
       
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;

        public RemoveScheduleUseCase(IScheduleRepository scheduleRepository, ILogger<RemoveScheduleUseCase>logger
        )
        {
            _scheduleRepository = scheduleRepository;
            _logger = logger;
        }
        public async Task<RemoveScheduleResponse> Handle(RemoveScheduleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _scheduleRepository.RemoveAsync(request.ScheduleId);

                return new RemoveScheduleResponse(Status.Accepted, Messages.Successful);
            }
            catch (RecordNotFoundException ex)
            {
                return new RemoveScheduleResponse(Status.NotFound, ex.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new RemoveScheduleResponse(Status.FatalError, ExceptionMessages.UnexpectedError);
            }

        }
    }
}
