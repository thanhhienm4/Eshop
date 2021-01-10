using EshopSolution.ViewModel.System.Languages;
using System.Collections.Generic;

namespace EshopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
        public string CurrentUrl { get; set; }
    }
}