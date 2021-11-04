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
      

        public IndexModel(IRequestHandler dataService)
        {
            _dataService = dataService;
          
        }

        public void OnGet()
        {
         //   x = ViewData["Categories"]


            Data = _dataService.GetData();
            var hasPart = Data.Select(item => item.HasPart).ToList();
            var urls = hasPart.Select(x => x.Select(p => p.Url.AbsolutePath.ToString())).ToList();
        
        }
        
        
    }
}