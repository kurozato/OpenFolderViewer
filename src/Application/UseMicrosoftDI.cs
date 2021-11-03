using System;
using System.Collections.Generic;
using System.Text;
using BlackSugar.SimpleMvp;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsApp1
{
    public class DependencyResolver : IDependencyResolver
    {
        protected IServiceCollection services;

        protected ServiceProvider provider;

        public object ContainerObject => throw new NotImplementedException();

        public TService Resolve<TService>() where TService : class
        {
            return provider.GetService<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return provider.GetService(serviceType);
        }

        public void Set(IServiceCollection services)
        {
            this.services = services;
            provider = services.BuildServiceProvider();
        }

        public void Set(Action<IServiceCollection> register)
        {
            services = new ServiceCollection();
            register(services);
            provider = services.BuildServiceProvider();
        }

        public void Release()
        {
            if (provider == null) return;

            provider.Dispose();
            provider = null;
        }
    }
}
