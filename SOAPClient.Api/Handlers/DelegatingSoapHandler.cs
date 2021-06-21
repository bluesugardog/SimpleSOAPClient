
namespace SOAPClient.Api.Handlers
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
	using SOAPClient.Api.Factories;

	/// <summary>
	/// SOAP Handler that exposes delegates for each handling operation.
	/// </summary>
	public sealed class DelegatingSoapHandler : ISoapHandler
    {
        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeRequestAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeRequestArguments, CancellationToken, Task> OnSoapEnvelopeRequestAsyncAction { get; set; }
        
        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpRequestAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnHttpRequestArguments, CancellationToken, Task> OnHttpRequestAsyncAction { get; set; }
        
        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpResponseAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnHttpResponseArguments, CancellationToken, Task> OnHttpResponseAsyncAction { get; set; }
        
        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeResponseAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeResponseArguments, CancellationToken, Task> OnSoapEnvelopeResponseAsyncAction { get; set; }

        #region Implementation of ISoapHandler

        /// <summary>
        /// The order for which the handler will be executed
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeRequestAsync(ISoapClient client, OnSoapEnvelopeRequestArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeRequestAsyncAction != null)
                await OnSoapEnvelopeRequestAsyncAction(client, arguments, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Method invoked before sending the <see cref="HttpRequestMessage"/> to the server.
        /// Useful to log the request or change properties like HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnHttpRequestAsync(ISoapClient client, OnHttpRequestArguments arguments, CancellationToken ct)
        {
            if (OnHttpRequestAsyncAction != null)
                await OnHttpRequestAsyncAction(client, arguments, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Method invoked after receiving a <see cref="HttpResponseMessage"/> from the server.
        /// Useful to log the response or validate HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnHttpResponseAsync(ISoapClient client, OnHttpResponseArguments arguments, CancellationToken ct)
        {
            if (OnHttpResponseAsyncAction != null)
                await OnHttpResponseAsyncAction(client, arguments, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeResponseAsync(ISoapClient client, OnSoapEnvelopeResponseArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeResponseAsyncAction != null)
                await OnSoapEnvelopeResponseAsyncAction(client, arguments, ct).ConfigureAwait(false);
        }

        #endregion
    }
}