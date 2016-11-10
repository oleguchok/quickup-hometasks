using System.ComponentModel.DataAnnotations;

namespace FiltersWebApp.Core
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        private int _age;

        public AgeValidationAttribute(int age)
        {
            _age = age;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int x = (int)value;
            if (x < _age)
            {
                return new ValidationResult($"Your age must be grater than {_age}");
            }

            return ValidationResult.Success;
        }
    }
}
