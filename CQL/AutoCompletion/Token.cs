using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// Token like operators or parentheses.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        public Token(string name, string usage)
        {
            Name = name;
            Usage = usage;
        }
        /// <summary>
        /// Name of the token.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// What does they mean?
        /// </summary>
        public string Usage { get; private set; }
    }
}
