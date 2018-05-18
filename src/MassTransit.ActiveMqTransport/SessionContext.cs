﻿// Copyright 2007-2018 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.ActiveMqTransport
{
    using System.Threading.Tasks;
    using Apache.NMS;
    using GreenPipes;
    using Topology;


    public interface SessionContext :
        PipeContext
    {
        /// <summary>
        /// The ActiveMQ session
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// The connection context for the session
        /// </summary>
        ConnectionContext ConnectionContext { get; }

        IActiveMqPublishTopology PublishTopology { get; }

        Task<ITopic> GetTopic(string topicName);

        Task<IQueue> GetQueue(string queueName);

        Task<IDestination> GetDestination(string destination, DestinationType destinationType);

        Task<IMessageProducer> CreateMessageProducer(IDestination destination);

        Task<IMessageConsumer> CreateMessageConsumer(IDestination destination, string selector, bool noLocal);

        Task DeleteTopic(string topicName);

        Task DeleteQueue(string queueName);
    }
}