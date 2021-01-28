using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMaze.Filters
{
    public class ExportModelStateErrorsToTempData : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            
            if (!filterContext.ModelState.IsValid)
            {
                // Export only if we are redirecting to action.
                if (filterContext.Result is RedirectToActionResult)
                {
                    var errorMessages = filterContext.ModelState.Values.SelectMany(modelStateEntry => modelStateEntry.Errors.Select(b => b.ErrorMessage)).ToArray();
                    controller.TempData["ModelStateErrors"] = errorMessages;
                }
            }
        }
    }
}
