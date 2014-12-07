using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FubarDev.Example.GoogleMaps
{
    public class GoogleMapsClient
    {
        private readonly RestClient _client;

        public CultureInfo Language { get; set; }

        public GoogleMapsClient(IWebProxy proxy = null)
        {
            Language = CultureInfo.CurrentCulture;
            _client = new RestClient("https://maps.googleapis.com/maps/api")
            {
                Proxy = proxy,
            };
        }

        public async Task<dynamic> GetDirections(string origin, string destination)
        {
            var request = new RestRequest("directions/{output}");
            request.AddUrlSegment("output", "json");
            request.AddParameter("language", Language.TwoLetterISOLanguageName);
            request.AddObject(new
            {
                sensor = false,
                origin = origin,
                destination = destination,
            });
            var response = await _client.Execute<dynamic>(request);
            var data = response.Data;
            return data;
        }
    }
}
