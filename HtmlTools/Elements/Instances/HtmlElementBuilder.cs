using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace HtmlConstructor.HtmlTools.Elements.Instances
{
    //Ответсвтенность - создание элементов по-умолчанию
    static class HtmlElementBuilder
    {
        public static HtmlElement CreateElementA(Dictionary<string, string> attributes = null, string innerText = "")
        {
            var result = new HtmlElement("a", attributes, true, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementDiv(Dictionary<string, string> attributes = null, string innerText = "")
        {
            var result = new HtmlElement("div", attributes, true, innerText: innerText);

            return result;
        }

        public static HtmlElement CreateElementBody(string innerText = "")
        {
            var result = new HtmlElement("body", null);

            return result;
        }

        public static HtmlElement CreateElementImg(string src = "")
        {
            var attributes = new Dictionary<string, string>()
            {
                { "src", src }
            };

            var result = new HtmlElement("img", attributes, false);

            return result;
        }

        public static HtmlElement CreateElementCarousel()
        {
            var result = new HtmlElement(File.ReadAllText($@"{Constants.WwwDirectory}/patterns/carousel.html"));
            return result;
        }

        public static HtmlElement CreateElementCard()
        {
            var result = new HtmlElement(File.ReadAllText($@"{Constants.WwwDirectory}/patterns/card.html"));
            return result;
        }

        public static HtmlElement CreateElementHead()
        {
            var result = new HtmlElement(File.ReadAllText($@"{Constants.WwwDirectory}/patterns/head.html"));
            return result;
        }
    }
}
