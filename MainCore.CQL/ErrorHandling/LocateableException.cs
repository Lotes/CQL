﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.ErrorHandling
{
    public class LocateableException: Exception
    {
        public readonly int StartIndex;
        public readonly int Length;

        public LocateableException(ParserRuleContext parserContext, string message, Exception innerException = null)
            : this(parserContext.Start.StartIndex, parserContext.Stop.StopIndex, message, innerException)
        {

        }

        public LocateableException(int startIndex, int endIndex, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StartIndex = startIndex;
            Length = endIndex - startIndex + 1;
        }
    }
}