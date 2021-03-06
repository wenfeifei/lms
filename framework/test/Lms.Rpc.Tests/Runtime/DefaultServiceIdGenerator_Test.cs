using Lms.Rpc.Runtime;
using Lms.Rpc.Runtime.Server;
using Lms.Rpc.Tests.AppService;
using Lms.TestBase.Testing;
using Xunit;

namespace Lms.Rpc.Tests.Runtime
{
    public class DefaultServiceIdGenerator_Test : LmsIntegratedTest<LmsRpcTestModule>
    {
        private readonly IServiceIdGenerator _serviceIdGenerator;

        public DefaultServiceIdGenerator_Test()
        {
            _serviceIdGenerator = GetRequiredService<IServiceIdGenerator>();
        }

        [Fact]
        public void Should_GenerateServiceId()
        {
            var type = typeof(ITestAppService);
            // foreach (var method in type.GetMethods())
            // {
            //     _serviceIdGenerator.GenerateServiceId(method).ShouldNotBeEmpty();
            // }
        }
    }
}