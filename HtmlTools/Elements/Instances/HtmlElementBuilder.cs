using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.Elements.Instances
{
    static class HtmlElementBuilder
    {
        public static HtmlElement CreateElementA(string innerText, HtmlElementParameters parameters)
        {
            var result = new HtmlElement();
            result.InnerText = innerText;
            result.TagName = "a";
            result.Parameters = parameters;
            
            return result;
        }
    }
}
