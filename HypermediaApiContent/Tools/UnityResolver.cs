using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace HypermediaApiSiteConsole {
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            object service = null;
            try
            {
                service = _unityContainer.Resolve(serviceType);
            } catch
            {
                
            }
            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return (IEnumerable<object>)_unityContainer.Resolve(typeof(IEnumerable<>).MakeGenericType(new[] { serviceType }));
            }
            catch
            {

            }
            return new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
           
        }
    }
}