using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CQLTypeAttribute : Attribute
    {
        public CQLTypeAttribute(string name, string usage)
        {
            Name = name;
            Usage = usage;
        }
        public string Name { get; private set; }
        public string Usage { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CQLMemberNativePropertyAttribute : Attribute
    {
        public CQLMemberNativePropertyAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        public string Name { get; private set; }
        public IdDelimiter Delimiter { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CQLNativeMemberFunctionAttribute : Attribute
    {
        public CQLNativeMemberFunctionAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        public string Name { get; private set; }
        public IdDelimiter Delimiter { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CQLNativeMemberIndexerAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CQLGlobalFunction: Attribute
    {
        public CQLGlobalFunction(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
