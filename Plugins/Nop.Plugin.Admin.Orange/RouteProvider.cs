using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Admin.Orange
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Admin.Orange.Create",
                 "Plugins/AdminOrange/Create",
                 new { controller = "AdminOrange", action = "Create", },
                 new[] { "Nop.Plugin.AdminOrange.Controllers" }
            );

            routes.MapRoute("Plugin.Admin.Orange.Edit",
                 "Plugins/AdminOrange/Edit",
                 new { controller = "AdminOrange", action = "Edit" },
                 new[] { "Nop.Plugin.AdminOrange.Controllers" }
            );
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
