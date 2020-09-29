using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace HtmlConstructor.HtmlTools.Elements.Instances
{
    //Ответсвтенность - создание элементов по-умолчанию
    static class HtmlElementBuilder
    {
        public static HtmlElement CreateElementA(HtmlElementParameters parameters = null, string innerText = "")
        {
            var result = new HtmlElement
            {
                InnerText = innerText,
                TagName = "a",
                Parameters = parameters ?? new HtmlElementParameters()
            };

            return result;
        }

        public static HtmlElement CreateElementDiv(HtmlElementParameters parameters = null, string innerText = "")
        {
            var result = new HtmlElement
            {
                InnerText = innerText,
                TagName = "div",
                Parameters = parameters ?? new HtmlElementParameters()
            };

            return result;
        }

        public static HtmlElement CreateElementBody(string innerText = "")
        {
            var result = new HtmlElement
            {
                InnerText = innerText,
                TagName = "body",
            };

            return result;
        }

        public static HtmlElement CreateElementImg(string src = "")
        {
            var result = new HtmlElement()
            {
                TagName = "img",
                HasEndTag = false,
                Parameters = new HtmlElementParameters()
                {
                    { "src", src }
                }
            };

            return result;
        }

        internal static HtmlElement CreateElementSlideshow()
        {
            var parameters = new HtmlElementParameters
            {
                { "class", "wrapper" }
            };

            var result = CreateElementDiv(parameters);

            result.InnerElements = new List<HtmlElement>()
            {
                CreateElementImg(@"./images\img_lights_wide.jpg"),
                CreateElementImg(@"./images\img_mountains_wide.jpg"),
                CreateElementImg(@"./images\img_nature_wide.jpg"),
                CreateElementImg(@"./images\img_snow_wide.jpg"),
            };

            return result;
        }

        public static HtmlElement CreateElementHead()
        {
            var result = new HtmlElement
            {
                TagName = "body",
            };

            result.AddInnerElement(new HtmlElement()
            {
                TagName = "link",
                HasEndTag = false,
                Parameters = new HtmlElementParameters()
                { {"rel", "stylesheet" }, { "href", "styles.css" }, { "type", "text/css" } }
            });

            return result;
        }
    }
}
