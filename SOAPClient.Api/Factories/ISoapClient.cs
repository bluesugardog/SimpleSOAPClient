namespace SOAPClient.Api.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Handlers;
    using Models;

    /// <summary>
    /// The SOAP client that can be used to invoke SOAP Endpoints
    /// </summary>
    public interface ISoapClient
    {
        /// <summary>
        /// The handler
        /// </summary>
        IReadOnlyCollection<ISoapHandler> Handlers { get; }

        /// <summary>
        /// The client settings
        /// </summary>
        SoapClientSettings Settings { get; set; }

        #region Send

        /// <summary>
        /// Sends the given <see cref="SoapEnvelope"/> into the specified url.
        /// </summary>
        /// <param name="url">The url that will receive the request</param>
        /// <param name="action">The SOAP action beeing performed</param>
        /// <param name="requestEnvelope">The <see cref="SoapEnvelope"/> to be sent</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited for the result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<SoapEnvelope> SendAsync(
            string url, string action, SoapEnvelope requestEnvelope, CancellationToken ct = default(CancellationToken));

        #endregion

        /// <summary>
        /// Adds the <see cref="ISoapHandler"/> to the <see cref="Handlers"/> collection.
        /// </summary>
        /// <param name="handler">The handler to add</param>
        void AddHandler(ISoapHandler handler);
    }
}