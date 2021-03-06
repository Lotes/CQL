﻿using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// Default implementation of <see cref="ITypeSystemBuilder"/>
    /// </summary>
    public class TypeSystemBuilder: ITypeSystemBuilder
    {
        private TypeSystem typeSystem = new TypeSystem();

        /// <summary>
        /// Creates a type system builder.
        /// </summary>
        /// <param name="flags">Setups the initial types.</param>
        public TypeSystemBuilder(SystemDefaultFlags flags = SystemDefaultFlags.All)
        {
            if (flags.HasFlag(SystemDefaultFlags.HasBoolean))
            {
                AddType<bool>("boolean", "true or false");
                typeSystem.AddRule<bool, bool>(UnaryOperator.Not, value => !value);
                typeSystem.AddRule<bool, bool, bool>(BinaryOperator.And, (lhs, rhs) => lhs && rhs);
                typeSystem.AddRule<bool, bool, bool>(BinaryOperator.Or, (lhs, rhs) => lhs || rhs);
            }
            if(flags.HasFlag(SystemDefaultFlags.HasDoubles))
            {
                AddType<double>("double", "floating point number");
                if(flags.HasFlag(SystemDefaultFlags.HasBoolean))
                {
                    AddCoercionRule<bool, double>(CoercionKind.Explicit, @bool => @bool ? 1.0 : 0.0);
                }
            }
            if(flags.HasFlag(SystemDefaultFlags.HasIntegers))
            {
                AddType<int>("int", "whole numbers");
                if(flags.HasFlag(SystemDefaultFlags.HasBoolean))
                {
                    AddCoercionRule<bool, int>(CoercionKind.Explicit, @bool => @bool ? 1 : 0);
                }
            }
            if (flags.HasFlag(SystemDefaultFlags.HasIntegers) && flags.HasFlag(SystemDefaultFlags.HasDoubles))
            {
                AddCoercionRule<int, double>(CoercionKind.Implicit, @int => (double)@int);
                AddCoercionRule<double, int>(CoercionKind.Explicit, @double => (int)@double);
            }
            if(flags.HasFlag(SystemDefaultFlags.HasStrings))
            {
                AddType<string>("string", "sequence of chars");
                typeSystem.AddRule<string, string, string>(BinaryOperator.Add, (lhs, rhs) => lhs + rhs);
                AddContainsRule<string, string>((haystack, needle) => haystack != null && needle != null && haystack.IndexOf(needle) > -1);
                if (flags.HasFlag(SystemDefaultFlags.HasBoolean))
                {
                    AddCoercionRule<bool, string>(CoercionKind.Explicit, @bool => @bool.ToString());
                }
                if (flags.HasFlag(SystemDefaultFlags.HasDoubles))
                {
                    AddCoercionRule<double, string>(CoercionKind.Explicit, @double => @double.ToString());
                }
                if (flags.HasFlag(SystemDefaultFlags.HasIntegers))
                {
                    AddCoercionRule<int, string>(CoercionKind.Explicit, @int => @int.ToString());
                }
            }
        }

        /// <summary>
        /// Registers a native type to be known under the given name.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public IType<TType> AddType<TType>(string name, string usage, TypeDefaultFlags flags = TypeDefaultFlags.All)
        {
            var result = typeSystem.AddType<TType>(name, usage);
            if(flags.HasFlag(TypeDefaultFlags.Equals))
                AddEqualsRule<TType>((a, b) => a != null && b != null && a.Equals(b));
            if (flags.HasFlag(TypeDefaultFlags.Comparable) && typeof(IComparable).IsAssignableFrom(typeof(TType)))
                AddLessRule<TType>((a, b) => ((IComparable)a).CompareTo(b) < 0);
            if(flags.HasFlag(TypeDefaultFlags.Numeric) && typeof(TType).IsNumeric())
            {
                TryAddBinaryNumericOperation<TType>(BinaryOperator.Add);
                TryAddBinaryNumericOperation<TType>(BinaryOperator.Sub);
                TryAddBinaryNumericOperation<TType>(BinaryOperator.Div);
                TryAddBinaryNumericOperation<TType>(BinaryOperator.Mul);
                TryAddBinaryNumericOperation<TType>(BinaryOperator.Mod);
                TryAddUnaryNumericOperation<TType>(UnaryOperator.Plus);
                TryAddUnaryNumericOperation<TType>(UnaryOperator.Minus);
            }
            return result;
        }

        private bool TryAddUnaryNumericOperation<TType>(UnaryOperator op)
        {
            try
            {
                var constant = Expression.Constant(default(TType));
                switch (op)
                {
                    case UnaryOperator.Minus:
                        Expression.Negate(constant);
                        AddRule<TType, TType>(UnaryOperator.Minus, expr =>
                        {
                            dynamic dexpr = expr;
                            return -dexpr;
                        });
                        break;
                    case UnaryOperator.Plus:
                        Expression.UnaryPlus(constant);
                        AddRule<TType, TType>(UnaryOperator.Plus, expr =>
                        {
                            dynamic dexpr = expr;
                            return +dexpr;
                        });
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled operator!");
                }
                return true;
            }
            catch { return false; }
        }

        private bool TryAddBinaryNumericOperation<TType>(BinaryOperator op)
        {
            try
            {
                var constant = Expression.Constant(default(TType));
                switch (op)
                {
                    case BinaryOperator.Add:
                        Expression.Add(constant, constant);
                        AddRule<TType, TType, TType>(op, (lhs, rhs) =>
                        {
                            dynamic dl = lhs;
                            dynamic dr = rhs;
                            return dl + dr;
                        });
                        break;
                    case BinaryOperator.Sub:
                        Expression.Subtract(constant, constant);
                        AddRule<TType, TType, TType>(op, (lhs, rhs) =>
                        {
                            dynamic dl = lhs;
                            dynamic dr = rhs;
                            return dl - dr;
                        });
                        break;
                    case BinaryOperator.Div:
                        Expression.Divide(constant, constant);
                        AddRule<TType, TType, TType>(op, (lhs, rhs) =>
                        {
                            dynamic dl = lhs;
                            dynamic dr = rhs;
                            return dl / dr;
                        });
                        break;
                    case BinaryOperator.Mul:
                        Expression.Multiply(constant, constant);
                        AddRule<TType, TType, TType>(op, (lhs, rhs) =>
                        {
                            dynamic dl = lhs;
                            dynamic dr = rhs;
                            return dl * dr;
                        });
                        break;
                    case BinaryOperator.Mod:
                        Expression.Modulo(constant, constant);
                        AddRule<TType, TType, TType>(op, (lhs, rhs) =>
                        {
                            dynamic dl = lhs;
                            dynamic dr = rhs;
                            return dl % dr;
                        });
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled operator!");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a coercion rule.
        /// </summary>
        /// <typeparam name="TOriginalType"></typeparam>
        /// <typeparam name="TCastingType"></typeparam>
        /// <param name="kind"></param>
        /// <param name="cast"></param>
        public void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast)
        {
            typeSystem.AddCoercionRule(kind, cast);
        }

        /// <summary>
        /// Adds a contains rule.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <param name="aggregate"></param>
        public void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.Contains, aggregate);
            typeSystem.AddRule<TLeft, TRight, bool>(BinaryOperator.DoesNotContain, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        /// <summary>
        /// Adds equality rules
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <param name="aggregate"></param>
        public void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.Equals, aggregate);
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.NotEquals, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        /// <summary>
        /// Adds "less" rules
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <param name="aggregate"></param>
        public void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.LessThan, aggregate);
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThan, (lhs, rhs) => aggregate(rhs, lhs));
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThanEquals, (lhs, rhs) => !aggregate(lhs, rhs));
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.LessThanEquals, (lhs, rhs) => !aggregate(rhs, lhs));
        }

        /// <summary>
        /// Eventually builds the type system.
        /// </summary>
        /// <returns></returns>
        public ITypeSystem Build()
        {
            return typeSystem;
        }

        /// <summary>
        /// Add unary rules.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="func"></param>
        public void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func)
        {
            typeSystem.AddRule(op, func);
        }

        /// <summary>
        /// Adds binary rules.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="aggregate"></param>
        public void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate)
        {
            typeSystem.AddRule(op, aggregate);
        }
    }
}
