namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Details(int userId, int orderId)
        {
            return this.Content($"UserId={userId} OrderId={orderId}");
        }
    }
}