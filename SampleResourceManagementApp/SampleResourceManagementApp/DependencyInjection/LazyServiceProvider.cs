using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SampleResourceManagementApp.Localization.Dictionaries.DictionariesExtensions;

namespace SampleResourceManagementApp.DependencyInjection
{
    public class LazyServiceProvider :ILazyServiceProvider
    {
        protected IDictionary<Type, object> CachedServices { get; set; }

        protected IServiceProvider ServiceProvider { get; set; }

        public LazyServiceProvider(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.CachedServices = (IDictionary<Type, object>)new Dictionary<Type, object>();
        }

        public virtual T LazyGetRequiredService<T>() => (T)this.LazyGetRequiredService(typeof(T));

        public virtual object LazyGetRequiredService(Type serviceType) => this.CachedServices.GetOrAdd<Type, object>(serviceType, (Func<object>)(() => ServiceProviderServiceExtensions.GetRequiredService(this.ServiceProvider, serviceType)));

        public virtual T LazyGetService<T>() => (T)this.LazyGetService(typeof(T));

        public virtual object LazyGetService(Type serviceType) => this.CachedServices.GetOrAdd<Type, object>(serviceType, (Func<object>)(() => this.ServiceProvider.GetService(serviceType)));

        public virtual T LazyGetService<T>(T defaultValue) => (T)this.LazyGetService(typeof(T), (object)defaultValue);

        public virtual object LazyGetService(Type serviceType, object defaultValue) => this.LazyGetService(serviceType) ?? defaultValue;

        public virtual T LazyGetService<T>(Func<IServiceProvider, object> factory) => (T)this.LazyGetService(typeof(T), factory);

        public virtual object LazyGetService(Type serviceType, Func<IServiceProvider, object> factory) => this.CachedServices.GetOrAdd<Type, object>(serviceType, (Func<object>)(() => factory(this.ServiceProvider)));
    }
}
