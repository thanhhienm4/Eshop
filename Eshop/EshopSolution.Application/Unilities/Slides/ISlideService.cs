using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Unilities.Slides
{
    public interface ISlideService
    {
        Task<ApiResult<List<SlideViewModel>>> GetAll();
    }
}
