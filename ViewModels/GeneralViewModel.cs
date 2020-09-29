using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
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

        public GeneralViewModel()
        {
            InitializeBrowser();
        }

        public void InitializeBrowser()
        {
            HtmlElements = HtmlElemViewCollection.Default();

            Doc = new HtmlDocument($@"{Constants.WwwDirectory}/index.html", $@"{Constants.WwwDirectory}/styles.css");

            var head = HtmlElementBuilder.CreateElementHead();
            var body = HtmlElementBuilder.CreateElementBody();

            var slideshow = HtmlElementBuilder.CreateElementSlideshow();

            body.AddInnerElement(slideshow);

            var htmlString = $"{head.HtmlString} {body.HtmlString}";

            Doc.UpdateHtml(htmlString);
        }
    }
}