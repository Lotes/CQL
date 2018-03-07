using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    [AttributeUsage(AttributeTargets.Class)]
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

    [AttributeUsage(AttributeTargets.Property)]
    public class CQLPropertyAttribute : Attribute
    {
        public CQLPropertyAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        public string Name { get; private set; }
        public IdDelimiter Delimiter { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CQLMethodAttribute : Attribute
    {
        public CQLMethodAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        public string Name { get; private set; }
        public IdDelimiter Delimiter { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CQLIndexerAttribute : Attribute
    {
    }
}
