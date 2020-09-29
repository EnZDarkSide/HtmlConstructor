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
        public static HtmlElement CreateElementA(Dictionary<string,object> parameters = null, string innerText = "")
        {
            var result = new HtmlElement("a", parameters, true, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementDiv(Dictionary<string,object> parameters = null, string innerText = "")
        {
            var result = new HtmlElement("div", parameters, true, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementBody(string innerText = "")
        {
            var result = new HtmlElement("body", null);

            return result;
        }

        public static HtmlElement CreateElementImg(string src = "")
        {
            var parameters = new Dictionary<string,object>()
            {
                { "src", src }
            };

            var result = new HtmlElement("img", parameters, false);

            return result;
        }

        internal static HtmlElement CreateElementSlideshow()
        {
            var parameters = new Dictionary<string, object>
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
            var result = new HtmlElement("head", null);

            var parameters = new Dictionary<string,object>()
                { {"rel", "stylesheet" }, { "href", "styles.css" }, { "type", "text/css" } };

            result.AddInnerElement(new HtmlElement("link", parameters, false));

            return result;
        }
    }
}
