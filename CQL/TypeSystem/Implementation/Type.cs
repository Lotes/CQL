using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
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

        public IProperty GetByName(IdDelimiter delimiter, string name)
        {
            var key = CreateKey(delimiter, name);
            IProperty symbol = null;
            if (symbols.TryGetValue(key, out symbol))
                return symbol;
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

        public IMemberFunction AddNativeFunction(IdDelimiter delimiter, string name, MethodInfo methodInfo)
        {
            var func = NativeMemberFunctionExtensions.CreateByMethodInfo(typeof(TType), methodInfo);
            addMemberFunction(this, func.GetType(), delimiter, name, func);
            return func;
        }
        
        public IProperty AddNativeProperty(IdDelimiter delimiter, string name, PropertyInfo propertyInfo)
        {
            var key = CreateKey(delimiter, name);
            if (symbols.ContainsKey(key))
                throw new InvalidOperationException("Already assigned!");
            IProperty result;
            symbols[key] = result = new NativeProperty(delimiter, name, propertyInfo);
            return result;
        }

        public IMemberIndexer AddNativeIndexer(PropertyInfo propertyInfo)
        {
            if (this.indexer != null)
                throw new InvalidOperationException("Duplicate indexer!");
            return this.indexer = new NativeIndexer(propertyInfo);
        }

        public IMemberIndexer Indexer { get { return indexer; } }
        public IEnumerable<IProperty> Members { get { return symbols.Values; } }
    }
}
