using System;
using System.Collections.Generic;
using System.Windows.Documents;
using HtmlConstructor.HtmlTools.Elements.Instances;
// ReSharper disable All

namespace HtmlConstructor.HtmlTools.Elements.Patterns
{
    public class HtmlAView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Тэг 'А'";
        public string Description { get; set; } = "Создает элемент со ссылкой";
        public HtmlElement DefaultElement { get; set; } = HtmlElementBuilder.CreateElementA();
    }

    public class HtmlDivView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Тэг 'Div'";
        public string Description { get; set; } = "Создает элемент-контейнер";
        public HtmlElement DefaultElement { get; set; } = HtmlElementBuilder.CreateElementDiv();
    }

    public class HtmlBodyView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Тэг 'Body'";
        public string Description { get; set; } = "Создает элемент со ссылкой";
        public HtmlElement DefaultElement { get; set; } = HtmlElementBuilder.CreateElementBody();
    }

    public class SlideshowView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Слайдшоу";
        public string Description { get; set; } = "";
        public HtmlElement DefaultElement { get; set; } = HtmlElementBuilder.CreateElementSlideshow();
    }

    public static class HtmlElemViewCollection
    {
        public static List<IHtmlElementView> Default()
        {
            var elements = new List<IHtmlElementView>
            {
                new SlideshowView()
            };
            return elements;
        }
    }
}