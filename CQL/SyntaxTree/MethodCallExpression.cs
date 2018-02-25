﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;

namespace CQL.SyntaxTree
{
    public class MethodCallExpression: IExpression<MethodCallExpression>
    {
        public IExpression ThisExpression;

        public IEnumerable<IExpression> Parameters { get; private set; }

        public MethodCallExpression(IParserLocation context, IExpression @this, IEnumerable<IExpression> parameters)
        {
            ThisExpression = @this;
            Parameters = parameters.ToArray();
            Location = context;
        }
        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }
       
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MethodCallExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        public override string ToString()
        {
            return $"{ThisExpression.ToString()}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }

        public MethodCallExpression Validate(IScope<Type> context)
        {
            ThisExpression = ThisExpression.Validate(context);
            MethodSignature signature;
            if (!(ThisExpression.SemanticType.IfMethodClosureTryGetMethodType(out signature)))
                throw new LocateableException(Location, "Expected a method closure!");
            SemanticType = signature.ReturnType;
            return this;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public object Evaluate(IScope<object> context)
        {
            var @this = this.ThisExpression.Evaluate(context);
            if(@this is IMethodClosure)
                return ((IMethodClosure)@this).Invoke(Parameters.Select(p => p.Evaluate(context)).ToArray());
            throw new InvalidOperationException("Closure was expected!");
        }
    }
}
