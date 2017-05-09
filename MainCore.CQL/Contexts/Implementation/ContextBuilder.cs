using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.Metrics;
using MainCore.Tags;
using MainCore.CQL.SyntaxTree;

namespace MainCore.CQL.Contexts.Implementation
{
    public class Context : IContext
    {
        public Context(IFieldSet fields, IFunctionSet functions, IEnumerable<MetricKey> metricKeys, IRuleSet rules, IEnumerable<Tag> tags)
        {
            Fields = fields;
            Functions = functions;
            MetricKeys = metricKeys;
            Rules = rules;
            Tags = tags;
        }

        public IFieldSet Fields { get; private set; }
        public IFunctionSet Functions { get; private set; }
        public IEnumerable<MetricKey> MetricKeys { get; private set; }
        public IRuleSet Rules { get; private set; }
        public IEnumerable<Tag> Tags { get; private set; }
    }

    public class ContextBuilder : IContextBuilder
    {
        private FieldSet fields = new FieldSet();
        private RuleSet rules = new RuleSet();
        private FunctionSet functions = new FunctionSet();
        private IEnumerable<Tag> tags = Enumerable.Empty<Tag>();
        private IEnumerable<MetricKey> metrics = Enumerable.Empty<MetricKey>();

        public void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate)
        {
            rules.AddRule(BinaryOperator.Contains, aggregate);
            rules.AddRule<TLeft, TRight, bool>(BinaryOperator.DoesNotContain, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        public void AddEqualsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate)
        {
            rules.AddRule(BinaryOperator.Equals, aggregate);
            rules.AddRule<TLeft, TRight, bool>(BinaryOperator.NotEquals, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        public void AddField<THost, TField>(string name, Func<THost, TField> getter)
        {
            fields.Add(name, getter);            
        }

        public FunctionSet.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage)
        {
            return functions.BeginNew<TResult>(name, usage);
        }

        public void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate)
        {
            rules.AddRule(BinaryOperator.LessThan, aggregate);
            rules.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThan, (lhs, rhs) => aggregate(rhs, lhs));
            rules.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThanEquals, (lhs, rhs) => !aggregate(lhs, rhs));
            rules.AddRule<TOperand, TOperand, bool>(BinaryOperator.LessThanEquals, (lhs, rhs) => !aggregate(rhs, lhs));
        }

        public IContext Build()
        {
            return new Context(fields, functions, metrics, rules, tags);
        }

        public void LinkMetricKeyCatalog(IEnumerable<MetricKey> metricKeys)
        {
            metrics = metricKeys.ToArray();
        }

        public void LinkTagCatalog(ITagCatalog tags)
        {
            this.tags = tags.ToArray();
        }
    }
}
