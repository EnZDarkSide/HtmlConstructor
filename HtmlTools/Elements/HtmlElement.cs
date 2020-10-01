using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlConstructor.HtmlTools.Elements
{
    public class HtmlElement
    {
        public HtmlElement ParentElement { get; set; }

        private List<HtmlElement> innerElements = new List<HtmlElement>();
        public List<HtmlElement> InnerElements { get => innerElements; set => SetInnerElements(value); }

        private Dictionary<string, string> attributes = new Dictionary<string, string>();
        public Dictionary<string, string> Attributes { get => attributes; set => SetAttributes(value); }

        #region setters
        private void SetInnerElements(List<HtmlElement> value)
        {
            value.ForEach(elem => elem.ParentElement = this);

            innerElements = value;
            UpdateHtmlText();
        }

        private void SetAttributes(Dictionary<string, string> value)
        {
            attributes = value;
            UpdateHtmlText();
        }
        #endregion

        public string HtmlText { get; set; } = "";
        public string InnerText { get; set; } = "";
        public string TagName { get; set; }
        public bool HasEndTag { get; set; } = true;

        public void AddInnerElement(HtmlElement elem)
        {
            elem.ParentElement = this;
            InnerElements.Add(elem);
            UpdateHtmlText();
        }

        public HtmlElement(string tagName, Dictionary<string, string> attributes, bool hasEndTag = true, string htmlString = "", string innerText = "") : base()
        {
            HtmlText = htmlString;
            InnerText = innerText;
            TagName = tagName;
            HasEndTag = hasEndTag;

            Attributes = attributes;
            UpdateHtmlText();
        }

        public HtmlElement(string htmlText)
        {
            HtmlText = htmlText;
            DecomposeHtmlText(htmlText);
        }

        private void DecomposeHtmlText(string htmlText)
        {
            IHtmlDocument angle = new HtmlParser().ParseDocument(htmlText);
            foreach (IElement element in angle.Body.Children)
            {
                TagName = element.TagName;
                Attributes = GetAttributes(element.Attributes);
                InnerText = element.ChildNodes.OfType<IText>().Select(m => m.Text).FirstOrDefault();
                InnerElements = element.Children.Select(child => new HtmlElement(child.ToHtml())).ToList();
                InnerElements.ForEach(elem => elem.ParentElement = this);
            }
        }

        private Dictionary<string, string> GetAttributes(INamedNodeMap attrs)
        {
            return attrs.ToDictionary(attr => attr.Name, attr => attr.Value);
        }

        public string UpdateHtmlText()
        {
            var innerHtml = string.Join("", InnerElements.Select(elem => elem.HtmlText));
            var attributes = Attributes != null ? string.Join(" ", Attributes.Select(param => $"{param.Key}='{param.Value}'")) : null;

            HtmlText = $@"<{TagName} {attributes}";
            if (HasEndTag)
                HtmlText += $@">{InnerText}{innerHtml}</{TagName}>";
            else
                HtmlText += $@">";

            return HtmlText;
        }
    }
}
