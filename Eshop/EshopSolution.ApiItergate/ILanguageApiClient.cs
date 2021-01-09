using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}