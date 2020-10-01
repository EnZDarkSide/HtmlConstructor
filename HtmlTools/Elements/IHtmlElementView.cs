using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.Elements
{
    public interface IHtmlElementView
    {
        Uri Img {get; set;}
        string Name { get; set;}
        string Description {get; set;}
        public HtmlElement Element { get; set;}
    }
}
