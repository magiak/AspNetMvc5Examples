namespace AspNetMvc5Examples.Entities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
