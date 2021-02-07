using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Validation
{
    public class IsEndDateLessThanStartDate : ValidationAttribute
    {
        public string otherPropertyName;
        public IsEndDateLessThanStartDate() { }
        public IsEndDateLessThanStartDate(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(this.otherPropertyName);
            DateTime toValidate = (DateTime)value;
            DateTime referenceProperty = (DateTime)field.GetValue(validationContext.ObjectInstance, null);
             if (toValidate.CompareTo(referenceProperty) < 1)
            {
                validationResult = new ValidationResult(ErrorMessageString);
            }
            return validationResult;
        }  

    }
}
