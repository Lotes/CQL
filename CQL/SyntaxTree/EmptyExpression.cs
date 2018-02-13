﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public class EmptyExpression: IExpression<EmptyExpression>
    {
        public EmptyExpression(IParserLocation context) { Location = context; }
        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return new TypeSystem.Implementation.TypeSystem.Empty();
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as EmptyExpression != null;
        }

        public override string ToString()
        {
            return "EMPTY";
        }

        public EmptyExpression Validate(IScope context)
        {
            SemanticType = context.TypeSystem.EmptyType;
            return this;
        }

        IExpression IExpression.Validate(IScope context)
        {
            return Validate(context);
        }
    }
}