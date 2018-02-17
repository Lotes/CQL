using CQL.Contexts;
using CQL.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.SyntaxTree
{
    public interface IExpression: ISyntaxTreeNode, IEvaluator
    {
        Type SemanticType { get; }

        IExpression Validate(IScope<Type> context);
    }

    public interface IExpression<TSelf>: IExpression, ISyntaxTreeNode<TSelf>
    {
    }
}
