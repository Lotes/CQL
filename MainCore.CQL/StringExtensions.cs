using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL
{
    public static class StringExtensions
    {
        public static string Escape(this string @this)
        {
            return @this
                .Replace("\"", "\\\"")
                .Replace("\r", "\\\r")
                .Replace("\n", "\\\n")
                .Replace("\t", "\\\t")
                .Replace("\\", "\\\\");
        }
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
