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
        private readonly IKernel kernel;

        public NinjectResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<IConnectionFactory>().To<SqlConnectionFactory>().WithConstructorArgument("connectionString", Connection.ConnectionString);
            this.kernel.Bind<IPerson>().To<PersonRepository>(); 
        }
    }
}