using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// The default implementation of <see cref="IType{TType}"/>
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public partial class Type<TType> : IType<TType>
    {
        private static Action<Type<TType>, Type, IdDelimiter, string, IMemberFunction>
            addMemberFunction = null;

        static Type()
        {
            var genericType = typeof(Type<TType>);
            var method = genericType.GetMethod("AddMemberFunction", BindingFlags.Instance | BindingFlags.NonPublic);
            addMemberFunction = (@this, functionType, delimiter, name, function) =>
            {
                var genericMethod = method.MakeGenericMethod(functionType);
                genericMethod.Invoke(@this, new object[] { delimiter, name, function });
            };
        }

        private Dictionary<Tuple<IdDelimiter, string>, IProperty> symbols = new Dictionary<Tuple<IdDelimiter, string>, IProperty>();
        private IMemberIndexer indexer = null;

        /// <summary>
        /// Create a new type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        public Type(string name, string usage)
        {
            Name = name;
            Usage = usage;
            NativeType = typeof(TType);
        }

        /// <summary>
        /// Name under which the native type was registered.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Usage documentation of this type.
        /// </summary>
        public string Usage { get; private set; }

        /// <summary>
        /// The CSharp type.
        /// </summary>
        public System.Type NativeType { get; private set; }

        private string Normalize(string str)
        {
            return str.ToUpper();
        }

        /// <summary>
        /// Adds a lambda function to create a foreign property.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
        public IProperty AddForeignProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new ForeignProperty(delimiter, name, typeof(TProperty), (t) => getter((TType)t));
            return result;
        }

        private Tuple<IdDelimiter, string> CreateKey(IdDelimiter delimiter, string name)
        {
            return new Tuple<IdDelimiter, string>(delimiter, Normalize(name));
        }

        /// <summary>
        /// Get a property by its name and delimiter.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IProperty GetByName(IdDelimiter delimiter, string name)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.TryGetValue(key, out IProperty symbol))
            {
                return symbol;
            }

            return null;
        }

        private IMemberIndexer AddAndReturnIndexer(Delegate getter)
        {
            if(this.indexer != null)
                throw new InvalidOperationException("Duplicate indexer!");
            var parameters = getter.Method.GetParameters()
                .SkipWhile(p => p.ParameterType.Namespace.StartsWith("System.Runtime.CompilerServices"))
                .Skip(1)
                .Select(a => a.ParameterType)
                .ToArray();
            var indexer = new ForeignIndexer(parameters, getter.Method.ReturnType, getter);
            this.indexer = indexer;
            return indexer;
        }

        private void AddMemberFunction<TMemberFunction>(IdDelimiter delimiter, string name, TMemberFunction method)
            where TMemberFunction: IMemberFunction
        {
            var key = CreateKey(delimiter, name);
            if(!symbols.ContainsKey(key))
            {
                AddForeignProperty(delimiter, name, @this => method.BindThis(@this));
                return;
            }
            throw new InvalidOperationException("Duplicate symbol!"); ;
        }

        /// <summary>
        /// Adds a native function. The function must be a MethodInfo of a real method of the native type.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public IMemberFunction AddNativeFunction(IdDelimiter delimiter, string name, MethodInfo methodInfo)
        {
            var func = NativeMemberFunctionExtensions.CreateByMethodInfo(typeof(TType), methodInfo);
            addMemberFunction(this, func.GetType(), delimiter, name, func);
            return func;
        }
        
        /// <summary>
        /// Adds a native MethodInfo which is a real method of the native type.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public IProperty AddNativeProperty(IdDelimiter delimiter, string name, PropertyInfo propertyInfo)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new NativeProperty(name, propertyInfo);
            return result;
        }

        /// <summary>
        /// Adds a real indexer property of the native type.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public IMemberIndexer AddNativeIndexer(PropertyInfo propertyInfo)
        {
            if (this.indexer != null)
                throw new InvalidOperationException("Duplicate indexer!");
            return this.indexer = new NativeIndexer(propertyInfo);
        }

        /// <summary>
        /// Returns the registered indexer of this type, or null.
        /// </summary>
        public IMemberIndexer Indexer { get { return indexer; } }
        /// <summary>
        /// Returns all members of this type.
        /// </summary>
        public IEnumerable<IProperty> Members { get { return symbols.Values; } }
    }
}
