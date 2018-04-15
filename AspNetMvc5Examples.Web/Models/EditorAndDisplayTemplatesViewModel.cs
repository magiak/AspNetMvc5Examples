namespace AspNetMvc5Examples.Web.Models
{
    using AspNetMvc5Examples.Entities.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class EditorAndDisplayTemplatesViewModel
    {
        public decimal Price { get; set; }

        public Genre Genre { get; set; }

        public int Month { get; set; }

        public List<SelectListItem> MonthItems { get; set; }

        [UIHint("Months")]
        public int Month2 { get; set; }
    }
}