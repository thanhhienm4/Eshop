using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class SlideApiClient :BaseApiClient, ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        { }
        public async Task<List<SlideViewModel>> GetAll()
        {
            return (await GetAsync<ApiResult<List<SlideViewModel>>>("api/Slide/GetAll")).ResultObj;
        }
    }
}
