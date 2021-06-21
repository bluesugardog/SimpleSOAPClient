using Microsoft.Extensions.Logging;
using SOAPClient.Api.Constants;
using SOAPClient.Api.Exceptions;
using SOAPClient.Api.Factories;
using SOAPClient.Api.Handlers;
using SOAPClient.Api.Helpers;
using SOAPClient.Api.Models;
using SOAPClient.Api.Models.Headers;
using SOAPClient.Api.Models.Headers.Oasis.Security;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SOAPClient.Api
{
	public static class Usage
	{
		public static async Task BuildClient()
		{
			//using (var client = SoapClient.Prepare().WithHandler(new DelegatingSoapHandler
			//{
			//	OnSoapEnvelopeRequestAsyncAction = async (c, d, cancellationToken) =>
			//	{
			//		d.Envelope.WithHeaders(
			//			KnownHeader.Oasis.Security.UsernameTokenAndPasswordText(
			//				"some-user", "some-password"));
			//	},
			//	OnHttpRequestAsyncAction = async (soapClient, d, cancellationToken) =>
			//	{
			//		Logger<>.LogTrace(
			//			"SOAP Outbound Request -> {0} {1}({2})\n{3}",
			//			d.Request.Method, d.Url, d.Action, await d.Request.Content.ReadAsStringAsync());
			//	},
			//	OnHttpResponseAsyncAction = async (soapClient, d, cancellationToken) =>
			//	{
			//		Logger.LogTrace(
			//			"SOAP Outbound Response -> {0}({1}) {2} {3}\n{4}",
			//			d.Url, d.Action, (int)d.Response.StatusCode, d.Response.StatusCode,
			//			await d.Response.Content.ReadAsStringAsync());
			//	},
			//	OnSoapEnvelopeResponseAsyncAction = async (soapClient, d, cancellationToken) =>
			//	{
			//		var header =
			//			d.Envelope.Header<UsernameTokenAndPasswordTextSoapHeader>(
			//				"{" + Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10 +
			//				"}Security");
			//	}
			//}))
			//{
			//	var requestEnvelope =
			//		SoapEnvelope.Prepare().Body(new IsAliveRequest());

			//	SoapEnvelope responseEnvelope;
			//	try
			//	{
			//		responseEnvelope =
			//			await client.SendAsync(
			//				"https://services.company.com/Service.svc",
			//				"http://services.company.com/IService/IsAlive",
			//				requestEnvelope, ct);
			//	}
			//	catch (SoapEnvelopeSerializationException e)
			//	{
			//		Logger.LogError(e,
			//			$"Failed to serialize the SOAP Envelope [Envelope={e.Envelope}]");
			//		throw;
			//	}
			//	catch (SoapEnvelopeDeserializationException e)
			//	{
			//		Logger.LogError(e,
			//			$"Failed to deserialize the response into a SOAP Envelope [XmlValue={e.XmlValue}]");
			//		throw;
			//	}

			//	try
			//	{
			//		var response = responseEnvelope.Body<IsAliveResponse>();
			//	}
			//	catch (FaultException e)
			//	{
			//		Logger.LogError(e,
			//			$"The server returned a fault [Code={e.Code}, String={e.String}, Actor={e.Actor}]");
			//		throw;
			//	}
			//}
		}

		[XmlRoot("IsAliveRequest", Namespace = "http://services.company.com")]
		public class IsAliveRequest
		{
		}

		[XmlRoot("IsAliveResponse", Namespace = "http://services.company.com")]
		public class IsAliveResponse
		{
			[XmlElement("IsAliveResult")]
			public bool IsAlive { get; set; }
		}
	}
}