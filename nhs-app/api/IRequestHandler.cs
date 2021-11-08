using System.Collections.Generic;
using RestSharp;

namespace api
{
    public interface IRequestHandler
    {
        List<Data> GetData();
        List<string> GetCategories();
    }
}