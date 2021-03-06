using System.Threading.Tasks;
using Lms.Rpc.Runtime.Server.ServiceDiscovery;
using Lms.Rpc.Tests.AppService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Rpc.Tests.AppService
{
    [ServiceRoute("api/test")]
    public interface ITestAppService
    {
        [HttpPost("/test")]
        Task<long> Create(TestInput input,string test);
        
        [HttpPut]
        [HttpPost]
        Task<long> Update(TestInput input);
        
        [HttpGet]
        Task<long> Query(TestInput input);
    }
}