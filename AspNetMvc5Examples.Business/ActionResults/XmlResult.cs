using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.ActionResults
{
    public class XmlResult : ActionResult
    {
        public XmlResult(object obj)
        {
            this.objectToSerialize = obj;
        }

        public object objectToSerialize { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var objectType = this.objectToSerialize.GetType();
            var xs = new System.Xml.Serialization.XmlSerializer(objectType);
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "text/xml";
            xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
        }
    }
}
