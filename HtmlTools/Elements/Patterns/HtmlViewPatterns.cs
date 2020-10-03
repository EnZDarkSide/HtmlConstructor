using System;
using System.Collections.Generic;
using System.Windows.Documents;
using HtmlConstructor.HtmlTools.Elements.Instances;
// ReSharper disable All

namespace HtmlConstructor.HtmlTools.Elements.Patterns
{
    public class CarouselView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Карусель";
        public string Description { get; set; } = "";

        public HtmlElement Element { get; set; } = HtmlElementBuilder.CreateElementCarousel();
    }

    public class CardView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Карточка";
        public string Description { get; set; } = "";

        public HtmlElement Element { get; set; } = HtmlElementBuilder.CreateElementCard();
    }

    public static class HtmlElementViewCollection
    {
        public static List<IHtmlElementView> Elements = new List<IHtmlElementView>()
        {
            new CardView(),
            new CarouselView(),
        };
    }
}