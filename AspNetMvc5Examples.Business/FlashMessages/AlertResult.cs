namespace AspNetMvcExamples.Business.FlashMessages
{
    using System.Web.Mvc;

    public class AlertResult : ActionResult
    {
        public ActionResult InnerResult { get; set; }
        public AlertType AlertType { get; set; }
        public string Message { get; set; }

        public AlertResult(
            ActionResult innerResult,
            AlertType alertType,
            string message)
        {
            this.InnerResult = innerResult;
            this.AlertType = alertType;
            this.Message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData.AddAlert(this.AlertType, this.Message);
            this.InnerResult.ExecuteResult(context);
        }
    }
}
