using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public interface IExpression: ISyntaxTreeNode
    {
        Type SemanticType { get; }

        IExpression Validate(IContext context);
    }

    public interface IExpression<TSelf>: IExpression, ISyntaxTreeNode<TSelf>
    {
    }
}
