using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Lms.Rpc.Address;
using Lms.Rpc.Address.Descriptor;
using Lms.Rpc.Routing.Descriptor;
using Lms.Rpc.Runtime.Server.ServiceEntry;
using Lms.Rpc.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Lms.Rpc.Routing
{
    public class DefaultServiceRouteProvider : IServiceRouteProvider
    {
        private readonly IServiceEntryManager _serviceEntryManager;
        private readonly IServiceRouteManager _serviceRouteManager;
        private readonly ILogger<DefaultServiceRouteProvider> _logger;

        public DefaultServiceRouteProvider(IServiceEntryManager serviceEntryManager,
            IServiceRouteManager serviceRouteManager)
        {
            _serviceEntryManager = serviceEntryManager;
            _serviceRouteManager = serviceRouteManager;
            _logger = NullLogger<DefaultServiceRouteProvider>.Instance;
        }

        public async Task RegisterRoutes(double processorTime)
        {
            var localServiceEntries = _serviceEntryManager.GetLocalEntries();
            var serviceRouteDescriptors = localServiceEntries.Select(e => e.CreateLocalRouteDescriptor(AddressType.Rpc)).ToImmutableList();
            await _serviceRouteManager.SetRoutesAsync(serviceRouteDescriptors);
        }
    }
}