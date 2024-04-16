using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IDisposable.Demo
{
    public class ServiceProxy : System.IDisposable
    {
        // This field holds the HttpClient instance that will be used by this class.
        private readonly HttpClient _httpClient;

        // This flag indicates whether the object has already been disposed.
        private bool disposed = false;

        // Constructor that takes an IHttpClientFactory to create an HttpClient instance.
        public ServiceProxy(IHttpClientFactory httpClientFactory)
        {
            // Creates an HttpClient using the factory. This is a common pattern for handling
            // HttpClient instances so as to encourage re-use and proper lifecycle management.
            _httpClient = httpClientFactory.CreateClient();
        }

        // Method to perform a GET request asynchronously.
        public void Get()
        {
            // Asynchronously sends a GET request to an empty URL (""). In practice, the URL should be a valid endpoint.
            var response = _httpClient.GetAsync("");
        }

        // Method to perform a POST request asynchronously.
        public void Post(String request)
        {
            // Asynchronously sends a POST request with the provided string content to an empty URL ("").
            // In practice, the URL should be a valid endpoint and handling of the response should be considered.
            var response = _httpClient.PostAsync("", new StringContent(request));
        }

        // Destructor (finalizer) for the ServiceProxy class.
        ~ServiceProxy()
        {
            // Calls Dispose with false indicating that the object is being cleaned up by the garbage collector.
            Dispose(false);
        }

        // Public implementation of the Dispose method from the IDisposable interface.
        public void Dispose()
        {
            // Perform actual dispose operations and then suppress finalization.
            Dispose(true);
            // Prevents the garbage collector from calling the destructor.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            // Check if the object has already been disposed.
            if (disposed)
            {
                return;
            }

            // If disposing equals true, dispose all managed and unmanaged resources.
            if (disposing)
            {
                // Dispose managed resources, e.g., the HttpClient.
                _httpClient.Dispose();
            }
            // Note: If there were unmanaged resources, they could be cleaned up here.

            // Indicate that the object has been disposed.
            disposed = true;
        }
    }

}
