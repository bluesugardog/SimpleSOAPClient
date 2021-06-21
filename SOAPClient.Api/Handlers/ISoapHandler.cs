
namespace SOAPClient.Api.Handlers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
	using SOAPClient.Api.Factories;

	/// <summary>
	/// Represents an handler for SOAP requests and responses.
	/// </summary>
	public interface ISoapHandler
    {
        /// <summary>
        /// The order for which the handler will be executed
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        Task OnSoapEnvelopeRequestAsync(ISoapClient client, OnSoapEnvelopeRequestArguments arguments, CancellationToken ct);

        /// <summary>
        /// Method invoked before sending the <see cref="HttpRequestMessage"/> to the server.
        /// Useful to log the request or change properties like HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        Task OnHttpRequestAsync(ISoapClient client, OnHttpRequestArguments arguments, CancellationToken ct);

        /// <summary>
        /// Method invoked after receiving a <see cref="HttpResponseMessage"/> from the server.
        /// Useful to log the response or validate HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        Task OnHttpResponseAsync(ISoapClient client, OnHttpResponseArguments arguments, CancellationToken ct);

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        Task OnSoapEnvelopeResponseAsync(ISoapClient client, OnSoapEnvelopeResponseArguments arguments, CancellationToken ct);
    }
}
