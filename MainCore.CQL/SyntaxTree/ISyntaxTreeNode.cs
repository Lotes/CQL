using Antlr4.Runtime;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public interface ISyntaxTreeNode
    {
        ParserRuleContext ParserContext { get; }
        bool StructurallyEquals(ISyntaxTreeNode node);
    }
    public interface ISyntaxTreeNode<TSelf>: ISyntaxTreeNode
    {
        TSelf Validate(IContext context);
    }
}