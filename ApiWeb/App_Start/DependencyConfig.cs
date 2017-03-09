using ApiWeb.Repositories;
using ApiWeb.Repositories.Interfaces;
using ApiWeb.Services;
using LightInject;
using System.Web.Http;

namespace ApiWeb.App_Start
{
    public class DependencyConfig
    {
        public static void Config()
        {
            var container = new ServiceContainer();
            container.Register<IPersonRepository, PersonRepository>();
            container.Register<IService, Service1>("Service1");
            container.Register<IService, Service2>("Service2");

            container.RegisterApiControllers();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}