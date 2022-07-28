using MediatR;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Schedule.CreateSchedule
{
    public class CreateScheduleUseCase : IRequestHandler<CreateScheduleRequest, CreateScheduleResponse>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        public CreateScheduleUseCase(IScheduleRepository scheduleRepository, ILogger<CreateScheduleUseCase> logger)
        {
            _scheduleRepository = scheduleRepository;
            _logger = logger;
        }

        public async Task<CreateScheduleResponse> Handle(CreateScheduleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newSchedule = new Domain.Schedule(request.StartsFrom, request.DurationInHours);

                await _scheduleRepository.CreateAsync(newSchedule, request.Username);

                return new CreateScheduleResponse(Status.Created, Messages.Successful);

            }
            catch (RecordNotFoundException ex)
            {
                return new CreateScheduleResponse(Status.NotFound, ex.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new CreateScheduleResponse(Status.FatalError, ExceptionMessages.UnexpectedError);
            }
        }
    }
}
