using System;
using System.Linq;
using System.Reflection;
using Lms.Core.Exceptions;
using Lms.Rpc.Address;

namespace Lms.Rpc.Runtime.Server.ServiceDiscovery
{
    public static class ServiceDiscoveryHelper
    {
        public static IRouteTemplateProvider GetServiceBundleProvider(Type serviceType)
        {
            var serviceTypeInterface = serviceType.IsInterface ? serviceType : serviceType.GetInterfaces().FirstOrDefault(p => p.GetCustomAttribute<ServiceRouteAttribute>() != null);
            if (serviceTypeInterface == null)
            {
                throw new LmsException($"{serviceType.FullName}不是服务类型,服务类型必须通过ServiceBundleAttribute特性进行标识");
            }
            return serviceTypeInterface.GetCustomAttribute<ServiceRouteAttribute>();
        }
        
    }
}