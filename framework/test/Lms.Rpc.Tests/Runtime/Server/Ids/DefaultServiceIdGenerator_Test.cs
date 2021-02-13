using Lms.Rpc.Runtime.Support.Ids;
using Lms.Rpc.Tests.AppService;
using Lms.TestBase.Testing;
using Xunit;

namespace Lms.Rpc.Tests.Runtime.Server.Ids
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