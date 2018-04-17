﻿namespace AspNetMvc5Examples.Web.HtmlHelper
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class ModalHtmlHelperExtensions
    {
        public static MvcHtmlString ModalButton(this HtmlHelper htmlHelper, string id, string text)
        {
            var result = 
$@"<button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#{id}"">
  {text}
</button>";

            return MvcHtmlString.Create(result);
        }
        
        public static MvcHtmlString Modal(this HtmlHelper htmlHelper,
            string id,
            string title,
            string body,
            string primary = "Submit",
            string secondary = "Close")
        {
            var result = 
$@"<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""{id}"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"">{title}</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
        <p>{body}</p>
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-primary"">{primary}</button>
        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">{secondary}</button>
      </div>
    </div>
  </div>
</div>";

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ModalPartial(this HtmlHelper htmlHelper,
            string id,
            string title,
            string body,
            string primary = "Submit",
            string secondary = "Close")
        {
            return htmlHelper.Partial("_ModalTemplate", id);
        }
    }
}