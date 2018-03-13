using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    public partial class Type<TType>
    {
		/// <summary>
        /// Add a indexer using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		public IMemberIndexer AddForeignIndexer<T1, TResult>(Func<TType, T1,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		public IMemberIndexer AddForeignIndexer<T1, T2, TResult>(Func<TType, T1, T2,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, TResult>(Func<TType, T1, T2, T3,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, TResult>(Func<TType, T1, T2, T3, T4,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="getter"></param>
        /// <returns></returns>
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, TResult>(Func<TType, T1, T2, T3, T4, T5,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, TResult>(Func<TType, T1, T2, T3, T4, T5, T6,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a indexer using a lambda function.
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
		public IMemberIndexer AddForeignIndexer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> getter)
		{
            return AddAndReturnIndexer(getter);
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public IMemberFunction AddForeignFunction<TResult>(IdDelimiter delimiter, string name, Func<TType,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public IMemberFunction AddForeignFunction<T1, TResult>(IdDelimiter delimiter, string name, Func<TType, T1,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public IMemberFunction AddForeignFunction<T1, T2, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="TResult"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public IMemberFunction AddForeignFunction<T1, T2, T3, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
		/// <summary>
        /// Add a lambda function as foreign member function to a type.
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
		public IMemberFunction AddForeignFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,  TResult> func)
		{
            var method = new ForeignMemberFunction<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func);
            AddMemberFunction(delimiter, name, method);
            return method;
        }
			}
}