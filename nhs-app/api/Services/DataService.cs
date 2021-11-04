using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace api.Services
{
    public class DataService : IRequestHandler
    {
        private static IRestClient _restClient;
        public DataService()
        {
            var baseUrl = "https://api.nhs.uk/mental-health";
            _restClient = new RestClient()
            {
                BaseUrl = new Uri(baseUrl),
            };
        }

        public DataService(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public List<Data> GetData()
        {
            var request = new RestRequest { };
            request.AddHeader("subscription-key", "186bb808eec7443bbda66f7ed7a7f313");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = _restClient.Execute<List<Data>>(request);
            return response.Data;
        }
    }
}   