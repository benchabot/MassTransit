﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.AzureServiceBusTransport
{
    using Microsoft.ServiceBus;


    public class SharedAccessKeyTokenProvider :
        IAzureServiceBusTokenProvider
    {
        readonly AzureServiceBusTokenProviderSettings _settings;

        public SharedAccessKeyTokenProvider(AzureServiceBusTokenProviderSettings settings)
        {
            _settings = settings;
        }

        public TokenProvider GetTokenProvider()
        {
            return TokenProvider.CreateSharedAccessSignatureTokenProvider(_settings.KeyName, _settings.SharedAccessKey,
                _settings.TokenTimeToLive, _settings.TokenScope);
        }
    }
}