
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
	public partial interface IType<TType>
	{
				IMemberIndexer AddForeignIndexer<T1, TResult>(Func<TType, T1,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, TResult>(Func<TType, T1, T2,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, T3,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, TResult>(Func<TType, T1, T2, T3, T4,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, TResult>(Func<TType, T1, T2, T3, T4, T5,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, TResult>(Func<TType, T1, T2, T3, T4, T5, T6,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> getter);
				IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> getter);
		        IMemberFunction AddForeignFunction<TResult>(IdDelimiter delimiter, string name, Func<TType,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> func);
		        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> func);
			}
}     