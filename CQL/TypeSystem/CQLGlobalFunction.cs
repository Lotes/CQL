using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Marks a static function as global function in a evaluation scope.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CQLGlobalFunction: Attribute
    {
        /// <summary>
        /// Creates the attribute.
        /// </summary>
        /// <param name="name"></param>
        public CQLGlobalFunction(string name)
        {
            Name = name;
        }
        /// <summary>
        /// The name of the function within the evaluation scope.
        /// </summary>
        public string Name { get; private set; }
    }
}
