using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IType
    {
        Type CSharpType { get; }
        IProperty GetByName(IdDelimiter delimiter, string name);
        /// <summary>
        /// Null if not defined
        /// </summary>
        /// <returns></returns>
        IIndexer Indexer { get; }
        IEnumerable<IProperty> Properties { get; }
    }

    public interface IType<TType>: IType
    {        
        IProperty AddProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter);

        IIndexer AddIndexer<T1, TResult>(Func<TType, T1, TResult> getter);
        IIndexer AddIndexer<T1, T2, TResult>(Func<TType, T1, T2, TResult> getter);
        IIndexer AddIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, T3, TResult> getter);

        IMethod AddAction(IdDelimiter delimiter, string name, Action<TType> action);
        IMethod AddAction<T1>(IdDelimiter delimiter, string name, Action<TType, T1> action);
        IMethod AddAction<T1, T2>(IdDelimiter delimiter, string name, Action<TType, T1, T2> action);
        IMethod AddAction<T1, T2, T3>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3> action);
        IMethod AddAction<T1, T2, T3, T4>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4> action);
        IMethod AddAction<T1, T2, T3, T4, T5>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5> action);
        IMethod AddAction<T1, T2, T3, T4, T5, T6>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6> action);
        IMethod AddAction<T1, T2, T3, T4, T5, T6, T7>(IdDelimiter delimiter, string name, Action<TType, T1, T2, T3, T4, T5, T6, T7> action);

        IMethod AddFunction<TResult>(IdDelimiter delimiter, string name, Func<TType, TResult> func);
        IMethod AddFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, TResult> func);
        IMethod AddFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, TResult> func);
        IMethod AddFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, TResult> func);
        IMethod AddFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, TResult> func);
        IMethod AddFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, TResult> func);
        IMethod AddFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, TResult> func);
    }
}
