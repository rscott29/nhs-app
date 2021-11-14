using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Mvc;

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
        public List<ViewModelData> Get()
        {
            var data = _dataService.GetData();
            return data;
        }
    }
}