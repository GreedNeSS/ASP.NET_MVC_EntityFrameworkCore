﻿using _8_PaginationTagHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _8_PaginationTagHelper.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory factory)
        {
            urlHelperFactory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;
        public PageViewModel? PageModel { get; set; }
        public string PageAction { get; set; } = string.Empty;

        private TagBuilder CreateTag(IUrlHelper urlHelper, int pageNumber = 1)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");

            if (pageNumber == PageModel?.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            }

            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel == null)
            {
                throw new Exception("PageModel is not set");
            }

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");
            TagBuilder currentItem = CreateTag(urlHelper, PageModel.PageNumber);

            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(urlHelper, PageModel.PageNumber - 1);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            tag.InnerHtml.AppendHtml(currentItem);

            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(urlHelper, PageModel.PageNumber + 1);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            output.Content.AppendHtml(tag);
        }
    }
}
