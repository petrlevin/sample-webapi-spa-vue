using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Common;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Web
{
    public static class UnityRegistrator
    {
        public static IDependencyResolver RegisterRepository<T,TR>(string connectionString) where TR: IRepository<T>
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository<T>, TR>(new HierarchicalLifetimeManager(), new InjectionConstructor(connectionString));
            return new UnityResolver(container);
        }

    }
}
