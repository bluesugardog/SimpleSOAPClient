﻿

using SOAPClient.Api.Factories;
using SOAPClient.Api.Models;

namespace SOAPClient.Api.Helpers
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Handlers;

    /// <summary>
    /// Helper methods for working with <see cref="ISoapClient"/> instances.
    /// </summary>
    public static class ClientHelpers
    {
        #region Settings

        /// <summary>
        /// Sets the <see cref="SoapClientSettings"/> to be used by the client.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="settings">The settings to be used</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient UsingSettings<TSoapClient>(
            this TSoapClient client, SoapClientSettings settings)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            client.Settings = settings;
            return client;
        }

        /// <summary>
        /// Sets the <see cref="SoapClientSettings.Default"/> as the settings to be used by the client.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient UsingDefaultSettings<TSoapClient>(this TSoapClient client)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            client.Settings = SoapClientSettings.Default;
            return client;
        }

        #endregion

        #region Handlers

        /// <summary>
        /// Adds the given handler to the SOAP client
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="handler">The handler to add</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient WithHandler<TSoapClient>(this TSoapClient client, ISoapHandler handler)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            client.AddHandler(handler);
            return client;
        }

        #region OnSoapEnvelopeRequest

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnSoapEnvelopeRequestAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnSoapEnvelopeRequest<TSoapClient>(
            this TSoapClient client, Func<ISoapClient, OnSoapEnvelopeRequestArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnSoapEnvelopeRequestAsyncAction = action
            });
            return client;
        }

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnSoapEnvelopeRequestAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnSoapEnvelopeRequest<TSoapClient>(
            this TSoapClient client, Func<OnSoapEnvelopeRequestArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnSoapEnvelopeRequestAsyncAction = async (c, args, ct) => await action(args, ct)
            });
            return client;
        }

        #endregion

        #region OnHttpRequest

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnHttpRequestAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnHttpRequest<TSoapClient>(
            this TSoapClient client, Func<ISoapClient, OnHttpRequestArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnHttpRequestAsyncAction = action
            });
            return client;
        }

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnHttpRequestAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnHttpRequest<TSoapClient>(
            this TSoapClient client, Func<OnHttpRequestArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnHttpRequestAsyncAction = async (c, args, ct) => await action(args, ct)
            });
            return client;
        }

        #endregion

        #region OnHttpResponse

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnHttpResponseAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnHttpResponse<TSoapClient>(
            this TSoapClient client, Func<ISoapClient, OnHttpResponseArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnHttpResponseAsyncAction = action
            });
            return client;
        }

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnHttpResponseAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnHttpResponse<TSoapClient>(
            this TSoapClient client, Func<OnHttpResponseArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnHttpResponseAsyncAction = async (c, args, ct) => await action(args, ct)
            });
            return client;
        }

        #endregion

        #region OnSoapEnvelopeResponse

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnSoapEnvelopeResponseAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnSoapEnvelopeResponse<TSoapClient>(
            this TSoapClient client, Func<ISoapClient, OnSoapEnvelopeResponseArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnSoapEnvelopeResponseAsyncAction = action
            });
            return client;
        }

        /// <summary>
        /// Assigns the given delegate has an handler for <see cref="ISoapHandler.OnSoapEnvelopeResponseAsync"/>
        /// operations using a <see cref="DelegatingSoapHandler"/> as a wrapper.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="client">The client to be used</param>
        /// <param name="action">The handler action</param>
        /// <param name="order">The handler order</param>
        /// <returns>The SOAP client after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TSoapClient OnSoapEnvelopeResponse<TSoapClient>(
            this TSoapClient client, Func<OnSoapEnvelopeResponseArguments, CancellationToken, Task> action, int order = 0)
            where TSoapClient : ISoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (action == null) throw new ArgumentNullException(nameof(action));

            client.AddHandler(new DelegatingSoapHandler
            {
                Order = order,
                OnSoapEnvelopeResponseAsyncAction = async (c, args, ct) => await action(args, ct)
            });
            return client;
        }

        #endregion

        #endregion

        #region HttpClient

        /// <summary>
        /// Allows an handler to configure the <see cref="SoapClient.HttpClient"/> instance.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP Client type</typeparam>
        /// <param name="client">The client to configure</param>
        /// <param name="cfgHandler">The configuration handler</param>
        /// <returns>The client after changes</returns>
        public static TSoapClient UsingClientConfiguration<TSoapClient>(
            this TSoapClient client, Action<HttpClient> cfgHandler)
            where TSoapClient : SoapClient
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (cfgHandler == null) throw new ArgumentNullException(nameof(cfgHandler));

            cfgHandler(client.HttpClient);

            return client;
        }

        #endregion

        /// <summary>
        /// Sends the given <see cref="SoapEnvelope"/> into the specified url.
        /// </summary>
        /// <param name="client">The client to be used</param>
        /// <param name="url">The url that will receive the request</param>
        /// <param name="action">The SOAP Action beeing performed</param>
        /// <param name="requestEnvelope">The <see cref="SoapEnvelope"/> to be sent</param>
        /// <returns>The resulting <see cref="SoapEnvelope"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SoapEnvelope Send(
            this ISoapClient client, string url, string action, SoapEnvelope requestEnvelope)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            return client.SendAsync(url, action, requestEnvelope, CancellationToken.None)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}
