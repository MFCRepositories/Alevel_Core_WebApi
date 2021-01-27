using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptions;
using Core.Utilities.Security;
using Core.Utilities.Security.Jwt;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;

namespace Business.Dependency.Autofac
{
    /// <summary>
    /// IoC Contenier yapısının Business Katmanında yönetir.
    /// Proje Bağımlılıklaırnı bu katmanda UI katmaında taşır.
    /// </summary>
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductServis>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //Assembly de çalışan uygulamaları Tespit eder
            var assembly =
                System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
