﻿using System.Linq;
using System.Threading.Tasks;
using Lms.RegistryCenter.Zookeeper.Routing;
using Lms.Zookeeper;

namespace Lms.RegistryCenter.Zookeeper
{
    public class ServiceRouteSubDirectoryWatcher
    {
        protected string SubDirectoryPath { get; }
        private readonly ZookeeperServiceRouteManager _zookeeperServiceRouteManager;

        public ServiceRouteSubDirectoryWatcher(string subDirectoryPath, ZookeeperServiceRouteManager zookeeperServiceRouteManager)
        {
            SubDirectoryPath = subDirectoryPath;
            _zookeeperServiceRouteManager = zookeeperServiceRouteManager;
        }


        public async Task SubscribeChildrenChange(IZookeeperClient client, NodeChildrenChangeArgs args)
        {
            var currentChildrens = args.CurrentChildrens;
            foreach (var child in currentChildrens)
            {
                await _zookeeperServiceRouteManager.CreateSubscribeDataChange(client, child);
            }
        }
    }
}