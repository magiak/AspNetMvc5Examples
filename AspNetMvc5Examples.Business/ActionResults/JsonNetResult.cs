using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.ActionResults
{
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
        }

        public JsonNetResult(JsonResult jsonResult)
        {
            this.ContentEncoding = jsonResult.ContentEncoding;
            this.ContentType = jsonResult.ContentType;
            this.Data = jsonResult.Data;
            this.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
            this.MaxJsonLength = jsonResult.MaxJsonLength;
            this.RecursionLimit = jsonResult.RecursionLimit;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented };
                JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings());
                serializer.Serialize(writer, this.Data);
                writer.Flush();
            }
        }
    }
}
