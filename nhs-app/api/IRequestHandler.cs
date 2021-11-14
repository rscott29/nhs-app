using System.Collections.Generic;
using api.Models;

namespace api
{
    public interface IRequestHandler
    {
        List<ViewModelData> GetData();
      
    }
}