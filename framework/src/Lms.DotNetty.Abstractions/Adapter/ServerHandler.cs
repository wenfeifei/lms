﻿using System;
using System.Net;
using DotNetty.Transport.Channels;
using Lms.Rpc.Address.HealthCheck;
using Lms.Rpc.Messages;

namespace Lms.DotNetty.Adapter
{
    public class ServerHandler : ChannelHandlerAdapter
    {
        private readonly Action<IChannelHandlerContext, TransportMessage> _readMessageAction;
        private readonly IHealthCheck _healthCheck;
        public ServerHandler(Action<IChannelHandlerContext, TransportMessage> readMessageAction,
            IHealthCheck healthCheck)
        {
            _readMessageAction = readMessageAction;
            _healthCheck = healthCheck;
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var transportMessage = (TransportMessage)message;
            _readMessageAction(context, transportMessage);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            var remoteServerEndpoint = context.Channel.RemoteAddress as IPEndPoint;
            if (remoteServerEndpoint != null)
            {
                _healthCheck.RemoveAddress(remoteServerEndpoint.Address.MapToIPv4(), remoteServerEndpoint.Port);
            }
        }
    }
}