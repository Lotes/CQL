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
        BinaryOperation Get(BinaryOperator op, Type left, Type right);
        UnaryOperation Get(UnaryOperator op, Type operand);
    }
}
