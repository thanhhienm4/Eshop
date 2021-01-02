using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.System.Languages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EshopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
       


    }
}
