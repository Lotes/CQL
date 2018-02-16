using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    public class Type<TType> : IType<TType>
    {
        private Dictionary<Tuple<IdDelimiter, string>, IProperty> symbols = new Dictionary<Tuple<IdDelimiter, string>, IProperty>();
        private IIndexer indexer = null;

        public Type(string name, string usage)
        {
            Name = name;
            Usage = usage;
            CSharpType = typeof(TType);
        }

        public string Name { get; private set; }
        public string Usage { get; private set; }
        public System.Type CSharpType { get; private set; }

        private string Normalize(string str)
        {
            return str.ToUpper();
        }

        public IProperty AddProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter, Action<TType, TProperty> setter = null)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new Property(delimiter, name, typeof(TProperty), (t) => getter((TType)t), (t, v) => setter((TType)t, (TProperty)v));
            return result;
        }

        private Tuple<IdDelimiter, string> CreateKey(IdDelimiter delimiter, string name)
        {
            return new Tuple<IdDelimiter, string>(delimiter, Normalize(name));
        }

        public IIndexer AddIndexer<T1, TResult>(Func<TType, T1, TResult> getter, Action<TType, T1, TResult> setter = null)
        {
            return AddAndReturnIndexer(
                Delegate.CreateDelegate(getter.GetType(), getter.Method),
                Delegate.CreateDelegate(setter.GetType(), setter.Method)
            );
        }

        public IIndexer AddIndexer<T1, T2, TResult>(Func<TType, T1, T2, TResult> getter, Action<TType, T1, T2, TResult> setter = null)
        {
            return AddAndReturnIndexer(
                Delegate.CreateDelegate(getter.GetType(), getter.Method),
                Delegate.CreateDelegate(setter.GetType(), setter.Method)
            );
        }

        public IIndexer AddIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, TResult> getter, Action<TType, T1, T2, T3, TResult> setter = null)
        {
            return AddAndReturnIndexer(
                Delegate.CreateDelegate(getter.GetType(), getter.Method),
                Delegate.CreateDelegate(setter.GetType(), setter.Method)
            );
        }

        
        public IMethod AddFunction<TResult>(IdDelimiter delimiter, string name, Func<TType, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(func.GetType(), func.Method));
        }

        public IProperty GetByName(IdDelimiter delimiter, string name)
        {
            var key = CreateKey(delimiter, name);
            IProperty symbol = null;
            if (symbols.TryGetValue(key, out symbol))
                return symbol;
            return null;
        }

        public IMethod AddAction(IdDelimiter delimiter, string name, Action<TType> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1>(IdDelimiter delimiter, string name, Action<TType, T1> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2>(IdDelimiter delimiter, string name, Action<TType, T1, T2> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2, T3>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2, T3, T4>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2, T3, T4, T5>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6, T7>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6, T7> action)
        {
            return AddAndReturnMethod(delimiter, name, Delegate.CreateDelegate(action.GetType(), action.Method));
        }

        private IIndexer AddAndReturnIndexer(Delegate getter, Delegate setter)
        {
            if(this.indexer != null)
                throw new InvalidOperationException("Duplicate indexer!"); ;
            var parameters = getter.Method.GetParameters().Select(a => a.ParameterType).Skip(1).ToArray();
            var indexer = new Indexer(parameters, getter.Method.ReturnType, getter, setter);
            this.indexer = indexer;
            return indexer;
        }

        private IMethod AddAndReturnMethod(IdDelimiter delimiter, string name, Delegate @delegate)
        {
            var parameters = @delegate.Method.GetParameters().Select(a => a.ParameterType).Skip(1).ToArray();
            var method = new Method(delimiter, name, parameters, @delegate.Method.ReturnType, @delegate);
            var key = CreateKey(delimiter, name);
            if(!symbols.ContainsKey(key))
            {
                symbols.Add(key, method);
                return method;
            }
            throw new InvalidOperationException("Duplicate symbol!"); ;
        }

        public IIndexer Indexer
        {
            get
            {
                return indexer;
            }
        }

        public IEnumerable<IProperty> Members
        {
            get
            {
                return symbols.Values;
            }
        }
    }
}
