using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.Elements
{
    public class HtmlElement
    {
        //Добавить реверс между innerText и innerHtml

        private List<HtmlElement> innerElements = new List<HtmlElement>();

        public List<HtmlElement> InnerElements { get => innerElements; set => SetInnerElements(value); }

        private void SetInnerElements(List<HtmlElement> value)
        {
            innerElements = value;
            UpdateHtmlString();
        }

        public string HtmlString { get; set; } = "";
        public string InnerText { get; set; } = "";
        public string TagName { get; set; }
        public bool HasEndTag { get; set; } = true;
        public Dictionary<string, object> Parameters { get; set; }

        public void AddInnerElement(HtmlElement elem)
        {
            InnerElements.Add(elem);
            UpdateHtmlString();
        }

        public HtmlElement(string tagName, Dictionary<string, object> parameters, bool hasEndTag = true, string htmlString = "", string innerText = "") : base()
        {
            HtmlString = htmlString;
            InnerText = innerText;
            TagName = tagName;
            HasEndTag = hasEndTag;

            Parameters = parameters;
            UpdateHtmlString();
        }
        
        public string UpdateHtmlString()
        {
            var innerHtml = string.Join("", InnerElements.Select(elem => elem.HtmlString));
            var attributes = Parameters != null ? string.Join(" ", Parameters.Select(param => $"{param.Key}='{param.Value}'")) : null;

            HtmlString = $@"<{TagName} {attributes}";
            if (HasEndTag)
                HtmlString += $@">{InnerText} {innerHtml} </{TagName}>";
            else
                HtmlString += $@">";

            return HtmlString;
        }
    }
}
