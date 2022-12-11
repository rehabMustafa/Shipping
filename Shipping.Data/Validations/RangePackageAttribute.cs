using Shipping.Infra.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Infra.Validations
{
    public class RangePackageAttribute : ValidationAttribute
    {
        public RangePackageAttribute(string propertyName)
     : base("{0} must be in range 0 and {1}")
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }
        public int MaxValue { get; set; }

        public string FormatErrorMessage(string name, int maxValue)
        {
            return string.Format(ErrorMessageString, name, maxValue);
        }

        protected override ValidationResult
            IsValid(object firstValue, ValidationContext validationContext)
        {
            var measurementType =
          Convert.ToUInt32(
              validationContext.ObjectInstance
                  .GetType()
                  .GetProperty(PropertyName)
                  .GetValue(validationContext.ObjectInstance)
              );
            switch ((Enums.MeasurementType)measurementType)
            {
                case Enums.MeasurementType.Metric:
                    MaxValue = 150;
                    break;
                case Enums.MeasurementType.Imperial:
                    MaxValue = 60;
                    break;
                default:
                    break;
            }

            if ((int)firstValue <= 0 || (int)firstValue > MaxValue)
            {
                return new ValidationResult(
                            FormatErrorMessage(validationContext.DisplayName, MaxValue));
            }
            return ValidationResult.Success;
        }
    }
}
