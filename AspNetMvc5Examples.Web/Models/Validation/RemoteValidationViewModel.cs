namespace AspNetMvc5Examples.Web.Models
{
    using System.Web.Mvc;

    public class RemoteValidationViewModel
    {
        [Remote("ValidateRemoteAttribute", "RemoteValidation")]
        public string RemoteAttribute { get; set; }
    }
}