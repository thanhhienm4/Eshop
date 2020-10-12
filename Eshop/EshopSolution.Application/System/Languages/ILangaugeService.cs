using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Languages
{
    interface ILangaugeService
    {
        Task<ApiResult<LanguageViewModel>> GetAll();
    }
}
