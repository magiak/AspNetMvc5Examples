namespace AspNetMvcExamples.Business.FlashMessages
{
    using System.Web.Mvc;

    public static class ActionResultExtensions
    {
        public static ActionResult WithAlert(this ActionResult result, AlertType alertType, string message)
        {
            return new AlertResult(result, alertType, message);
        }

        public static ActionResult WithSuccessAlert(this ActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Success, message);
        }

        public static ActionResult WithInfoAlert(this ActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Info, message);
        }

        public static ActionResult WithWarningAlert(this ActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Warning, message);
        }

        public static ActionResult WithErrorAlert(this ActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Error, message);
        }
    }
}
