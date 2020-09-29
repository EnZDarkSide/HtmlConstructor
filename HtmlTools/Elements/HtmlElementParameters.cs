using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace HtmlConstructor.HtmlTools.Elements
{
    public class HtmlElementParameters : IDictionary<string, object>
    {
        public delegate void ParameterHandler(string key, object value);
        public event ParameterHandler OnParametersUpdate;

        public object this[string key]
        {
            get => Parameters.FirstOrDefault(param => param.Key == key)?.Value;
            set
            {
                var parameter = Parameters.FirstOrDefault(param => param.Key == key);

                parameter.Value = value;
            }
        }

        public HtmlElementParameters ()
        {
            OnParametersUpdate?.Invoke(null,null);
        }

        public List<HtmlElementParameter> Parameters = new List<HtmlElementParameter>();

        public ICollection<string> Keys => (ICollection<string>)Parameters.Select(param => param.Key);

        public ICollection<object> Values => (ICollection<object>)Parameters.Select(param => param.Value);

        public int Count => Parameters.Count;

        public bool IsReadOnly { get; set; }

        public void Add(string key, object value)
        {
            Parameters.Add(new HtmlElementParameter(key, value));
        }

        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
            OnParametersUpdate?.Invoke(null,null);
        }

        public void AddOrUpdate(string key, object value)
        {
            if (ContainsKey(key))
                this[key] = value;
            else
                Add(key, value);

            OnParametersUpdate?.Invoke(null, null);
        }

        public void Clear()
        {
            if (Parameters.Count != 0)
            {
                Parameters.Clear();
                OnParametersUpdate?.Invoke(null, null);
            }
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return Parameters.Any(param => param.Key == item.Key && param.Value == item.Value);
        }

        public bool ContainsKey(string key)
        {
            return Parameters.Any(param => param.Key == key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            array = Parameters.Select(param => param.ToKeyValuePair()).Skip(arrayIndex).ToArray();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return new HtmlElemParametersEnumerator(Parameters);
        }

        public bool Remove(string key)
        {
            bool isSuccessful = Parameters.Remove(Parameters.FirstOrDefault(param => param.Key == key));
            if (isSuccessful)
                OnParametersUpdate?.Invoke(null, null);

            return isSuccessful;
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            bool isSuccessful = Parameters.Remove(Parameters.FirstOrDefault(param => param.Key == item.Key && param.Value == item.Value));
            if(isSuccessful)
                OnParametersUpdate?.Invoke(null, null);

            return isSuccessful;
        }

        public bool TryGetValue(string key, out object value)
        {
            value = Parameters.FirstOrDefault(param => param.Key == key)?.Value;

            return value != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class HtmlElemParametersEnumerator : IEnumerator<KeyValuePair<string, object>>
    {
        int _position = -1;
        readonly List<HtmlElementParameter> _collection;

        public KeyValuePair<string, object> Current => new KeyValuePair<string, object>(_collection[_position].Key, _collection[_position].Value);

        object IEnumerator.Current => throw new NotImplementedException();

        public HtmlElemParametersEnumerator(List<HtmlElementParameter> collection)
        {
            _collection = collection;
        }

        public void Dispose()
        {
            _collection.Clear();
        }

        public bool MoveNext()
        {
            if (_position < _collection.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
