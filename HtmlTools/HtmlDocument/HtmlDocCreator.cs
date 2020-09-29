using HtmlConstructor.HtmlTools.Elements.Instances;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HtmlConstructor.HtmlTools.HtmlDocument
{
    public class HtmlDocument
    {
        public static string HtmlText { get; set; } = "";
        public string Path { get; set; }
        public string Styles { get; set; } = "";

        public HtmlDocument(string path, string stylesPath)
        {
            Path = path;

            try
            {
                HtmlText = File.ReadAllText(Path);
            } catch
            {
                File.Create(path);
            }
            
            Styles = ReadStylesFile(stylesPath);
        }

        public string ReadStylesFile(string path)
        {
            try
            {
                HtmlText = File.ReadAllText(Path);
            }
            catch
            {
                File.Create(path);
            }
            return Styles;
        }

        public string UpdateHtml(string htmlText)
        {
            HtmlText = htmlText;

            File.WriteAllText(Path, HtmlText);
            return HtmlText;
        }
    }
}
