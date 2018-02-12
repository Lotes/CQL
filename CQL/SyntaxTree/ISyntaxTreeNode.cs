using Antlr4.Runtime;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public interface ISyntaxTreeNode
    {
        IParserLocation Location { get; }
        bool StructurallyEquals(ISyntaxTreeNode node);
    }
    public interface ISyntaxTreeNode<TSelf>: ISyntaxTreeNode
    {
        TSelf Validate(IContext context);
    }
}