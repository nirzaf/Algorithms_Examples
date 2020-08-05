using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Extensions
{
    public static class Extension_Methods
    {
        public static TValue GetValueOrDefault<TKey, TValue>
                        (this IDictionary<TKey, TValue> dictionary,
                         TKey key,
                         TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary,
             TKey key,
             Func<TValue> defaultValueProvider)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value
                 : defaultValueProvider();
        }
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
                where TValue : new()
        {
            TValue val;

            if (!dict.TryGetValue(key, out val))
            {
                val = new TValue();
                dict.Add(key, val);
            }

            return val;
        }
    }
}
