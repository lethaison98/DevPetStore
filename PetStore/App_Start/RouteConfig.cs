using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cho_canh",
                url: "Cho_canh/{MetaTitle}",
                defaults: new { controller = "Pet", action = "GiongCho", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );
            routes.MapRoute(
                name: "Meo_canh",
                url: "Meo_canh/{MetaTitle}",
                defaults: new { controller = "Pet", action = "GiongMeo", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );
            routes.MapRoute(
                name: "bai_viet",
                url: "KienThuc/{MetaTitle}",
                defaults: new { controller = "KienThuc", action = "ChiTiet", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );
            routes.MapRoute(
                name: "Add Cart",
                url: "Them_gio_hang",
                defaults: new { controller = "GioHang", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );
            routes.MapRoute(
                name: "Tim_kiem",
                url: "Tim_kiem",
                defaults: new { controller = "Pet", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PetStore.Controllers" }
                );

        }
    }
}
