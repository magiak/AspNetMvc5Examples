using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc5Examples.Entities.Models
{
    public class XmlModel
    {
        public string Name { get; set; }
        public XmlChildModel Child { get; set; }
    }

    public class XmlChildModel
    {
        public string ChildName { get; set; }
    }
}
