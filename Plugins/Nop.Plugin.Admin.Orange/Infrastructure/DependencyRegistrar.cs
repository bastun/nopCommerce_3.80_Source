using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Admin.Orange.Data;
using Nop.Plugin.Admin.Orange.Domain;
using Nop.Plugin.Admin.Orange.Services;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Admin.Orange.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<AdminOrangeService>().As<IAdminOrangeService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<AdminOrangeObjectContext>(builder, "nop_object_context_orange-admin");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<AdminOrange>>()
                .As<IRepository<AdminOrange>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_orange-admin"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
