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

        public List<HtmlElement> InnerElements { get; set; } = new List<HtmlElement>();
        public string HtmlString { get; set; }
        public string InnerText { get; set; } = "";
        public string TagName { get; set; }
        public bool HasEndTag { get; set; } = true;
        public HtmlElementParameters Parameters { get; set; } = new HtmlElementParameters();

        public HtmlElement()
        {
            Parameters.OnParametersUpdate += HtmlText_OnParametersUpdate;
        }

        public void AddInnerElement(HtmlElement elem)
        {
            InnerElements.Add(elem);
            GetHtmlString();
        }

        public HtmlElement(string htmlString, string innerText, string tagName, bool hasEndTag, HtmlElementParameters parameters = null) : base()
        {
            HtmlString = htmlString;
            InnerText = innerText;
            TagName = tagName;
            HasEndTag = hasEndTag;

            //При присвоении обновляется строка HtmlString 
            Parameters = parameters;
        }

        private void HtmlText_OnParametersUpdate(string key, object value)
        {
            if (string.IsNullOrEmpty(TagName))
                throw new NullReferenceException("TagName is null");

            GetHtmlString();
        }
        
        public string GetHtmlString()
        {
            var innerHtml = string.Join("", InnerElements.Select(elem => elem.GetHtmlString()));

            HtmlString = $@"<{TagName} {string.Join(" ", Parameters.Select(param => $"{param.Key}='{param.Value}'"))}";
            if (HasEndTag)
                HtmlString += $@">{InnerText} {innerHtml} </{TagName}>";
            else
                HtmlString += $@">";

            return HtmlString;
        }
    }
}
