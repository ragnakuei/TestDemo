using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebWithDI.Controllers;
using WebWithDI.BL;
using WebWithDI.DAL;
using WebWithDI.Enums;

namespace WebWithDI
{
    public static class AutofacConfig
    {
        public static void SetAutofacConfig(this HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.Register(c => HttpContext.Current.Request).As<HttpRequest>().InstancePerRequest();
            builder.RegisterType<OrgRecordController>().InstancePerRequest();
            builder.RegisterType<SingletonController>().InstancePerRequest();
            builder.RegisterType<NamedController>().InstancePerRequest();
            builder.RegisterType<KeyedController>().InstancePerRequest();

            builder.RegisterType<SingletonBL>().As<ISingletonBL>().SingleInstance();

            // NamedTypeProvider.GetNamedType() 透過 header key 來回傳 NamedType
            builder.RegisterType<NamedTypeProvider>().As<NamedTypeProvider>();
            builder.RegisterType<NamedABL>().Named<INamedBL>(NamedType.A.ToString());
            builder.RegisterType<NamedBBL>().Named<INamedBL>(NamedType.B.ToString());
            builder.RegisterType<NamedNoneBL>().Named<INamedBL>(NamedType.None.ToString());
            builder.Register(c =>
                             {
                                 var namedProvider = c.Resolve<NamedTypeProvider>();
                                 var namedType = namedProvider.GetNamedType();
                                 return c.ResolveNamed<INamedBL>(namedType.ToString());
                             })
                   .As<INamedBL>();
            
            // KeyedTypeProvider.GetKeyedType() 透過是否給定 header key 來回傳 KeyedType
            builder.RegisterType<KeyedTypeProvider>().As<KeyedTypeProvider>();
            builder.RegisterType<Keyed1BL>().Keyed<IKeyedBL>(KeyedType.Keyed1);
            builder.RegisterType<Keyed2BL>().Keyed<IKeyedBL>(KeyedType.Keyed2);
            builder.Register(c =>
                             {
                                 var keyedProvider = c.Resolve<KeyedTypeProvider>();
                                 var keyedType = keyedProvider.GetKeyedType();
                                 return c.ResolveKeyed<IKeyedBL>(keyedType);
                             })
                   .As<IKeyedBL>();

            builder.RegisterType<OrgRecordBL>().As<IOrgRecordBL>();
            builder.RegisterType<OrgRecordImpl>().As<IOrgRecordDAO>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}