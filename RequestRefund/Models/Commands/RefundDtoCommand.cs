using MediatR;
using RequestRefund.Models.Bases;

namespace RequestRefund.Models.Commands
{
    public class RefundDtoCommand: RequestRefundBase, IRequest
    {
    }
}
