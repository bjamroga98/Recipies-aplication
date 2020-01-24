using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ClientAPI
{   
    /// <summary>
    /// Service for API client
    /// </summary>
    public class NetworkService
    {
        /// <summary>
        /// Client for connect
        /// </summary>
        public static HttpClient ApiClient { get; set; }
        /// <summary>
        /// method intialize client
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
