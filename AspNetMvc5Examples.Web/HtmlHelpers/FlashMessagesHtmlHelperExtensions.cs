namespace AspNetMvc5Examples.Web.HtmlHelpers
{
    using System.Text;
    using System.Web.Mvc;
    using AspNetMvcExamples.Business.FlashMessages;
    using System.Web.Mvc.Html; // actionlink, ...

    public static class FlashMessagesHtmlHelperExtensions
    {
        // https://getbootstrap.com/docs/3.3/components/#alerts
        public static MvcHtmlString FlashMessages(this HtmlHelper htmlHelper, bool dismissible = false)
        {
            var stringBuilder = new StringBuilder();
            var alerts = htmlHelper.ViewContext.TempData.GetAllAlerts();
            foreach (Alert alert in alerts)
            {
                var tagBuilder = new TagBuilder("div");
                tagBuilder.MergeAttribute("role", "alert");
                tagBuilder.AddCssClass("alert");
                tagBuilder.AddCssClass($"alert-{alert.AllertType.ToString().ToLower()}");

                if (dismissible)
                {
                    tagBuilder.AddCssClass("alert-dismissible");
                    tagBuilder.InnerHtml =
                        "<button type=\"button\" class=\"close\" " +
                        "data-dismiss=\"alert\" aria-label=\"Close\">" +
                        "<span aria-hidden=\"true\">&times;</span></button>";
                }

                tagBuilder.InnerHtml += $"<span>{alert.Message}</span>";

                stringBuilder.AppendLine(tagBuilder.ToString());
            }

            alerts.Clear();

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}