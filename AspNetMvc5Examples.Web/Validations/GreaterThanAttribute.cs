namespace AspNetMvc5Examples.Web.Validations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string otherPropertyName;

        public GreaterThanAttribute(string otherPropertyName)
            : base()
        {
            this.otherPropertyName = otherPropertyName;
        }

        // 1. option
        //public override bool IsValid(object value)
        //{
        //    return false;
        //}

        // 2. option
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                
            int toValidate = (int)value;
            int referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                    
            if (toValidate <= referenceProperty)
            {
                validationResult = new ValidationResult(this.ErrorMessageString);
            }

            return validationResult;
        }

        // Source code from https://thewayofcode.wordpress.com/tag/custom-unobtrusive-validation/
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.ErrorMessageString;

            var greaterThanRule = new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = "greaterthan" // This is the name the jQuery adapter will use
            };

            // "otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            greaterThanRule.ValidationParameters.Add("otherpropertyname", this.otherPropertyName);

            yield return greaterThanRule;
        }
    }
}