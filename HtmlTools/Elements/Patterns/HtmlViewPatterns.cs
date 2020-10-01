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
        public HtmlElement Element { get; set; } = HtmlElementBuilder.CreateElementA();

    }

    public class HtmlDivView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Тэг 'Div'";
        public string Description { get; set; } = "Создает элемент-контейнер";
        public HtmlElement Element { get; set; } = HtmlElementBuilder.CreateElementDiv();

    }

    public class HtmlBodyView : IHtmlElementView
    {
        public Uri Img { get; set; } = null;
        public string Name { get; set; } = "Тэг 'Body'";
        public string Description { get; set; } = "Создает элемент со ссылкой";
        public HtmlElement Element { get; set; } = HtmlElementBuilder.CreateElementBody();

    }
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


    public static class HtmlElemViewCollection
    {
        public delegate void AddItemHandler(HtmlElement element);
        public static event AddItemHandler OnAddCommand;

        public delegate void ClearDocHandler();
        public static event ClearDocHandler OnClearCommand;

        public static List<IHtmlElementView> Default()
        {
            var elements = new List<IHtmlElementView>
            {
                new CarouselView(),
                new CardView(),
            };

            return elements;
        }

        public static void OnAddCommandInvoke(HtmlElement element)
        {
            OnAddCommand?.Invoke(element);
        }

        public static void OnClearCommandInvoke()
        {
            OnClearCommand?.Invoke();
        }
    }
}