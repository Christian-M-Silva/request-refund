using MediatR;
using RequestRefund.Models.Commands;
using RequestRefund.Models.Entities;

namespace RequestRefund.Handlers
{
    public class RefundDtoCommandHandle(MyDbContext context) : IRequestHandler<RefundDtoCommand>
    {
        private readonly MyDbContext _context = context;

        public async Task Handle(RefundDtoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                RequestRefundEntity requestRefund = new()
                {
                    EmployeeId = request.EmployeeId,
                    Value = request.Value,
                    Description = request.Description,
                    Category = request.Category,
                    RequestDate = request.RequestDate,
                };
                await _context.Requests.AddAsync(requestRefund, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
