namespace AspNetMvc5Examples.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Validations;

    public class ValidationViewModel
    {
        [Required]
        public string Required { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string StringLength { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(1, 12)]
        public int Range { get; set; }

        [RegularExpression("\\D")]
        public string RegularExpression { get; set; }

        [Remote("ValidateRemoteAttribute", "RemoteValidation")]
        public string RemoteAttribute { get; set; }

        [GreaterThan(nameof(OtherProperty), "Property has to be greater than OtherProperty")]
        public int Property { get; set; }

        public int OtherProperty { get; set; }
    }
}