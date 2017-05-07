using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.Metrics
{
    public static class DictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> MergeWith<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> @this, params IReadOnlyDictionary<TKey, TValue>[] others)
        {
            var keyValues = new[] { @this }.Concat(others).SelectMany(d => d);
            return keyValues.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        /// <summary>
        /// Alters a value in a dictionary. If not present it execute the action on a given default value.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="action"></param>
        /// <param name="default"></param>
        public static void AlterValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue, TValue> action, TValue @default = default(TValue))
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, action(@default));
            else
                dictionary[key] = action(dictionary[key]);
        }

        public static TValue GetValueOrInsertedDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue @default = default(TValue))
        {
            TValue result;
            if (!dictionary.TryGetValue(key, out result))
                dictionary[key] = result = @default;
            return result;
        }

        public static TValue GetValueOrInsertedLazyDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> @default)
        {
            TValue result;
            if (!dictionary.TryGetValue(key, out result))
                dictionary[key] = result = @default();
            return result;
        }

        public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, TKey key, TValue @default = default(TValue))
        {
            TValue value;
            if (_this.TryGetValue(key, out value))
                return value;
            return @default;
        }
        public static TValue GetOrLazyInsert<TKey, TValue>(this IDictionary<TKey, TValue> _this, TKey key, Func<TValue> create)
        {
            TValue value;
            if (_this.TryGetValue(key, out value))
                return value;
            return _this[key] = create();
        }
        public static TValue GetOrDefaultInsert<TKey, TValue>(this IDictionary<TKey, TValue> _this, TKey key, TValue @default = default(TValue))
        {
            TValue value;
            if (_this.TryGetValue(key, out value))
                return value;
            return _this[key] = @default;
        }
    }
}
