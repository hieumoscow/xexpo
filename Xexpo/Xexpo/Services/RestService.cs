using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Xexpo.Services
{
    public class RestService
    {
        private readonly HttpService _httpService;
        private static RestService _current;
        public static RestService Current => _current ?? (_current = new RestService());

        public RestService()
        {
            _httpService = new HttpService("");

        }

        public async Task<string> GetXamlAsync(string url)
        {
            var resp = await _httpService.GetAsync(url);
            return resp;
        }
    }
}
