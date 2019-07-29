using Comp2084_CarDealer.App_Start;
using Comp2084_CarDealer.Models;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Comp2084_CarDealer
{
    public static class UnityConfig
    {
        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ICarDAL, CarDAL>(); //map the IAlbumBL interface to use AlbumBL by default
        }

        public static void RegisterWebApiComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
        }
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}