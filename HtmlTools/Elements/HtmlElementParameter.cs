using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.HtmlTools.Elements
{
    public class HtmlElementParameter
    {
        public string Key;
        public string Value;

        public HtmlElementParameter(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public KeyValuePair<string,string> ToKeyValuePair()
        {
            return new KeyValuePair<string, string>(Key, Value);
        }

        public override string ToString()
        {
            return $"{Key} : {Value}";
        }
    }
}
