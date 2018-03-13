using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL
{
    /// <summary>
    /// Contains extensions for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Escapes a string from special charaters, using the C# compiler environment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Escape(this string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    var literal = writer.ToString();
                    return literal.Substring(1, literal.Length-2);
                }
            }
        }

        /// <summary>
        /// Unescapes an escaped string.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string Unescape(this string @this)
        {
            return @this
                .Replace("\\\"", "\"")
                .Replace("\\r", "\r")
                .Replace("\\n", "\n")
                .Replace("\\t", "\t")
                .Replace("\\\\", "\\");
        }
    }
}
