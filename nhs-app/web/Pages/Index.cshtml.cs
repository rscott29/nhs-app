using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRequestHandler _dataService;
        public List<Data> Data { get; set; }
        public  List<string> Categories { get; set; }


        public IndexModel(IRequestHandler dataService)
        {
            _dataService = dataService;
        }

        public void OnGet()
        {
 
            Data = _dataService.GetData();
            Categories = _dataService.GetCategories();


        }
    }
}