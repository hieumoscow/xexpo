using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xexpo.Services
{

    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly string _baseAddress;
        public event EventHandler ConnectionFailed;

        public HttpService(string baseAddress)
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(15) };
        }
        private static string LangIgnoreParam(string api)
        {
            //var ret = ((api.Contains("?")) ? "&" : "?") + "lang=" +
                   //AppResources.Culture.TwoLetterISOLanguageName + "&ignore=" + DateTime.Now.Ticks;
            var ret = ((api.Contains("?")) ? "&" : "?") +"ignore=" + DateTime.Now.Ticks;
            return ret;
        }

        public async Task<string> GetAsync(string url, bool cache = false, Dictionary<string, string> headers = null)
        {
            try
            {
                url += LangIgnoreParam(url);
                //if (!NetworkInterface.GetIsNetworkAvailable())
                    //throw new NoInternetConnection();
                //TryAddAuth();
                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.IfModifiedSince = DateTimeOffset.Now;
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        msg.Headers.TryAddWithoutValidation(h.Key, h.Value);
                    }
                }
                var response = await _httpClient.SendAsync(msg, _cts.Token);
                var content = await response.Content.ReadAsStringAsync();

                    response.EnsureSuccessStatusCode();
                return content;
            }
            catch (Exception e)
            {

                ConnectionFailed?.Invoke(e, EventArgs.Empty);
                return null;
            }
        }
    }

    public class NoInternetConnection : Exception
    {
    }


}