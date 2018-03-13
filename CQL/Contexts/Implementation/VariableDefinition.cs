using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts.Implementation
{
    /// <summary>
    /// Default implementation of <see cref="IVariableDefinition"/>
    /// </summary>
    public class VariableDefinition : IVariableDefinition
    {
        /// <summary>
        /// Creates a variable definition
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public VariableDefinition(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Name of the definition.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Value of the definition.
        /// </summary>
        public object Value { get; set; }
    }
}
