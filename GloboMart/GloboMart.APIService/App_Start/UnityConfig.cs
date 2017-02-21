using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using GloboMart.APIService.Models;
using GloboMart.APIService.DataAccessRepository;

namespace GloboMart.APIService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataAccessRepository<Product, int>, clsDataAccessRepository>();         

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}