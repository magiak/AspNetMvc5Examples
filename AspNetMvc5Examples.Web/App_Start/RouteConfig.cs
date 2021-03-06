﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AspNetMvc5Examples.Web.HttpHandlers;

namespace AspNetMvc5Examples.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignoruje pokus o pristup k HTTP handleru
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.Add("HTTP handler", new Route("routehttphandler.axd", new RouteHandler())); // TODO it breaks all the links in the app

            // @Html.ActionLink("Movies released", "Released", "Movies", new { year=2017, month=5 }, null)
            // WITH: /Movies/Released/2017/5
            // WITHOUT: /Movies/Released?year=2017&month=5
            //routes.MapRoute(
            //    name: "Movies",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new
            //    {
            //        controller = "Movies",
            //        action = "Released"
            //    },
            //    constraints: new
            //    {
            //        year = @"\d{4}",
            //        month = "\\d{2}"
            //    }
            //);

            // http://localhost/
            // http://localhost/home
            // http://localhost/HoMe/index // Case insensitive
            // http://localhost/Order/Details/1
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home", // Konvence je pouziti jmena bez Controller
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            // Bez pouziti extensiony
            //Route route = new Route(
            //    "{controller}/{action}/{id}",
            //    new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } },
            //new MvcRouteHandler());
            //routes.Add("Default", route);

            // http://localhost/Order/Details/1/1
            // http://localhost/Order/Details?userId=1&orderId=1
            // Pouziti v pripade slozeneho klice
            //routes.MapRoute(
            //    name: "Orders",
            //    url: "Order/{action}/{userId}/{orderId}",
            //    defaults: new
            //    {
            //        controller = "Order", 
            //        action = "Index",
            //        userId = UrlParameter.Optional,
            //        orderId = UrlParameter.Optional
            //    });
        }

    }

    public class RouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new RouteHttpHandler();
        }
    }
}
