namespace AspNetMvc5Examples.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Enums;

    public class EditorAndDisplayTemplatesViewModel
    {
        public decimal Price { get; set; }

        public Genres Genre { get; set; }

        public int Month { get; set; }

        public List<SelectListItem> MonthItems { get; set; }

        [UIHint("Months")]
        public int Month2 { get; set; }
    }
}