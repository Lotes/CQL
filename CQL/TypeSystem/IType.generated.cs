
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// A registered type in the type system, representing a C# native type.
    /// </summary>
    /// <typeparam name="TType">the native type</typeparam>
	public partial interface IType<TType>
	{
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, TResult>(Func<TType, T1,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, TResult>(Func<TType, T1, T2,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, T3,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, TResult>(Func<TType, T1, T2, T3, T4,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, TResult>(Func<TType, T1, T2, T3, T4, T5,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, TResult>(Func<TType, T1, T2, T3, T4, T5, T6,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> getter);
		
		/// <summary>
        /// Adds an foreign indexer by adding a lambda function to get the value.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="T15"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> getter);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<TResult>(IdDelimiter delimiter, string name, Func<TType,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> func);
		/// <summary>
        /// Adds a foreign function to the type by a given lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="T15"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> func);
			}
}     