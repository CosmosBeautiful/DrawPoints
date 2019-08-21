using DrawPoint.DI;
using DrawPoint.Repositories;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace DrawPoint
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            var container = new UnityContainer();
            container.RegisterType<ISortPointsRepository, SortPointsRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "REST",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
