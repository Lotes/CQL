using System;

namespace CQL.Contexts.Implementation
{
    /// <summary>
    /// Default implementation of <see cref="IVariableDeclaration"/>
    /// </summary>
    public class VariableDeclaration : IVariableDeclaration
    {
        /// <summary>
        /// Creates a variable declaration
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value">actual the type...</param>
        public VariableDeclaration(string name, Type value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Name of the definition.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Type of the definition.
        /// </summary>
        public Type Value { get; set; }
    }
}
