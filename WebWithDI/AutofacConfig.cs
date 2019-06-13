using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebWithDI.Controllers;
using WebWithDI.BL;
using WebWithDI.DAL;

namespace WebWithDI
{
    public static class AutofacConfig
    {
        public static void SetAutofacConfig(this HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OrgRecordController>().InstancePerRequest();
        
            builder.RegisterType<OrgRecordBL>().As<IOrgRecordBL>();
            builder.RegisterType<OrgRecordImpl>().As<IOrgRecordDAO>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}