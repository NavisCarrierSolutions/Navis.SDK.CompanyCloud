using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Navis.SDK.CompanyCloud.Core
{
    public abstract class ApiWrapper
    {
        private const string DefaultServerAddress = "https://api.company.navis-cvs.com";
        private readonly Lazy<JsonSerializerSettings> _settings;
        private readonly Uri _baseUrl;

        protected ApiWrapper(string serverAddress = DefaultServerAddress)
        {
            _baseUrl = new Uri(serverAddress);
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        protected virtual void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
        }

        protected virtual void PrepareRequest(System.Net.Http.HttpClient client,
            System.Net.Http.HttpRequestMessage request,
            string url)
        {
        }

        protected virtual void ProcessResponse(System.Net.Http.HttpClient client,
            System.Net.Http.HttpResponseMessage response)
        {
        }

        /// <summary>Posts a new object using the specified route.</summary>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="apiKey">Api key identifier.</param>
        /// <param name="route">Route to use to post object.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<T> GetObjectAsync<T>(string accountIdentifier, string apiKey, string route, CancellationToken cancellationToken)
        {
            var client = new System.Net.Http.HttpClient {BaseAddress = _baseUrl};
            try
            {
                using (var request = new System.Net.Http.HttpRequestMessage())
                {
                    if (accountIdentifier != null)
                        request.Headers.TryAddWithoutValidation("accountIdentifier",
                            ConvertToString(accountIdentifier, System.Globalization.CultureInfo.InvariantCulture));
                    if (apiKey != null)
                        request.Headers.TryAddWithoutValidation("apiKey",
                            ConvertToString(apiKey, System.Globalization.CultureInfo.InvariantCulture));
                    request.Method = new System.Net.Http.HttpMethod("GET");
                    request.Headers.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    
                    request.RequestUri = new Uri(route, UriKind.RelativeOrAbsolute);

                    PrepareRequest(client, request, route);

                    var response = await client.SendAsync(request,
                            System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        if (response.Content?.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int) response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert
                                    .DeserializeObject<T>(responseData, _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new HttpException("Could not deserialize the response body.",
                                    (int) response.StatusCode, responseData, headers, exception);
                            }
                        }
                        else if (status == "404")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Requested {nameof(T)} was not found", (int) response.StatusCode,
                                responseData, headers, null);
                        }
                        else if (status == "401")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The request did not have the correct authorization header credientials.",
                                (int) response.StatusCode, responseData, headers, null);
                        }
                        else if (status == "403")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException("You have not enough rights to finish the request",
                                (int) response.StatusCode, responseData, headers, null);
                        }
                        else if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The HTTP status code of the response was not expected (" + (int) response.StatusCode +
                                ").", (int) response.StatusCode, responseData, headers, null);
                        }

                        return default(T);
                    }
                    finally
                    {
                        response.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>Posts a new object using the specified route.</summary>
        /// <param name="postObject">Object to post.</param>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="apiKey">Api key identifier.</param>
        /// <param name="route">Route to use to post object.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<TR> PostObjectAsync<TR, TI>(TI postObject, string accountIdentifier, string apiKey, string route, CancellationToken cancellationToken)
        {
            var client = new System.Net.Http.HttpClient {BaseAddress = _baseUrl};
            try
            {
                using (var request = new System.Net.Http.HttpRequestMessage())
                {
                    if (accountIdentifier != null)
                        request.Headers.TryAddWithoutValidation("accountIdentifier",
                            ConvertToString(accountIdentifier, System.Globalization.CultureInfo.InvariantCulture));
                    if (apiKey != null)
                        request.Headers.TryAddWithoutValidation("apiKey",
                            ConvertToString(apiKey, System.Globalization.CultureInfo.InvariantCulture));
                    var content =
                        new System.Net.Http.StringContent(
                            JsonConvert.SerializeObject(postObject, _settings.Value));
                    content.Headers.ContentType =
                        System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new System.Net.Http.HttpMethod("POST");
                    request.Headers.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request.RequestUri = new Uri(route, UriKind.RelativeOrAbsolute);

                    PrepareRequest(client, request, route);

                    var response = await client.SendAsync(request,
                            System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        if (response.Content?.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int) response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<TR>(responseData,
                                    _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new HttpException("Could not deserialize the response body.",
                                    (int) response.StatusCode, responseData, headers, exception);
                            }
                        }
                        else if (status == "400")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                $"Incoming {nameof(TI)} is invalid (see response message details)",
                                (int) response.StatusCode, responseData, headers, null);
                        }
                        else if (status == "404")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Requested {nameof(TI)} was not found", (int) response.StatusCode,
                                responseData, headers, null);
                        }
                        else if (status == "409")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Conflict. {nameof(TI)} already exist.", (int) response.StatusCode,
                                responseData, headers, null);
                        }
                        else if (status == "401")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The request did not have the correct authorization header credientials.",
                                (int) response.StatusCode, responseData, headers, null);
                        }
                        else if (status == "403")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException("You have not enough rights to finish the request",
                                (int) response.StatusCode, responseData, headers, null);
                        }
                        else if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The HTTP status code of the response was not expected (" + (int) response.StatusCode +
                                ").", (int) response.StatusCode, responseData, headers, null);
                        }

                        return default(TR);
                    }
                    finally
                    {
                        response.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>Updates the corresponding entity with the specified object.</summary>
        /// <param name="putObject">Object to use to update the corresponding entity.</param>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="apiKey">Api key identifier.</param>
        /// <param name="route">Route to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<TR> PutObjectAsync<TR, TI>(TI putObject, string accountIdentifier, string apiKey, string route, CancellationToken cancellationToken)
        {
            var client = new System.Net.Http.HttpClient { BaseAddress = _baseUrl };
            try
            {
                using (var request = new System.Net.Http.HttpRequestMessage())
                {
                    if (accountIdentifier != null)
                        request.Headers.TryAddWithoutValidation("accountIdentifier",
                            ConvertToString(accountIdentifier, System.Globalization.CultureInfo.InvariantCulture));
                    if (apiKey != null)
                        request.Headers.TryAddWithoutValidation("apiKey",
                            ConvertToString(apiKey, System.Globalization.CultureInfo.InvariantCulture));
                    var content =
                        new System.Net.Http.StringContent(JsonConvert.SerializeObject(putObject, _settings.Value));
                    content.Headers.ContentType =
                        System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new System.Net.Http.HttpMethod("PUT");
                    request.Headers.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request.RequestUri = new Uri(route, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, route);

                    var response = await client.SendAsync(request,
                            System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        if (response.Content?.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<TR>(responseData,
                                    _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new HttpException("Could not deserialize the response body.",
                                    (int)response.StatusCode, responseData, headers, exception);
                            }
                        }
                        else if (status == "400")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Incoming {nameof(TI)} is invalid (see response message details)",
                                (int)response.StatusCode, responseData, headers, null);
                        }
                        else if (status == "404")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Requested {nameof(TI)} was not found", (int)response.StatusCode,
                                responseData, headers, null);
                        }
                        else if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                                ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(TR);
                    }
                    finally
                    {
                        response?.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>Deletes an object.</summary>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="apiKey">Api key identifier.</param>
        /// <param name="route">Route to use</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<T> DeleteObjectAsync<T>(string accountIdentifier, string apiKey, string route, CancellationToken cancellationToken)
        {
            var client = new System.Net.Http.HttpClient { BaseAddress = _baseUrl };
            try
            {
                using (var request = new System.Net.Http.HttpRequestMessage())
                {
                    if (accountIdentifier != null)
                        request.Headers.TryAddWithoutValidation("accountIdentifier",
                            ConvertToString(accountIdentifier, System.Globalization.CultureInfo.InvariantCulture));
                    if (apiKey != null)
                        request.Headers.TryAddWithoutValidation("apiKey",
                            ConvertToString(apiKey, System.Globalization.CultureInfo.InvariantCulture));
                    request.Method = new System.Net.Http.HttpMethod("DELETE");
                    request.Headers.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request.RequestUri = new Uri(route, UriKind.RelativeOrAbsolute);

                    PrepareRequest(client, request, route);

                    var response = await client.SendAsync(request,
                            System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        if (response.Content?.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<T>(responseData,
                                    _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new HttpException("Could not deserialize the response body.",
                                    (int)response.StatusCode, responseData, headers, exception);
                            }
                        }
                        else if (status == "404")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException($"Requested {nameof(T)} was not found", (int)response.StatusCode,
                                responseData, headers, null);
                        }
                        else if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null
                                ? null
                                : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new HttpException(
                                "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                                ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(T);
                    }
                    finally
                    {
                        response?.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        private static string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is Enum)
            {
                string name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType())
                        .GetDeclaredField(name);
                    if (field != null)
                    {
                        if (System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field,
                            typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            else if (value is byte[] bytes)
            {
                return Convert.ToBase64String(bytes);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = ((Array) value).OfType<object>();
                return string.Join(",", array.Select(o => ConvertToString(o, cultureInfo)));
            }

            return Convert.ToString(value, cultureInfo);
        }
    }
}
