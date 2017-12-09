namespace AspNetMvc5Examples.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    //[Bind(Exclude = nameof(Name))]
    public class ModelBinderViewModel
    {
        [MaxLength(10)]
        public string Name { get; set; }
        
        public ModelBinderChildViewModel Child { get; set; }
    }
}