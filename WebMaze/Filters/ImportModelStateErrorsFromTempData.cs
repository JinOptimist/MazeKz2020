using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebMaze.Filters
{
    public class ImportModelStateErrorsFromTempData : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;

            if (controller.TempData["ModelStateErrors"] is string[] errorMessages)
            {
                if (filterContext.Result is ViewResult)
                {
                    foreach (var errorMessage in errorMessages)
                    {
                        controller.ViewData.ModelState.AddModelError(string.Empty, errorMessage);
                    }
                }
                else
                {
                    controller.TempData.Remove("ModelStateErrors");
                }
            }
        }
    }
}
