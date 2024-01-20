using System.ComponentModel.DataAnnotations;

namespace ReviewTheCore.Validation
{
    public class AgeValidate:ValidationAttribute
    {
        private int _minYear;
        private int _maxYear;
        public AgeValidate(int minyear,int maxyear)
        {
            _minYear = minyear;
            _maxYear = maxyear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((int)value > _minYear && (int)value < _maxYear) 
                    return ValidationResult.Success;
                return new ValidationResult(ErrorMessage ?? $"the Age must netween {_minYear} and {_maxYear}");
            }
            return null;
        }
    }
}
