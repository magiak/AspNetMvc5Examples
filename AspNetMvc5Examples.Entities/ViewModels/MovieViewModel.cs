using System.ComponentModel.DataAnnotations;

namespace AspNetMvc5Examples.Entities.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
