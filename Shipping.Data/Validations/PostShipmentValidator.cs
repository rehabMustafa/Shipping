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

            RuleFor(x => x.Width)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEqual(0)
            .LessThan(150)
            .WithErrorCode("400");

            RuleFor(x => x.Height)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEqual(0)
           .LessThan(150)
           .WithErrorCode("400");

            RuleFor(x => x.Length)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEqual(0)
           .LessThan(150)
           .WithErrorCode("400");

            RuleFor(x => x.Weight)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEqual(0)
           .LessThan(150)
           .WithErrorCode("400");
        }
    }
}
