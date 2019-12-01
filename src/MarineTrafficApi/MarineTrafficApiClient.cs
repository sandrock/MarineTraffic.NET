
namespace MarineTrafficApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class MarineTrafficApiClient : IMarineTrafficApiClient
    {
        private readonly string baseUrl;
        private readonly Lazy<HttpClient> http;
        private bool isDisposed;

        public MarineTrafficApiClient(string baseUrl, string apiKey, Lazy<HttpClient> http)
        {
            if (baseUrl == null)
                throw new ArgumentNullException("baseUrl");

            this.baseUrl = baseUrl;
            this.ApiKey = apiKey;
            this.http = http ?? new Lazy<HttpClient>();
        }

        public MarineTrafficApiClient(string apiKey)
        {
            this.baseUrl = "https://services.marinetraffic.com/";
            this.ApiKey = apiKey;
            this.http = new Lazy<HttpClient>();
        }

        public string BaseUrl
        {
            get { return this.baseUrl; }
        }

        public string ApiKey { get; set; }

        public async Task ExecuteAsync(IMarineTrafficRequest request, IMarineTrafficResult result)
        {
            if (this.isDisposed)
                throw new ObjectDisposedException(this.ToString());

            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.ExpectContinue = false;
            requestMessage.Headers.UserAgent.Add(new ProductInfoHeaderValue("MarineTrafficApiClient.NET", "1.0"));
            
            request.PrepareHttpMessage(this, requestMessage);

            if (requestMessage.RequestUri.OriginalString.Contains("{ApiKey}"))
            {
                requestMessage.RequestUri = new Uri(requestMessage.RequestUri.OriginalString.Replace("{ApiKey}", this.ApiKey), UriKind.Absolute);
            }

            if (requestMessage.RequestUri.OriginalString.Contains("%7BApiKey%7D"))
            {
                requestMessage.RequestUri = new Uri(requestMessage.RequestUri.OriginalString.Replace("%7BApiKey%7D", this.ApiKey), UriKind.Absolute);
            }

            try
            {
                var resultMessage = await this.http.Value.SendAsync(requestMessage);
                await result.ReadHttpMessage(resultMessage);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    if (this.http.IsValueCreated)
                    {
                        this.http.Value.Dispose();
                    }
                }

                this.isDisposed = true;
            }
        }
    }
}
