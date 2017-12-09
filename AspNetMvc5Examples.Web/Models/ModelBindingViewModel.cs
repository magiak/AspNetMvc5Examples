namespace AspNetMvc5Examples.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    //[Bind(Exclude = nameof(Name))]
    public class ModelBindingViewModel
    {
        [MaxLength(10)]
        public string Name { get; set; }
        
        public ModelBindingChildViewModel Child { get; set; }
    }
}