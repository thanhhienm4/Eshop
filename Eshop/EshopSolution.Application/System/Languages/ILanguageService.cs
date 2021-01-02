using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}