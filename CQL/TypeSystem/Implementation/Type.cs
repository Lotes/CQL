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

        public IProperty AddProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new Property(delimiter, name, typeof(TProperty), (t) => getter((TType)t));
            return result;
        }

        private Tuple<IdDelimiter, string> CreateKey(IdDelimiter delimiter, string name)
        {
            return new Tuple<IdDelimiter, string>(delimiter, Normalize(name));
        }

        public IIndexer AddIndexer<T1, TResult>(Func<TType, T1, TResult> getter)
        {
            return AddAndReturnIndexer(
                getter
            );
        }

        public IIndexer AddIndexer<T1, T2, TResult>(Func<TType, T1, T2, TResult> getter)
        {
            return AddAndReturnIndexer(
                Delegate.CreateDelegate(getter.GetType(), getter.Method)
            );
        }

        public IIndexer AddIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, T3, TResult> getter)
        {
            return AddAndReturnIndexer(
                Delegate.CreateDelegate(getter.GetType(), getter.Method)
            );
        }

        
        public IMethod AddFunction<TResult>(IdDelimiter delimiter, string name, Func<TType, TResult> func)
        {
            var method = new Method<TType, TResult>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, TResult> func)
        {
            var method = new Method<TType, TResult, T1>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, TResult> func)
        {
            var method = new Method<TType, TResult, T1, T2>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, TResult> func)
        {
            var method = new Method<TType, TResult, T1, T2, T3>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, TResult> func)
        {
            var method = new Method<TType, TResult, T1, T2, T3, T4>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, TResult> func)
        {
            var method = new Method<TType, TResult, T1, T2, T3, T4, T5>(func);
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, TResult> func)
        {
            var method = new Method<TType, TResult, T1, T2, T3, T4, T5, T6>(func);
            AddMethod(delimiter, name, method);
            return method;
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
            var method = new Method<TType, Void>((t) => { action(t); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1>(IdDelimiter delimiter, string name, Action<TType, T1> action)
        {
            var method = new Method<TType, Void, T1>((t, a) => { action(t, a); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2>(IdDelimiter delimiter, string name, Action<TType, T1, T2> action)
        {
            var method = new Method<TType, Void, T1, T2>((t, a, b) => { action(t, a, b); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2, T3>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3> action)
        {
            var method = new Method<TType, Void, T1, T2, T3>((t, a, b, c) => { action(t, a, b, c); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2, T3, T4>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4> action)
        {
            var method = new Method<TType, Void, T1, T2, T3, T4>((t, a, b, c, d) => { action(t, a, b, c, d); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2, T3, T4, T5>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5> action)
        {
            var method = new Method<TType, Void, T1, T2, T3, T4, T5>((t, a, b, c, d, e) => { action(t, a, b, c, d, e); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6> action)
        {
            var method = new Method<TType, Void, T1, T2, T3, T4, T5, T6>((t, a, b, c, d, e, f) => { action(t, a, b, c, d, e, f); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6, T7>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6, T7> action)
        {
            var method = new Method<TType, Void, T1, T2, T3, T4, T5, T6, T7>((t, a, b, c, d, e, f, g) => { action(t, a, b, c, d, e, f, g); return Void.Instance; });
            AddMethod(delimiter, name, method);
            return method;
        }

        private IIndexer AddAndReturnIndexer(Delegate getter)
        {
            if(this.indexer != null)
                throw new InvalidOperationException("Duplicate indexer!"); ;
            var parameters = getter.Method.GetParameters().Select(a => a.ParameterType).Skip(1).ToArray();
            var indexer = new Indexer(parameters, getter.Method.ReturnType, getter);
            this.indexer = indexer;
            return indexer;
        }

        private void AddMethod<TMethod>(IdDelimiter delimiter, string name, TMethod method)
            where TMethod: Method
        {
            var key = CreateKey(delimiter, name);
            if(!symbols.ContainsKey(key))
            {
                AddProperty(delimiter, name, @this => method.BindThis(@this));
                return;
            }
            throw new InvalidOperationException("Duplicate symbol!"); ;
        }

        public IIndexer Indexer { get { return indexer; } }

        public IEnumerable<IProperty> Properties
        {
            get
            {
                return symbols.Values;
            }
        }
    }
}
