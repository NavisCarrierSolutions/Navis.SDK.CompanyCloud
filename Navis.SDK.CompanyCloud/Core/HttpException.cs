using System;
using System.Collections.Generic;

namespace Navis.SDK.CompanyCloud.Core
{
    public class HttpException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the HTTP response message.
        /// </summary>
        public string Response { get; }

        /// <summary>
        /// Gets the headers included in the response.
        /// </summary>
        public Dictionary<string, IEnumerable<string>> Headers
        {
            get;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of the <see cref="T:Navis.SDK.CompanyCloud.Core.ApiException" /> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="response">Response message.</param>
        /// <param name="headers">HTTP response headers.</param>
        /// <param name="innerException">Inner exception.</param>
        public HttpException(string message, int statusCode, string response,
            Dictionary<string, IEnumerable<string>> headers,
            Exception innerException)
            : base(
                message + "\n\nStatus: " + statusCode + "\nResponse: \n" +
                response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
        }
    }

    public class HttpException<TResult> : HttpException
    {
        public TResult Result { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="HttpException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="response">Response message.</param>
        /// <param name="headers">HTTP response headers.</param>
        /// <param name="result">Result object.</param>
        /// <param name="innerException">Inner exception.</param>
        public HttpException(string message, int statusCode, string response,
            Dictionary<string, IEnumerable<string>> headers,
            TResult result, Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}
