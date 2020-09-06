using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.HtmlDocument
{
    class HtmlDocCreator
    {
        public string HtmlText { get; set; } = "";
        public string DocumentName { get; set; } = "index.html";
        public string Path { get; set; } = @"C:/";

        public List<string> htmlOrderedElements = new List<string>();


        public string getHtmlText()
        {

        }
    }
}
