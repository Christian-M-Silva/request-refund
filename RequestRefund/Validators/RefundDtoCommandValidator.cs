using FluentValidation;
using RequestRefund.Models.Commands;
using RequestRefund.Models.Enuns;

namespace RequestRefund.Validators
{
    public class RefundDtoCommandValidator: AbstractValidator<RefundDtoCommand>
    {
        private readonly string _requiredMessage = "Campo obrigatório";
        public RefundDtoCommandValidator()
        {
            RuleFor(refund => refund.EmployeeId).NotEmpty().WithMessage(_requiredMessage);

            RuleFor(refund => refund.Value)
                .NotEmpty().WithMessage(_requiredMessage)
                .GreaterThan(500).WithMessage("O valor do reembolso deve ser maior que R$ 500,00")
                .LessThan(5000).WithMessage("O valor do reembolso deve ser menor que R$ 5000,00");

            RuleFor(refund => refund.Description).NotEmpty().WithMessage(_requiredMessage).When(refund => refund.Category == CategoryEnum.Accommodation);

            RuleFor(refund => refund.Category)
                .IsInEnum().WithMessage("Categoria inválida")
                .NotEmpty().WithMessage(_requiredMessage);
        }
    }
}
