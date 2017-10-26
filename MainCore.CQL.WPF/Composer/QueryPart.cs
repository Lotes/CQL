using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.WPF.Composer
{
    public class QueryPart
    {
        Field Field;
        BinaryOperator BooleanOperator;
        object Value;
        bool Negate;
    }
}
