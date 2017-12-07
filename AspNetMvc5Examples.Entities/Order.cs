namespace AspNetMvc5Examples.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Net.NetworkInformation;

    public class Order
    {
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }
    }
}
