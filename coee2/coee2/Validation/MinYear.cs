using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace coee2.Validation
{
    public class MinYear:ValidationAttribute
    {
        private int _oldYear;
        private int _lastYear;

        public MinYear(int OldYear,int LastYear)
        {
            _oldYear = OldYear;
            _lastYear = LastYear;
        }
        protected override ValidationResult? IsValid(object? value,ValidationContext validationContext)
        {
           
            if(value is not null) 
            {
              DateTime date = (DateTime)value;
               if (date.Year >= _oldYear &&  date.Year <=_lastYear)
                    return ValidationResult.Success;
               return new ValidationResult(ErrorMessage??$"Must Year between {_oldYear} and {_lastYear}");
            }
            return null;
        }
    }
}
