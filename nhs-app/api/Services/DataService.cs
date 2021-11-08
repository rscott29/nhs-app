using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using RestSharp;


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

        public List<string> GetCategories()
        {
            var request = new RestRequest { };
            request.AddHeader("subscription-key", "186bb808eec7443bbda66f7ed7a7f313");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = _restClient.Execute<List<Data>>(request);
            List<IEnumerable<string>> parts = response.Data.Select(x => x.HasPart.Select(u => u.Url.AbsolutePath))
                .ToList();
          
            List<string> catergories = new List<string>();
            foreach (var url in parts)
            {
                // removing anything that causes duplicate categories
                var partsList = url.Distinct().ToList();
                partsList.RemoveAll(i => i.Contains("treatment"));
                partsList.RemoveAll(i => i.Contains("behaviours"));
                foreach (string stringUrl in partsList)
                {
     
                    var strippedUrls = stringUrl.Split("/")[3];
                    catergories.Add(strippedUrls);
                }
            }

            return catergories;
        }
    }
}