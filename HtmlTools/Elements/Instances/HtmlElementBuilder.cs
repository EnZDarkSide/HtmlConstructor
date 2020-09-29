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
            var result = new HtmlElement("a", true, parameters, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementDiv(HtmlElementParameters parameters = null, string innerText = "")
        {
            var result = new HtmlElement("div", true, parameters, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementBody(string innerText = "")
        {
            var result = new HtmlElement("body", true, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementImg(string src = "")
        {
            var parameters = new HtmlElementParameters()
            {
                { "src", src }
            };

            var result = new HtmlElement("img", false, parameters);

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
            var result = new HtmlElement("head");

            var parameters = new HtmlElementParameters()
                { {"rel", "stylesheet" }, { "href", "styles.css" }, { "type", "text/css" } };

            result.AddInnerElement(new HtmlElement("link", false, parameters));

            return result;
        }
    }
}
