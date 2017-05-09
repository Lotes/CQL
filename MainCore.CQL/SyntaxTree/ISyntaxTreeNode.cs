using Antlr4.Runtime;

namespace MainCore.CQL.SyntaxTree
{
    public interface ISyntaxTreeNode
    {
        ParserRuleContext ParserContext { get; }
        bool StructurallyEquals(ISyntaxTreeNode node);
    }
}