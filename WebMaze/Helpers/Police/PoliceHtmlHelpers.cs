using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Helpers.Police
{
    public static class PoliceHtmlHelpers
    {
        /// <summary>
        /// Создает хлебные крошки.
        /// <para>Количество аргументов должно быть НЕ четным, так как последний аргумент передается без ссылки</para>
        /// </summary>
        /// <param name="_"></param>
        /// <param name="args">Аргументы должны чередоваться 'Название' - 'Ссылка', кроме последнего.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Хлебные крошки для удобной навигации по сайту</returns>
        public static HtmlString BreadCrumb(this IHtmlHelper _, params string[] args)
        {
            if (args.Length < 1 || args.Length % 2 == 0)
            {
                throw new ArgumentException();
            }

            StringBuilder result = new StringBuilder();
            result.Append("<nav aria-label=\"breadcrumb\">");
            result.Append("<ol class=\"breadcrumb\">");
            for (int i = 0; i < args.Length - 1; i += 2)
            {
                result.Append($"<li class=\"breadcrumb-item\"><a href=\"{args[i + 1]}\">{args[i]}</a></li>");
            }

            result.Append($"<li class=\"breadcrumb-item active\" aria-current=\"page\">{args[^1]}</li>");

            result.Append("</ol>");
            result.Append("</nav>");

            return new HtmlString(result.ToString());
        }

        public static HtmlString GetValidationErrors(this IHtmlHelper html)
        {
            var result = new StringBuilder();
            result.Append("<div id=\"form-validation-errors\" style=\"display: none!important;\">");
            foreach (var key in html.ViewContext.ModelState)
            {
                foreach (var value in html.ViewContext.ModelState[key.Key].Errors)
                {
                    result.Append($"<span data-valmsg-for=\"{key.Key}\">{value.ErrorMessage}</span>");
                }
            }

            result.Append("</div>");

            return new HtmlString(result.ToString());
        }
    }
}
