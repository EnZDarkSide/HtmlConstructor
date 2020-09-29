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
        public HtmlElementParameters Parameters { get; set; } = new HtmlElementParameters();

        public void AddInnerElement(HtmlElement elem)
        {
            InnerElements.Add(elem);
            UpdateHtmlString();
        }

        public HtmlElement(string tagName, bool hasEndTag = true, HtmlElementParameters parameters = null, string htmlString = "", string innerText = "") : base()
        {
            Parameters.OnParametersUpdate += HtmlText_OnParametersUpdate;

            HtmlString = htmlString;
            InnerText = innerText;
            TagName = tagName;
            HasEndTag = hasEndTag;

            //При присвоении обновляется строка HtmlString 
            Parameters = parameters ?? new HtmlElementParameters();
            UpdateHtmlString();
        }

        private void HtmlText_OnParametersUpdate(string key, object value)
        {
            UpdateHtmlString();
        }
        
        public string UpdateHtmlString()
        {
            var innerHtml = string.Join("", InnerElements.Select(elem => elem.HtmlString));
            HtmlString = $@"<{TagName} {string.Join(" ", Parameters.Select(param => $"{param.Key}='{param.Value}'"))}";
            if (HasEndTag)
                HtmlString += $@">{InnerText} {innerHtml} </{TagName}>";
            else
                HtmlString += $@">";

            return HtmlString;
        }
    }
}
