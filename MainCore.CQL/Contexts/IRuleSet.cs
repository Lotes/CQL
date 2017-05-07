using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public interface IRuleSet
    {
        Func<object, object, object> this[BinaryOperator op, Type left, Type right] { get; }
        Func<object, object> this[UnaryOperator op, Type operand] { get; }
    }
}
