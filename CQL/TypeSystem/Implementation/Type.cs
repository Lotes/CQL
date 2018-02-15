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
        private Dictionary<Tuple<IdDelimiter, string>, ISymbol> symbols = new Dictionary<Tuple<IdDelimiter, string>, ISymbol>();
        private IMethod indexer = null;

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
            var key = new Tuple<IdDelimiter, string>(delimiter, Normalize(name));
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new Property(delimiter, name, (t) => getter((TType)t), (t, v) => setter((TType)t, (TProperty)v));
            return result;
        }

        public IMethod AddIndexer<T1, TResult>(Func<TType, T1, TResult> getter, Action<TType, T1, TResult> setter = null)
        {

        }

        public IMethod AddIndexer<T1, T2, TResult>(Func<TType, T1, T2, TResult> getter, Action<TType, T1, T2, TResult> setter = null)
        {
            
        }

        public IMethod AddIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, TResult> getter, Action<TType, T1, T2, T3, TResult> setter = null)
        {
            
        }

        public IMethod AddAction(IdDelimiter delimiter, string name, Action<TType> action)
        {
            
        }

        public IMethod AddAction<T1>(IdDelimiter delimiter, string name, Action<T1, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2>(IdDelimiter delimiter, string name, Action<T1, T2, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2, T3>(IdDelimiter delimiter, string name, Action<T1, T2, T3, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2, T3, T4>(IdDelimiter delimiter, string name, Action<T1, T2, T3, T4, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2, T3, T4, T5>(IdDelimiter delimiter, string name, Action<T1, T2, T3, T4, T5, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6>(IdDelimiter delimiter, string name, Action<T1, T2, T3, T4, T5, T6, TType> action)
        {
            
        }

        public IMethod AddAction<T1, T2, T3, T4, T5, T6, T7>(IdDelimiter delimiter, string name, Action<T1, T2, T3, T4, T5, T6, T7, TType> action)
        {
            
        }

        public IMethod AddFunction<TResult>(IdDelimiter delimiter, string name, Func<TType, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, TResult> func)
        {
            
        }

        public IMethod AddFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, TResult> func)
        {
            
        }

        public ISymbol GetByName(IdDelimiter delimiter, string name)
        {
            
        }
    }
}
