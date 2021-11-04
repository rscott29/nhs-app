using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IRequestHandler _dataService;

        public DataController(IRequestHandler dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public  List<Data> Get()
        {
           var data = _dataService.GetData();
           return data;
        }
    }
}