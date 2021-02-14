using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Utilities;
using EshopSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface ISlideApiClient
    {
        Task<List<SlideViewModel>> GetAll();
    }
}
