using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using HtmlConstructor.Data;
using HtmlConstructor.HtmlTools.Elements;
using HtmlConstructor.HtmlTools.Elements.Instances;
using HtmlConstructor.HtmlTools.Elements.Patterns;
using HtmlConstructor.HtmlTools.HtmlDocument;

namespace HtmlConstructor.ViewModels
{
    public class GeneralViewModel : ViewModelBase
    {
        public HtmlDocument Doc { get; set; }
        public List<IHtmlElementView> HtmlElements { get; set; }

        HtmlElement Head = HtmlElementBuilder.CreateElementHead();
        HtmlElement Body = HtmlElementBuilder.CreateElementBody();

        public GeneralViewModel()
        {
            InitializeBrowser();
        }

        public void InitializeBrowser()
        {
            HtmlElements = HtmlElementViewCollection.Elements;

            DataTransferAssistant.OnAddCommand += AddCommand;
            DataTransferAssistant.OnClearCommand += ClearCommand;

            Doc = new HtmlDocument($@"{Constants.WwwDirectory}/index.html");
        }

        private void ClearCommand()
        {
            Doc.UpdateHtml("");
        }
         
        private void AddCommand(HtmlElement element)
        {
            Body.AddInnerElement(element);
            UpdateHtml();
        }

        public void UpdateHtml()
        {
            var htmlString = $"{Head.HtmlText} {Body.HtmlText}";
            Doc.UpdateHtml(htmlString);
        }
    }
}