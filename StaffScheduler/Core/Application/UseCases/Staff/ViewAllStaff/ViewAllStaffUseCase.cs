using MediatR;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewAllStaff
{
    public class ViewAllStaffUseCase : IRequestHandler<ViewAllStaffRequest, ViewAllStaffResponse>
    {
        private readonly IStaffRepository _staffRepository;

        public ViewAllStaffUseCase(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<ViewAllStaffResponse> Handle(ViewAllStaffRequest request, CancellationToken cancellationToken)
        {
            var records = await _staffRepository.GetAllAsync(request.PeriodInMonths);

            var result = new ViewAllStaffResponse(Status.Ok);

            foreach (var record in records)
            {
                result.Records.Add(new StaffRecord(record.FirstName, record.LastName, record.AccumulatedHours()));
            }

            result.Order();

            return result;
        }
    }
}
