﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ASF.UI.WbSite.Constants.ExtensionMethods
{
    public static class WebGridExtensions
    {
        public static HelperResult PagerList(
            this WebGrid webGrid,
            WebGridPagerModes mode = WebGridPagerModes.NextPrevious | WebGridPagerModes.Numeric,
            string firstText = null,
            string previousText = null,
            string nextText = null,
            string lastText = null,
            int numericLinksCount = 5,
            string paginationStyle = null)
        {
            return PagerList(webGrid, mode, firstText, previousText, nextText, lastText, numericLinksCount, paginationStyle, explicitlyCalled: true);
        }

        private static HelperResult PagerList(
            WebGrid webGrid,
            WebGridPagerModes mode,
            string firstText,
            string previousText,
            string nextText,
            string lastText,
            int numericLinksCount,
            string paginationStyle,
            bool explicitlyCalled)
        {

            var currentPage = webGrid.PageIndex;
            var totalPages = webGrid.PageCount;
            var lastPage = totalPages - 1;

            var ul = new TagBuilder("ul");
            ul.AddCssClass(paginationStyle);

            var li = new List<TagBuilder>();

            if (webGrid.TotalRowCount <= webGrid.PageCount)
            {
                return new HelperResult(writer =>
                {
                    writer.Write(string.Empty);
                });
            }

            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (string.IsNullOrEmpty(firstText))
                {
                    firstText = "First";
                }

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(0), firstText)
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (string.IsNullOrEmpty(previousText))
                {
                    previousText = "Prev";
                }

                var page = currentPage == 0 ? 0 : currentPage - 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(page), previousText)
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }


            if (ModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
            {
                var last = currentPage + (numericLinksCount / 2);
                var first = last - numericLinksCount + 1;
                if (last > lastPage)
                {
                    first -= last - lastPage;
                    last = lastPage;
                }
                if (first < 0)
                {
                    last = Math.Min(last + (0 - first), lastPage);
                    first = 0;
                }
                for (var i = first; i <= last; i++)
                {

                    var pageText = (i + 1).ToString(CultureInfo.InvariantCulture);
                    var part = new TagBuilder("li")
                    {
                        InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(i), pageText)
                    };

                    if (i == currentPage)
                    {
                        part.MergeAttribute("class", "active");
                    }

                    li.Add(part);

                }
            }

            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (string.IsNullOrEmpty(nextText))
                {
                    nextText = "Next";
                }

                var page = currentPage == lastPage ? lastPage : currentPage + 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(page), nextText)
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (string.IsNullOrEmpty(lastText))
                {
                    lastText = "Last";
                }

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(lastPage), lastText)
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            ul.InnerHtml = string.Join("", li);

            string html;
            if (explicitlyCalled && webGrid.IsAjaxEnabled)
            {
                var span = new TagBuilder("span");
                span.MergeAttribute("data-swhgajax", "true");
                span.MergeAttribute("data-swhgcontainer", webGrid.AjaxUpdateContainerId);
                span.MergeAttribute("data-swhgcallback", webGrid.AjaxUpdateCallback);

                span.InnerHtml = ul.ToString();
                html = span.ToString();

            }
            else
            {
                html = ul.ToString();
            }

            return new HelperResult(writer =>
            {
                writer.Write(html);
            });
        }

        private static string GridLink(WebGrid webGrid, string url, string text)
        {
            var builder = new TagBuilder("a");
            builder.SetInnerText(text);
            builder.MergeAttribute("href", url);
            if (webGrid.IsAjaxEnabled)
            {
                builder.MergeAttribute("data-swhglnk", "true");
            }
            return builder.ToString(TagRenderMode.Normal);
        }


        private static bool ModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }

    }
}