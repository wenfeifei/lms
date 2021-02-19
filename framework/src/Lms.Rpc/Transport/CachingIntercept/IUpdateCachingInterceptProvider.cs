﻿namespace Lms.Rpc.Transport.CachingIntercept
{
    public interface IUpdateCachingInterceptProvider : ICachingInterceptProvider
    {
        string CacheName { get; }
        
        public string KeyTemplete { get; }
    }
}