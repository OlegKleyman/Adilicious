[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Adilicious.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Adilicious.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Adilicious.Web.App_Start
{
    using System;
    using System.Runtime.Caching;
    using System.Web;

    using Adilicious.Core;
    using Adilicious.Core.Data;
    using Adilicious.Core.Mediaradar;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ObjectCache>().ToMethod(context => MemoryCache.Default);
            kernel.Bind<IAdDataService>().To<AdDataServiceClient>();
            kernel.Bind<IAdDataProxy>().To<AdDataProxy>();
            kernel.Bind<IAdRepository>().To<AdRepository>().InSingletonScope();
        }        
    }
}
