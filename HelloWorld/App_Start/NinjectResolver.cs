using HelloWorld.Helpers;
using HelloWorld.Interfaces;
using HelloWorld.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelloWorld
{
    public class NinjectResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this._kernel.Bind<IConnectionFactory>().To<SqlConnectionFactory>().WithConstructorArgument("connectionString", Connection.ConnectionString);
            this._kernel.Bind<IPerson>().To<PersonRepository>(); 
        }
    }
}