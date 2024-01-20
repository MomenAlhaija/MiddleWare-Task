using System.ComponentModel.DataAnnotations;

namespace ReviewSomeCoreTopic.Validation
{
    public class DateOfBirthValidation:ValidationAttribute
    {
        private int _minyear;
        private int _maxyear;
        public DateOfBirthValidation(int minyear,int maxyear)
        {
            _maxyear = maxyear;
            _minyear = minyear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
          if(value != null) {

                if ((int)value > _minyear && (int)value < _minyear)
                    return ValidationResult.Success;
                return new ValidationResult(ErrorMessage ?? $"the Age must netween {_minyear} and {_maxyear}");

          }
          return null;
        }
    }
}
