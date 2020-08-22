using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products
{
    public class ApiExplorerIgnores : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.Controller.ControllerName.Equals("Pwa"))
                action.ApiExplorer.IsVisible = false;
        }
    }
}
