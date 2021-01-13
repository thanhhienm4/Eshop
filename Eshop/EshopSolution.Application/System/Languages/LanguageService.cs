using EshopSolution.Data.EF;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Languages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly EshopDbContext _context;

        public LanguageService(EshopDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return new ApiSuccessResult<List<LanguageViewModel>>(languages);
        }
    }
}