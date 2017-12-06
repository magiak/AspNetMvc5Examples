using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.ActionResults
{
    public class DummyViewEngineActionResult : ActionResult
    {
        public object Model { get; set; }

        private readonly string[] viewLocationFormats =
        {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
        };

        public override void ExecuteResult(ControllerContext context)
        {
            var filePath = this.FindView(context);
            var fileContent = System.IO.File.ReadAllText(filePath);

            var properties = this.Model.GetType().GetProperties();
            foreach(var property in properties)
            {
                fileContent = fileContent.Replace($"@Model.{property.Name}", property.GetValue(this.Model).ToString());
            }

            context.HttpContext.Response.Write(fileContent); // context.HttpContext.Response.WriteFile(filePath);
        }

        private string FindView(ControllerContext context)
        {
            var controllerName = context.RouteData.GetRequiredString("controller");
            var actionName = context.RouteData.GetRequiredString("action");

            var filePath = context.HttpContext.Server.MapPath(string.Format(this.viewLocationFormats[0], actionName, controllerName));
            return filePath; // TODO: Nejdrive zkontroluj zda soubor existuje
        }
    }
}