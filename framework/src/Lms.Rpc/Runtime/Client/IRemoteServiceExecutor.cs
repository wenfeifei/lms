﻿using System.Threading.Tasks;
using Lms.Core.DependencyInjection;
using Lms.Rpc.Runtime.Server;

namespace Lms.Rpc.Runtime.Client
{
    public interface IRemoteServiceExecutor : ITransientDependency
    {
        Task<object> Execute(ServiceEntry serviceEntry, object[] parameters, string serviceKey = null);
    }
}