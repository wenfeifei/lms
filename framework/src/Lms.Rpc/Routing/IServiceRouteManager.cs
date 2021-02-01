using System.Collections.Generic;
using System.Threading.Tasks;
using Lms.Rpc.Address;
using Lms.Rpc.Routing.Descriptor;

namespace Lms.Rpc.Routing
{
    public interface IServiceRouteManager 
    {
        Task SetRoutesAsync(IReadOnlyList<ServiceRouteDescriptor> serviceRouteDescriptors);
    }
}