using Autofac;
using Autofac.Extras.Multitenant;
//using Autofac.Extras.Multitenant.Wcf;
using Autofac.Extras.Multitenant.Web;
using Autofac.Integration.Mvc;
using SimpleLogin.Authentications;
using SimpleLogin.Controllers;
using System.Reflection;
using System.Web.Mvc;

namespace SimpleLogin
{
    /// <summary>
    /// The inversion of control class.
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Build the container.
        /// </summary>
        public static void BuildContainer()
        {
            var tenantIdStrategy = new RequestParameterTenantIdentificationStrategy("tenant");
            
            var builder = new ContainerBuilder();
            builder.RegisterType<FacebookController>();
            builder.RegisterType<TwitterController>();
            builder.RegisterInstance(tenantIdStrategy).As<ITenantIdentificationStrategy>();
            
            var mtc = new MultitenantContainer(tenantIdStrategy, builder.Build());
            mtc.ConfigureTenant("1",
                b =>
                {
                    b.RegisterType<FacebookAuthentication>().As<IAuthentication>().InstancePerDependency();
                    b.RegisterType<FacebookController>().As<IController>();
                });
            mtc.ConfigureTenant("2",
                b =>
                {
                    b.RegisterType<TwitterAuthentication>().As<IAuthentication>().SingleInstance();
                    b.RegisterType<TwitterController>().As<IController>();
                });

            DependencyResolver.SetResolver(new AutofacDependencyResolver(mtc));
        }
    }
}