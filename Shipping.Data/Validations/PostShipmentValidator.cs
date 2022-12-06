using FluentValidation;
using Shipping.Infra.Models;

namespace Shipping.Infra.Validations
{
    public class PostShipmentValidator : AbstractValidator<Shipment>
    {
        public PostShipmentValidator()
        {
            RuleFor(x => x.ServiceId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(0)
                .WithErrorCode("400");
        }
    }
}
