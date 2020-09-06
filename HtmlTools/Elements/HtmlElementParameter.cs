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
        public object Value;

        public HtmlElementParameter(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public KeyValuePair<string,object> ToKeyValuePair()
        {
            return new KeyValuePair<string, object>(Key, Value);
        }

        public override string ToString()
        {
            return $"{Key} : {Value}";
        }
    }
}
