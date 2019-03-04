using AspNetMvc5Examples.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc5Examples.Entities.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime ReleasedDate { get; set; }
        public decimal Price { get; set; }
    }
}
