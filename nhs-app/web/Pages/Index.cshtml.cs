using System.Collections.Generic;
using api;
using api.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRequestHandler _dataService;

        public IndexModel(IRequestHandler dataService)
        {
            _dataService = dataService;
        }


        public new List<ViewModelData> ViewData { get; set; }

        public void OnGet()
        {
            ViewData = _dataService.GetData();
        }
    }
}