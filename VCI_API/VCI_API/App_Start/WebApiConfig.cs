using System.Web.Http;
using System.Web.Http.Cors;

namespace VCI_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //Origines permitidos
            var Cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(Cors);

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
