using AspNetMvc5Examples.Business.ActionResults;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.Extensions
{
    public static class ControllerExtensions
    {
        public static XmlResult Xml(this Controller controller, object obj)
        {
            return new XmlResult(obj);
        }
    }
}
