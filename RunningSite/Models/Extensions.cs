using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace RunningSite.Models
{
    public static class Extensions
    {
        public static HtmlString NavigationLink(this HtmlHelper html, string linkText, string actionName, string controllerName)
        {
            //FROM: https://stackoverflow.com/questions/9289909/asp-net-mvc-current-page-highlighting-in-navigation

            string contextAction = (string)html.ViewContext.RouteData.Values["action"];
            string contextController = (string)html.ViewContext.RouteData.Values["controller"];

            bool isCurrent =
                string.Equals(contextAction, actionName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(contextController, controllerName, StringComparison.CurrentCultureIgnoreCase);

            return html.ActionLink(
                linkText,
                actionName,
                controllerName,
                routeValues: null,
                htmlAttributes: isCurrent ? new { @class = "current" } : null);
        }


        public static MvcHtmlString ActionLinkInnerHtml(this HtmlHelper helper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues = null, IDictionary<string, object> htmlAttributes = null, string leftInnerHtml = null, string rightInnerHtml = null)
        {
            //FROM: https://stackoverflow.com/questions/1974980/putting-html-inside-html-actionlink-plus-no-link-text

            // CONSTRUCT THE URL
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName: actionName, controllerName: controllerName, routeValues: routeValues);

            // CREATE AN ANCHOR TAG BUILDER
            var builder = new TagBuilder("a");
            builder.InnerHtml = string.Format("{0}{1}{2}", leftInnerHtml, linkText, rightInnerHtml);
            builder.MergeAttribute(key: "href", value: url);

            // ADD HTML ATTRIBUTES
            builder.MergeAttributes(htmlAttributes, replaceExisting: true);

            // BUILD THE STRING AND RETURN IT
            var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
            return mvcHtmlString;
        }


        public static MvcHtmlString ActionLinkInnerHtmlNav(this HtmlHelper helper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues = null, IDictionary<string, object> htmlAttributes = null, string leftInnerHtml = null, string rightInnerHtml = null)
        {
            // CONSTRUCT THE URL
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName: actionName, controllerName: controllerName, routeValues: routeValues);

            // CREATE AN ANCHOR TAG BUILDER
            var builder = new TagBuilder("a");
            builder.InnerHtml = string.Format("{0}{1}{2}", leftInnerHtml, linkText, rightInnerHtml);
            builder.MergeAttribute(key: "href", value: url);

            // ADD HTML ATTRIBUTES
            builder.MergeAttributes(htmlAttributes, replaceExisting: true);

            string contextAction = (string)helper.ViewContext.RouteData.Values["action"];
            string contextController = (string)helper.ViewContext.RouteData.Values["controller"];

            //ADD CSS CLASS IF CURRENT PAGE
            bool isCurrent =
                string.Equals(contextAction, actionName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(contextController, controllerName, StringComparison.CurrentCultureIgnoreCase);

            if (isCurrent)
            {
                //builder.MergeAttributes(new { @class = "current" }, replaceExisting: false);
                builder.AddCssClass("current");
            }

            // BUILD THE STRING AND RETURN IT
            var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
            return mvcHtmlString;
        }
    }
        
}
