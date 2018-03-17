namespace AspNetMvc5Examples.Web.HtmlHelper
{
    using System.Web;
    using System.Web.Mvc;

    public static class HighlightsJsExtension
    {
        public static MvcHtmlString CodeSection(this HtmlHelper html, string code)
        {
            code = HttpUtility.HtmlDecode(code);
            code = html.Encode(code);
            var result = $@"<div class=""hljs-wrapper""><pre><code class=""html"">{code}</code></pre></div>";

            return MvcHtmlString.Create(result);
        }
    }
}