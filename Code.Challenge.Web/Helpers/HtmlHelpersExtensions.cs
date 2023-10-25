using Application.Core.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Code.Challenge.Web.Helpers
{
    public static class HtmlHelpersExtensions
    {
        public static HtmlString ShowNotifications<TModel>(this IHtmlHelper<TModel> helper, List<FlashMessage> messages)
        {
            StringBuilder sb = new();

            sb.Append("<script type=\"text/javascript\">$(function(){");
            if (messages != null)
            {
                foreach (var message in messages)
                {
                    sb.Append(@$"Swal.fire({{
                                  icon: '{message.Type.ToString().ToLower()}',
                                  title: '{message.Title}',
                                  text: '{message.Body}',
                                  showConfirmButton: true
                                }})");
                }
            }
            sb.Append("})</script>");

            return new HtmlString(sb.ToString());
        }
    }
}
