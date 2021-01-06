using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.Utilities;
using EshopSolution.ViewModel.Utilities.Slides;
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
