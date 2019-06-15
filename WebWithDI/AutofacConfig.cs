using System;
using System.Reflection;
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

            Assembly assembly = Assembly.GetExecutingAssembly();

            // 註冊 Assembly 內所有的 ApiController
            // builder.RegisterApiControllers(assembly).InstancePerRequest();

            // 註冊指定 Controller
            // builder.RegisterType<OrgRecordController>().InstancePerRequest();
            // builder.RegisterType<SingletonController>().InstancePerRequest();
            // builder.RegisterType<NamedController>().InstancePerRequest();
            // builder.RegisterType<KeyedController>().InstancePerRequest();

            // 註冊 Type 結尾是 Controller 的所有 class
            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.Name.EndsWith("Controller", StringComparison.Ordinal))
                   .InstancePerRequest();

            // 註冊 Prefix 為 BaseType 的所有類別
            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.Name.StartsWith("BaseType", StringComparison.Ordinal));

            builder.RegisterType<OrgRecordBL>().As<IOrgRecordBL>();
            builder.RegisterType<OrgRecordImpl>().As<IOrgRecordDAO>();
            
            builder.RegisterType<PaRecordBL>().As<IPaRecordBL>(); 
            builder.RegisterType<PaRecordImpl>().As<IPaRecordDAO>();

            // 每次只會 DI 相同的 instance
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

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}