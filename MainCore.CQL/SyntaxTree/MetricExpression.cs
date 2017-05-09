using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class MetricExpression: IExpression
    {
        public readonly string SensorType;
        public readonly string Name;

        public MetricExpression(ParserRuleContext context, string sensorType, string name)
        {
            SensorType = sensorType;
            Name = name;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }
        public override string ToString()
        {
            return $"{SensorType}.{Name}";
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            throw new NotImplementedException();
        }
    }
}
