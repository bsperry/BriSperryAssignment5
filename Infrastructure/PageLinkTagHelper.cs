using assignment5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Infrastructure
{
    //to help build html dynamically

    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        
        private IUrlHelperFactory urlHelperFactory;

        //constructor
        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        //tag helper for dictionary
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url")] //add to view
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        //properties for page classes
        public bool PageClasseEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //Overriding (different than overloading)
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            for (int i = 1;i <= PageModel.TotalPages; i++)
            {
                //new instance of tagbuilder
                TagBuilder tag = new TagBuilder("a");

                //make the dictionary work
                PageUrlValues["pages"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);        
                
                //for pageclass enabled
                if (PageClasseEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }


}
