using MainCore.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public class FunctionSet : IFunctionSet
    {
        private Dictionary<string, Func<object>> zeroFunctions = new Dictionary<string, Func<object>>();
        private Dictionary<string, Dictionary<Type, Func<object, object>>> oneFunctions = new Dictionary<string, Dictionary<Type, Func<object, object>>>();
        private Dictionary<string, Dictionary<Type, Dictionary<Type, Func<object, object, object>>>> twoFunctions = new Dictionary<string, Dictionary<Type, Dictionary<Type, Func<object, object, object>>>>();
        private Dictionary<string, Dictionary<Type, Dictionary<Type, Dictionary<Type, Func<object, object, object, object>>>>> threeFunctions = new Dictionary<string, Dictionary<Type, Dictionary<Type, Dictionary<Type, Func<object, object, object, object>>>>>();

        public void Add<TResult>(string name, Func<TResult> func)
        {
            name = name.ToLower();
            if (Get(name) != null)
                throw new InvalidOperationException("Such a function already exists!");
            zeroFunctions.Add(name, () => func());
        }
        public void Add<TArg1, TResult>(string name, Func<TArg1, TResult> func)
        {
            name = name.ToLower();
            if (Get<TArg1>(name) != null)
                throw new InvalidOperationException("Such a function already exists!");
            oneFunctions.GetValueOrInsertedLazyDefault(name, () => new Dictionary<Type, Func<object, object>>())
                [typeof(TArg1)] = a => func((TArg1)a);
        }
        public void Add<TArg1, TArg2, TResult>(string name, Func<TArg1, TArg2, TResult> func)
        {
            name = name.ToLower();
            if (Get<TArg1, TArg2>(name) != null)
                throw new InvalidOperationException("Such a function already exists!");
            twoFunctions.GetValueOrInsertedLazyDefault(name, () => new Dictionary<Type, Dictionary<Type, Func<object, object, object>>>())
                .GetValueOrInsertedLazyDefault(typeof(TArg1), () => new Dictionary<Type, Func<object, object, object>>())
                [typeof(TArg2)] = (a, b) => func((TArg1)a, (TArg2)b);
        }
        public void Add<TArg1, TArg2, TArg3, TResult>(string name, Func<TArg1, TArg2, TArg3, TResult> func)
        {
            name = name.ToLower();
            if (Get<TArg1, TArg2, TArg3>(name) != null)
                throw new InvalidOperationException("Such a function already exists!");
            threeFunctions.GetValueOrInsertedLazyDefault(name, () => new Dictionary<Type, Dictionary<Type, Dictionary<Type, Func<object, object, object, object>>>>())
                .GetValueOrInsertedLazyDefault(typeof(TArg1), () => new Dictionary<Type, Dictionary<Type, Func<object, object, object, object>>>())
                .GetValueOrInsertedLazyDefault(typeof(TArg2), () => new Dictionary<Type, Func<object, object, object, object>>())
                [typeof(TArg3)] = (a, b, c) => func((TArg1)a, (TArg2)b, (TArg3)c);
        }

        public Func<object> Get(string name)
        {
            name = name.ToLower();
            if (zeroFunctions.ContainsKey(name))
                return zeroFunctions[name];
            return null;
        }

        public Func<object, object> Get<TArg1>(string name)
        {
            name = name.ToLower();
            if (oneFunctions.ContainsKey(name) && oneFunctions[name].ContainsKey(typeof(TArg1)))
                return oneFunctions[name][typeof(TArg1)];
            return null;
        }

        public Func<object, object, object> Get<TArg1, TArg2>(string name)
        {
            name = name.ToLower();
            if (twoFunctions.ContainsKey(name) && twoFunctions[name].ContainsKey(typeof(TArg1)) && twoFunctions[name][typeof(TArg1)].ContainsKey(typeof(TArg2)))
                return twoFunctions[name][typeof(TArg1)][typeof(TArg2)];
            return null;
        }

        public Func<object, object, object, object> Get<TArg1, TArg2, TArg3>(string name)
        {
            name = name.ToLower();
            if (threeFunctions.ContainsKey(name) && threeFunctions[name].ContainsKey(typeof(TArg1)) && threeFunctions[name][typeof(TArg1)].ContainsKey(typeof(TArg2)) && threeFunctions[name][typeof(TArg1)][typeof(TArg2)].ContainsKey(typeof(TArg3)))
                return threeFunctions[name][typeof(TArg1)][typeof(TArg2)][typeof(TArg3)];
            return null;
        }
    }
}
