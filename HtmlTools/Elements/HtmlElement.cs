using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.Elements
{
    public class HtmlElement
    {
        public HtmlElement _innerElement { get; set; }
        public string HtmlString { get; set; }
        public string InnerText { get; set; }
        public string TagName { get; set; }
        public bool HasEndTag { get; set; } = true;
        public HtmlElementParameters Parameters { get; set; }

        public HtmlElement()
        {
            Parameters.OnParametersUpdate += Parameters_OnParametersUpdate;
        }

        public HtmlElement(string htmlString, string innerText, string tagName, bool hasEndTag, HtmlElementParameters parameters = null) : base()
        {
            HtmlString = htmlString;
            InnerText = innerText;
            TagName = tagName;
            HasEndTag = hasEndTag;
            Parameters = parameters;
        }

        void Parameters_OnParametersUpdate(string key, object value)
        {
            if (string.IsNullOrEmpty(TagName))
                throw new NullReferenceException("TagName is null");

            RebuildHtmlString();
        }
        
        void RebuildHtmlString()
        {
            HtmlString = $@"<{TagName} {string.Join(" ", Parameters.Select(param => $"{param.Key}='{param.Value}'"))}>{InnerText}";
            if (HasEndTag)
                HtmlString += $@"</{TagName}>";
        }
    }
}
