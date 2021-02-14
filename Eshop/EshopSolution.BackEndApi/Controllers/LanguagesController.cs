using EshopSolution.Application.System.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _languageService.GetAll();
            return Ok(languages);
        }
    }
}