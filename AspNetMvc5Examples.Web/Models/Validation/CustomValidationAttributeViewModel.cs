namespace AspNetMvc5Examples.Web.Models
{
    using Validations;

    public class CustomValidationAttributeViewModel
    {
        [GreaterThan(nameof(OtherProperty), ErrorMessage = "Property has to be greater than OtherProperty")]
        public int Property { get; set; }

        public int OtherProperty { get; set; }
    }
}