using System.Collections.Generic;
using System.Threading.Tasks;
using Lms.Rpc.Address;
using Lms.Rpc.Routing.Descriptor;

namespace Lms.Rpc.Routing
{
    public abstract class ServiceRouteManagerBase : IServiceRouteManager
    {
        protected readonly ServiceRouteCache _serviceRouteCache;

        protected ServiceRouteManagerBase(ServiceRouteCache serviceRouteCache)
        {
            _serviceRouteCache = serviceRouteCache;
            EnterRoutes().GetAwaiter().GetResult();
        }

        protected abstract Task EnterRoutes();

        public virtual async Task SetRoutesAsync(IReadOnlyList<ServiceRouteDescriptor> serviceRouteDescriptors)
        {
             
            
        }

        protected virtual async Task RemoveExceptRouteAsyncs(IEnumerable<ServiceRouteDescriptor> serviceRouteDescriptors,
            IAddressModel hostAddress)
        {
            
        }

    }
}