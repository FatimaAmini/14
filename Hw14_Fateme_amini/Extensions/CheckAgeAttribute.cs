﻿using System.ComponentModel.DataAnnotations;

namespace Hw14_Fateme_amini.Extensions
{
    public class UserDateOfBirthValidation : ValidationAttribute
    {
        public const string MINIMUM_DATE_OF_BIRTH =
        "The User age must be greater or equal to 18 years";
        private int MINIMUM_AGE = 18;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valueString = value != null ? value.ToString() : null;

            if (string.IsNullOrWhiteSpace(valueString))
            {
                return ValidationResult.Success;
            }

            if (!DateTime.TryParse(valueString, out DateTime dob))
            {
                return new ValidationResult("Please provide the date of birth in a valid format");
        
    }

            var minDateOfBirth = DateTime.Now.Date.AddYears(MINIMUM_AGE * -1);

            if (dob > minDateOfBirth)
            {
                return new ValidationResult(MINIMUM_DATE_OF_BIRTH);
            }

            return ValidationResult.Success;
        }
    }
}
