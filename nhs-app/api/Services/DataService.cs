using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using api.Models;
using RestSharp;

namespace api.Services
{
    public class DataService : IRequestHandler
    {
        private static IRestClient _restClient;
        List<ViewModelData> dataViewModel = new List<ViewModelData>();
        public DataService()
        {
            var baseUrl = "https://api.nhs.uk/mental-health";
            _restClient = new RestClient
            {
                BaseUrl = new Uri(baseUrl)
            };
        }

        public DataService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public List<ViewModelData> GetData()
        {
            var request = new RestRequest();
            request.AddHeader("subscription-key", "186bb808eec7443bbda66f7ed7a7f313");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = _restClient.Execute<List<Data>>(request);
            var viewData = response.Data.SelectMany(d => d.HasPart).ToList();
            var parts = response.Data.Select(x => x.HasPart.Select(u => u.Url.AbsolutePath.ToString())).ToList();


            var categories = new List<string>();
            List<string> partsList = new List<string>(); 
        
            string uri = "";
           
            foreach (var url in parts)
            {
                // removing anything that causes duplicate categories
                partsList = url.Distinct().ToList();
                partsList.RemoveAll(i => i.Contains("treatment"));
                partsList.RemoveAll(i => i.Contains("behaviours"));
                foreach (var stringUrl in partsList)
                {
                    var strippedUrls = stringUrl.Split("/")[3];
                    categories.Add(strippedUrls);
                    
                }
            }

            var textList = viewData.SelectMany(x => x.HasPart.Select(y => y.Text)).ToList();

            foreach (string url in partsList)
            {
                uri = url;
            }
            foreach (var category in categories)
        
            {
                
                var deHyphened = category.Replace("-", " ");
                var groupedText = textList.Where(c => c.Contains(deHyphened));
                var joinedText = string.Join(", ", groupedText).Trim().Replace(",", "");
                
                CreateViewObject(category, joinedText, uri);
            }

            return dataViewModel;
            
        }

        private List<ViewModelData> CreateViewObject(string category, string joinedText, string urls) {
            
             dataViewModel.Add(new ViewModelData
            {
                Catergory = category,
                Text = joinedText,
                Url =  urls
            });
             return dataViewModel;
        }

    }
    
}