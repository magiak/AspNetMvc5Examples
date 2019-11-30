﻿using System.Collections.Generic;

namespace AspNetMvc5Examples.Entities.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
