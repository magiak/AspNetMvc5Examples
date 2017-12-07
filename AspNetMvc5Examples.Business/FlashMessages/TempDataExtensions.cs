namespace AspNetMvcExamples.Business.FlashMessages
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class TempDataExtensions
    {
        private const string TempDataKey = "FlashMessages";

        public static List<Alert> GetAllAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(TempDataKey))
            {
                tempData[TempDataKey] = new List<Alert>();
            }

            return (List<Alert>)tempData[TempDataKey];
        }

        public static void AddAlert(this TempDataDictionary tempData, AlertType alertType, string message)
        {
            var alerts = tempData.GetAllAlerts();
            alerts.Add(new Alert()
            {
                AllertType = alertType,
                Message = message
            });
        }
    }
}
