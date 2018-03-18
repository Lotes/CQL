## `CQLBaseListener`

```csharp
public class CQL.CQLBaseListener
    : ICQLListener, IParseTreeListener

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | EnterAddTerm(`AddTermContext` context) |  | 
| `void` | EnterAnd(`AndContext` context) |  | 
| `void` | EnterArrayAccess(`ArrayAccessContext` context) |  | 
| `void` | EnterBool(`BoolContext` context) |  | 
| `void` | EnterBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `void` | EnterBraceElems(`BraceElemsContext` context) |  | 
| `void` | EnterBracketElems(`BracketElemsContext` context) |  | 
| `void` | EnterCastFactor(`CastFactorContext` context) |  | 
| `void` | EnterChain_element(`Chain_elementContext` context) |  | 
| `void` | EnterCompareTerm(`CompareTermContext` context) |  | 
| `void` | EnterComplexFactor(`ComplexFactorContext` context) |  | 
| `void` | EnterConditional(`ConditionalContext` context) |  | 
| `void` | EnterConst(`ConstContext` context) |  | 
| `void` | EnterConstant(`ConstantContext` context) |  | 
| `void` | EnterContains(`ContainsContext` context) |  | 
| `void` | EnterDecimal(`DecimalContext` context) |  | 
| `void` | EnterDiv(`DivContext` context) |  | 
| `void` | EnterDoesNotContain(`DoesNotContainContext` context) |  | 
| `void` | EnterElementList(`ElementListContext` context) |  | 
| `void` | EnterElemList(`ElemListContext` context) |  | 
| `void` | EnterElemSingle(`ElemSingleContext` context) |  | 
| `void` | EnterEmpty(`EmptyContext` context) |  | 
| `void` | EnterEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `void` | EnterEquals(`EqualsContext` context) |  | 
| `void` | EnterEqualsTerm(`EqualsTermContext` context) |  | 
| `void` | EnterEveryRule(`ParserRuleContext` context) |  | 
| `void` | EnterExpr(`ExprContext` context) |  | 
| `void` | EnterExpression(`ExpressionContext` context) |  | 
| `void` | EnterFactor(`FactorContext` context) |  | 
| `void` | EnterFalse(`FalseContext` context) |  | 
| `void` | EnterGt(`GtContext` context) |  | 
| `void` | EnterGte(`GteContext` context) |  | 
| `void` | EnterIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `void` | EnterIn(`InContext` context) |  | 
| `void` | EnterIs(`IsContext` context) |  | 
| `void` | EnterList(`ListContext` context) |  | 
| `void` | EnterLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `void` | EnterLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `void` | EnterLs(`LsContext` context) |  | 
| `void` | EnterLt(`LtContext` context) |  | 
| `void` | EnterLte(`LteContext` context) |  | 
| `void` | EnterMember(`MemberContext` context) |  | 
| `void` | EnterMemberCall(`MemberCallContext` context) |  | 
| `void` | EnterMemberName(`MemberNameContext` context) |  | 
| `void` | EnterMethodCall(`MethodCallContext` context) |  | 
| `void` | EnterMinus(`MinusContext` context) |  | 
| `void` | EnterMinusFactor(`MinusFactorContext` context) |  | 
| `void` | EnterMod(`ModContext` context) |  | 
| `void` | EnterMul(`MulContext` context) |  | 
| `void` | EnterMulTerm(`MulTermContext` context) |  | 
| `void` | EnterNotEquals(`NotEqualsContext` context) |  | 
| `void` | EnterNotFactor(`NotFactorContext` context) |  | 
| `void` | EnterNotIn(`NotInContext` context) |  | 
| `void` | EnterNull(`NullContext` context) |  | 
| `void` | EnterNullLiteral(`NullLiteralContext` context) |  | 
| `void` | EnterOr(`OrContext` context) |  | 
| `void` | EnterParameterList(`ParameterListContext` context) |  | 
| `void` | EnterParamList(`ParamListContext` context) |  | 
| `void` | EnterParamSingle(`ParamSingleContext` context) |  | 
| `void` | EnterPlus(`PlusContext` context) |  | 
| `void` | EnterPlusFactor(`PlusFactorContext` context) |  | 
| `void` | EnterPrimary(`PrimaryContext` context) |  | 
| `void` | EnterPrimeVar(`PrimeVarContext` context) |  | 
| `void` | EnterQuery(`QueryContext` context) |  | 
| `void` | EnterSpecialTerm(`SpecialTermContext` context) |  | 
| `void` | EnterString(`StringContext` context) |  | 
| `void` | EnterToAdd(`ToAddContext` context) |  | 
| `void` | EnterToAnd(`ToAndContext` context) |  | 
| `void` | EnterToCompare(`ToCompareContext` context) |  | 
| `void` | EnterToEquals(`ToEqualsContext` context) |  | 
| `void` | EnterToFactor(`ToFactorContext` context) |  | 
| `void` | EnterToMul(`ToMulContext` context) |  | 
| `void` | EnterToOr(`ToOrContext` context) |  | 
| `void` | EnterToSpecial(`ToSpecialContext` context) |  | 
| `void` | EnterTrue(`TrueContext` context) |  | 
| `void` | EnterTypeName(`TypeNameContext` context) |  | 
| `void` | EnterVarExp(`VarExpContext` context) |  | 
| `void` | ExitAddTerm(`AddTermContext` context) |  | 
| `void` | ExitAnd(`AndContext` context) |  | 
| `void` | ExitArrayAccess(`ArrayAccessContext` context) |  | 
| `void` | ExitBool(`BoolContext` context) |  | 
| `void` | ExitBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `void` | ExitBraceElems(`BraceElemsContext` context) |  | 
| `void` | ExitBracketElems(`BracketElemsContext` context) |  | 
| `void` | ExitCastFactor(`CastFactorContext` context) |  | 
| `void` | ExitChain_element(`Chain_elementContext` context) |  | 
| `void` | ExitCompareTerm(`CompareTermContext` context) |  | 
| `void` | ExitComplexFactor(`ComplexFactorContext` context) |  | 
| `void` | ExitConditional(`ConditionalContext` context) |  | 
| `void` | ExitConst(`ConstContext` context) |  | 
| `void` | ExitConstant(`ConstantContext` context) |  | 
| `void` | ExitContains(`ContainsContext` context) |  | 
| `void` | ExitDecimal(`DecimalContext` context) |  | 
| `void` | ExitDiv(`DivContext` context) |  | 
| `void` | ExitDoesNotContain(`DoesNotContainContext` context) |  | 
| `void` | ExitElementList(`ElementListContext` context) |  | 
| `void` | ExitElemList(`ElemListContext` context) |  | 
| `void` | ExitElemSingle(`ElemSingleContext` context) |  | 
| `void` | ExitEmpty(`EmptyContext` context) |  | 
| `void` | ExitEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `void` | ExitEquals(`EqualsContext` context) |  | 
| `void` | ExitEqualsTerm(`EqualsTermContext` context) |  | 
| `void` | ExitEveryRule(`ParserRuleContext` context) |  | 
| `void` | ExitExpr(`ExprContext` context) |  | 
| `void` | ExitExpression(`ExpressionContext` context) |  | 
| `void` | ExitFactor(`FactorContext` context) |  | 
| `void` | ExitFalse(`FalseContext` context) |  | 
| `void` | ExitGt(`GtContext` context) |  | 
| `void` | ExitGte(`GteContext` context) |  | 
| `void` | ExitIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `void` | ExitIn(`InContext` context) |  | 
| `void` | ExitIs(`IsContext` context) |  | 
| `void` | ExitList(`ListContext` context) |  | 
| `void` | ExitLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `void` | ExitLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `void` | ExitLs(`LsContext` context) |  | 
| `void` | ExitLt(`LtContext` context) |  | 
| `void` | ExitLte(`LteContext` context) |  | 
| `void` | ExitMember(`MemberContext` context) |  | 
| `void` | ExitMemberCall(`MemberCallContext` context) |  | 
| `void` | ExitMemberName(`MemberNameContext` context) |  | 
| `void` | ExitMethodCall(`MethodCallContext` context) |  | 
| `void` | ExitMinus(`MinusContext` context) |  | 
| `void` | ExitMinusFactor(`MinusFactorContext` context) |  | 
| `void` | ExitMod(`ModContext` context) |  | 
| `void` | ExitMul(`MulContext` context) |  | 
| `void` | ExitMulTerm(`MulTermContext` context) |  | 
| `void` | ExitNotEquals(`NotEqualsContext` context) |  | 
| `void` | ExitNotFactor(`NotFactorContext` context) |  | 
| `void` | ExitNotIn(`NotInContext` context) |  | 
| `void` | ExitNull(`NullContext` context) |  | 
| `void` | ExitNullLiteral(`NullLiteralContext` context) |  | 
| `void` | ExitOr(`OrContext` context) |  | 
| `void` | ExitParameterList(`ParameterListContext` context) |  | 
| `void` | ExitParamList(`ParamListContext` context) |  | 
| `void` | ExitParamSingle(`ParamSingleContext` context) |  | 
| `void` | ExitPlus(`PlusContext` context) |  | 
| `void` | ExitPlusFactor(`PlusFactorContext` context) |  | 
| `void` | ExitPrimary(`PrimaryContext` context) |  | 
| `void` | ExitPrimeVar(`PrimeVarContext` context) |  | 
| `void` | ExitQuery(`QueryContext` context) |  | 
| `void` | ExitSpecialTerm(`SpecialTermContext` context) |  | 
| `void` | ExitString(`StringContext` context) |  | 
| `void` | ExitToAdd(`ToAddContext` context) |  | 
| `void` | ExitToAnd(`ToAndContext` context) |  | 
| `void` | ExitToCompare(`ToCompareContext` context) |  | 
| `void` | ExitToEquals(`ToEqualsContext` context) |  | 
| `void` | ExitToFactor(`ToFactorContext` context) |  | 
| `void` | ExitToMul(`ToMulContext` context) |  | 
| `void` | ExitToOr(`ToOrContext` context) |  | 
| `void` | ExitToSpecial(`ToSpecialContext` context) |  | 
| `void` | ExitTrue(`TrueContext` context) |  | 
| `void` | ExitTypeName(`TypeNameContext` context) |  | 
| `void` | ExitVarExp(`VarExpContext` context) |  | 
| `void` | VisitErrorNode(`IErrorNode` node) |  | 
| `void` | VisitTerminal(`ITerminalNode` node) |  | 


## `CQLBaseVisitor<Result>`

```csharp
public class CQL.CQLBaseVisitor<Result>
    : AbstractParseTreeVisitor<Result>, IParseTreeVisitor<Result>, ICQLVisitor<Result>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Result` | VisitAddTerm(`AddTermContext` context) |  | 
| `Result` | VisitAnd(`AndContext` context) |  | 
| `Result` | VisitArrayAccess(`ArrayAccessContext` context) |  | 
| `Result` | VisitBool(`BoolContext` context) |  | 
| `Result` | VisitBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `Result` | VisitBraceElems(`BraceElemsContext` context) |  | 
| `Result` | VisitBracketElems(`BracketElemsContext` context) |  | 
| `Result` | VisitCastFactor(`CastFactorContext` context) |  | 
| `Result` | VisitChain_element(`Chain_elementContext` context) |  | 
| `Result` | VisitCompareTerm(`CompareTermContext` context) |  | 
| `Result` | VisitComplexFactor(`ComplexFactorContext` context) |  | 
| `Result` | VisitConditional(`ConditionalContext` context) |  | 
| `Result` | VisitConst(`ConstContext` context) |  | 
| `Result` | VisitConstant(`ConstantContext` context) |  | 
| `Result` | VisitContains(`ContainsContext` context) |  | 
| `Result` | VisitDecimal(`DecimalContext` context) |  | 
| `Result` | VisitDiv(`DivContext` context) |  | 
| `Result` | VisitDoesNotContain(`DoesNotContainContext` context) |  | 
| `Result` | VisitElementList(`ElementListContext` context) |  | 
| `Result` | VisitElemList(`ElemListContext` context) |  | 
| `Result` | VisitElemSingle(`ElemSingleContext` context) |  | 
| `Result` | VisitEmpty(`EmptyContext` context) |  | 
| `Result` | VisitEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `Result` | VisitEquals(`EqualsContext` context) |  | 
| `Result` | VisitEqualsTerm(`EqualsTermContext` context) |  | 
| `Result` | VisitExpr(`ExprContext` context) |  | 
| `Result` | VisitExpression(`ExpressionContext` context) |  | 
| `Result` | VisitFactor(`FactorContext` context) |  | 
| `Result` | VisitFalse(`FalseContext` context) |  | 
| `Result` | VisitGt(`GtContext` context) |  | 
| `Result` | VisitGte(`GteContext` context) |  | 
| `Result` | VisitIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `Result` | VisitIn(`InContext` context) |  | 
| `Result` | VisitIs(`IsContext` context) |  | 
| `Result` | VisitList(`ListContext` context) |  | 
| `Result` | VisitLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `Result` | VisitLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `Result` | VisitLs(`LsContext` context) |  | 
| `Result` | VisitLt(`LtContext` context) |  | 
| `Result` | VisitLte(`LteContext` context) |  | 
| `Result` | VisitMember(`MemberContext` context) |  | 
| `Result` | VisitMemberCall(`MemberCallContext` context) |  | 
| `Result` | VisitMemberName(`MemberNameContext` context) |  | 
| `Result` | VisitMethodCall(`MethodCallContext` context) |  | 
| `Result` | VisitMinus(`MinusContext` context) |  | 
| `Result` | VisitMinusFactor(`MinusFactorContext` context) |  | 
| `Result` | VisitMod(`ModContext` context) |  | 
| `Result` | VisitMul(`MulContext` context) |  | 
| `Result` | VisitMulTerm(`MulTermContext` context) |  | 
| `Result` | VisitNotEquals(`NotEqualsContext` context) |  | 
| `Result` | VisitNotFactor(`NotFactorContext` context) |  | 
| `Result` | VisitNotIn(`NotInContext` context) |  | 
| `Result` | VisitNull(`NullContext` context) |  | 
| `Result` | VisitNullLiteral(`NullLiteralContext` context) |  | 
| `Result` | VisitOr(`OrContext` context) |  | 
| `Result` | VisitParameterList(`ParameterListContext` context) |  | 
| `Result` | VisitParamList(`ParamListContext` context) |  | 
| `Result` | VisitParamSingle(`ParamSingleContext` context) |  | 
| `Result` | VisitPlus(`PlusContext` context) |  | 
| `Result` | VisitPlusFactor(`PlusFactorContext` context) |  | 
| `Result` | VisitPrimary(`PrimaryContext` context) |  | 
| `Result` | VisitPrimeVar(`PrimeVarContext` context) |  | 
| `Result` | VisitQuery(`QueryContext` context) |  | 
| `Result` | VisitSpecialTerm(`SpecialTermContext` context) |  | 
| `Result` | VisitString(`StringContext` context) |  | 
| `Result` | VisitToAdd(`ToAddContext` context) |  | 
| `Result` | VisitToAnd(`ToAndContext` context) |  | 
| `Result` | VisitToCompare(`ToCompareContext` context) |  | 
| `Result` | VisitToEquals(`ToEqualsContext` context) |  | 
| `Result` | VisitToFactor(`ToFactorContext` context) |  | 
| `Result` | VisitToMul(`ToMulContext` context) |  | 
| `Result` | VisitToOr(`ToOrContext` context) |  | 
| `Result` | VisitToSpecial(`ToSpecialContext` context) |  | 
| `Result` | VisitTrue(`TrueContext` context) |  | 
| `Result` | VisitTypeName(`TypeNameContext` context) |  | 
| `Result` | VisitVarExp(`VarExpContext` context) |  | 


## `CQLLexer`

```csharp
public class CQL.CQLLexer
    : Lexer, IRecognizer, ITokenSource

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GrammarFileName |  | 
| `String[]` | ModeNames |  | 
| `String[]` | RuleNames |  | 
| `String` | SerializedAtn |  | 
| `IVocabulary` | Vocabulary |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `ATN` | _ATN |  | 
| `String` | _serializedATN |  | 
| `Int32` | AND |  | 
| `Int32` | AS |  | 
| `Int32` | COLON |  | 
| `Int32` | COMMA |  | 
| `Int32` | CONTAINS |  | 
| `Int32` | DECIMAL_LITERAL |  | 
| `IVocabulary` | DefaultVocabulary |  | 
| `Int32` | DIV |  | 
| `Int32` | DOES_NOT_CONTAIN |  | 
| `Int32` | EMPTY |  | 
| `Int32` | EQUALS |  | 
| `Int32` | FALSE |  | 
| `Int32` | GREATER_THAN |  | 
| `Int32` | GREATER_THAN_EQUALS |  | 
| `Int32` | ID |  | 
| `Int32` | IN |  | 
| `Int32` | IS |  | 
| `Int32` | LBRACE |  | 
| `Int32` | LBRACKET |  | 
| `Int32` | LESS_THAN |  | 
| `Int32` | LESS_THAN_EQUALS |  | 
| `Int32` | LPAREN |  | 
| `Int32` | MINUS |  | 
| `Int32` | MOD |  | 
| `String[]` | modeNames |  | 
| `Int32` | MUL |  | 
| `Int32` | NOT |  | 
| `Int32` | NOT_EQUALS |  | 
| `Int32` | NULL |  | 
| `Int32` | OR |  | 
| `Int32` | PLUS |  | 
| `Int32` | QUESTION |  | 
| `Int32` | RBRACE |  | 
| `Int32` | RBRACKET |  | 
| `Int32` | RPAREN |  | 
| `String[]` | ruleNames |  | 
| `Int32` | SEPARATOR |  | 
| `Int32` | SLASH |  | 
| `Int32` | STRING_LITERAL |  | 
| `Int32` | TRUE |  | 
| `Int32` | WHITESPACE |  | 


## `CQLParser`

```csharp
public class CQL.CQLParser
    : Parser, IRecognizer

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GrammarFileName |  | 
| `String[]` | RuleNames |  | 
| `String` | SerializedAtn |  | 
| `IVocabulary` | Vocabulary |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `AddTermContext` | addTerm() |  | 
| `BooleanLiteralContext` | booleanLiteral() |  | 
| `Chain_elementContext` | chain_element() |  | 
| `CompareTermContext` | compareTerm() |  | 
| `ConstantContext` | constant() |  | 
| `ElementListContext` | elementList() |  | 
| `EmptyLiteralContext` | emptyLiteral() |  | 
| `EqualsTermContext` | equalsTerm() |  | 
| `ExpressionContext` | expression() |  | 
| `FactorContext` | factor() |  | 
| `IfThenElseTermContext` | ifThenElseTerm() |  | 
| `ListContext` | list() |  | 
| `LogicalAndTermContext` | logicalAndTerm() |  | 
| `LogicalOrTermContext` | logicalOrTerm() |  | 
| `MemberContext` | member() |  | 
| `MulTermContext` | mulTerm() |  | 
| `NullLiteralContext` | nullLiteral() |  | 
| `ParameterListContext` | parameterList() |  | 
| `PrimaryContext` | primary() |  | 
| `PrimeVarContext` | primeVar() |  | 
| `QueryContext` | query() |  | 
| `Boolean` | Sempred(`RuleContext` _localctx, `Int32` ruleIndex, `Int32` predIndex) |  | 
| `SpecialTermContext` | specialTerm() |  | 
| `TypeNameContext` | typeName() |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `ATN` | _ATN |  | 
| `String` | _serializedATN |  | 
| `Int32` | AND |  | 
| `Int32` | AS |  | 
| `Int32` | COLON |  | 
| `Int32` | COMMA |  | 
| `Int32` | CONTAINS |  | 
| `Int32` | DECIMAL_LITERAL |  | 
| `IVocabulary` | DefaultVocabulary |  | 
| `Int32` | DIV |  | 
| `Int32` | DOES_NOT_CONTAIN |  | 
| `Int32` | EMPTY |  | 
| `Int32` | EQUALS |  | 
| `Int32` | FALSE |  | 
| `Int32` | GREATER_THAN |  | 
| `Int32` | GREATER_THAN_EQUALS |  | 
| `Int32` | ID |  | 
| `Int32` | IN |  | 
| `Int32` | IS |  | 
| `Int32` | LBRACE |  | 
| `Int32` | LBRACKET |  | 
| `Int32` | LESS_THAN |  | 
| `Int32` | LESS_THAN_EQUALS |  | 
| `Int32` | LPAREN |  | 
| `Int32` | MINUS |  | 
| `Int32` | MOD |  | 
| `Int32` | MUL |  | 
| `Int32` | NOT |  | 
| `Int32` | NOT_EQUALS |  | 
| `Int32` | NULL |  | 
| `Int32` | OR |  | 
| `Int32` | PLUS |  | 
| `Int32` | QUESTION |  | 
| `Int32` | RBRACE |  | 
| `Int32` | RBRACKET |  | 
| `Int32` | RPAREN |  | 
| `Int32` | RULE_addTerm |  | 
| `Int32` | RULE_booleanLiteral |  | 
| `Int32` | RULE_chain_element |  | 
| `Int32` | RULE_compareTerm |  | 
| `Int32` | RULE_constant |  | 
| `Int32` | RULE_elementList |  | 
| `Int32` | RULE_emptyLiteral |  | 
| `Int32` | RULE_equalsTerm |  | 
| `Int32` | RULE_expression |  | 
| `Int32` | RULE_factor |  | 
| `Int32` | RULE_ifThenElseTerm |  | 
| `Int32` | RULE_list |  | 
| `Int32` | RULE_logicalAndTerm |  | 
| `Int32` | RULE_logicalOrTerm |  | 
| `Int32` | RULE_member |  | 
| `Int32` | RULE_mulTerm |  | 
| `Int32` | RULE_nullLiteral |  | 
| `Int32` | RULE_parameterList |  | 
| `Int32` | RULE_primary |  | 
| `Int32` | RULE_primeVar |  | 
| `Int32` | RULE_query |  | 
| `Int32` | RULE_specialTerm |  | 
| `Int32` | RULE_typeName |  | 
| `String[]` | ruleNames |  | 
| `Int32` | SEPARATOR |  | 
| `Int32` | SLASH |  | 
| `Int32` | STRING_LITERAL |  | 
| `Int32` | TRUE |  | 
| `Int32` | WHITESPACE |  | 


## `DictionaryExtensions`

```csharp
public static class CQL.DictionaryExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AlterValueOrDefault(this `IDictionary<TKey, TValue>` dictionary, `TKey` key, `Func<TValue, TValue>` action, `TValue` default = null) |  | 
| `TValue` | GetOrDefault(this `IReadOnlyDictionary<TKey, TValue>` _this, `TKey` key, `TValue` default = null) |  | 
| `TValue` | GetValueOrInsertedDefault(this `IDictionary<TKey, TValue>` dictionary, `TKey` key, `TValue` default = null) |  | 
| `TValue` | GetValueOrInsertedLazyDefault(this `IDictionary<TKey, TValue>` dictionary, `TKey` key, `Func<TValue>` default) |  | 
| `IReadOnlyDictionary<TKey, TValue>` | MergeWith(this `IReadOnlyDictionary<TKey, TValue>` this, `IReadOnlyDictionary`2[]` others) |  | 


## `EnumerableExtensions`

```csharp
public static class CQL.EnumerableExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<T>` | Plus(this `IEnumerable<T>` this, `T[]` added) |  | 


## `HashExtensions`

```csharp
public static class CQL.HashExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | GetCommonHashCode(this `IEnumerable<Object>` this) |  | 


## `ICQLListener`

```csharp
public interface CQL.ICQLListener
    : IParseTreeListener

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | EnterAddTerm(`AddTermContext` context) |  | 
| `void` | EnterAnd(`AndContext` context) |  | 
| `void` | EnterArrayAccess(`ArrayAccessContext` context) |  | 
| `void` | EnterBool(`BoolContext` context) |  | 
| `void` | EnterBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `void` | EnterBraceElems(`BraceElemsContext` context) |  | 
| `void` | EnterBracketElems(`BracketElemsContext` context) |  | 
| `void` | EnterCastFactor(`CastFactorContext` context) |  | 
| `void` | EnterChain_element(`Chain_elementContext` context) |  | 
| `void` | EnterCompareTerm(`CompareTermContext` context) |  | 
| `void` | EnterComplexFactor(`ComplexFactorContext` context) |  | 
| `void` | EnterConditional(`ConditionalContext` context) |  | 
| `void` | EnterConst(`ConstContext` context) |  | 
| `void` | EnterConstant(`ConstantContext` context) |  | 
| `void` | EnterContains(`ContainsContext` context) |  | 
| `void` | EnterDecimal(`DecimalContext` context) |  | 
| `void` | EnterDiv(`DivContext` context) |  | 
| `void` | EnterDoesNotContain(`DoesNotContainContext` context) |  | 
| `void` | EnterElementList(`ElementListContext` context) |  | 
| `void` | EnterElemList(`ElemListContext` context) |  | 
| `void` | EnterElemSingle(`ElemSingleContext` context) |  | 
| `void` | EnterEmpty(`EmptyContext` context) |  | 
| `void` | EnterEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `void` | EnterEquals(`EqualsContext` context) |  | 
| `void` | EnterEqualsTerm(`EqualsTermContext` context) |  | 
| `void` | EnterExpr(`ExprContext` context) |  | 
| `void` | EnterExpression(`ExpressionContext` context) |  | 
| `void` | EnterFactor(`FactorContext` context) |  | 
| `void` | EnterFalse(`FalseContext` context) |  | 
| `void` | EnterGt(`GtContext` context) |  | 
| `void` | EnterGte(`GteContext` context) |  | 
| `void` | EnterIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `void` | EnterIn(`InContext` context) |  | 
| `void` | EnterIs(`IsContext` context) |  | 
| `void` | EnterList(`ListContext` context) |  | 
| `void` | EnterLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `void` | EnterLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `void` | EnterLs(`LsContext` context) |  | 
| `void` | EnterLt(`LtContext` context) |  | 
| `void` | EnterLte(`LteContext` context) |  | 
| `void` | EnterMember(`MemberContext` context) |  | 
| `void` | EnterMemberCall(`MemberCallContext` context) |  | 
| `void` | EnterMemberName(`MemberNameContext` context) |  | 
| `void` | EnterMethodCall(`MethodCallContext` context) |  | 
| `void` | EnterMinus(`MinusContext` context) |  | 
| `void` | EnterMinusFactor(`MinusFactorContext` context) |  | 
| `void` | EnterMod(`ModContext` context) |  | 
| `void` | EnterMul(`MulContext` context) |  | 
| `void` | EnterMulTerm(`MulTermContext` context) |  | 
| `void` | EnterNotEquals(`NotEqualsContext` context) |  | 
| `void` | EnterNotFactor(`NotFactorContext` context) |  | 
| `void` | EnterNotIn(`NotInContext` context) |  | 
| `void` | EnterNull(`NullContext` context) |  | 
| `void` | EnterNullLiteral(`NullLiteralContext` context) |  | 
| `void` | EnterOr(`OrContext` context) |  | 
| `void` | EnterParameterList(`ParameterListContext` context) |  | 
| `void` | EnterParamList(`ParamListContext` context) |  | 
| `void` | EnterParamSingle(`ParamSingleContext` context) |  | 
| `void` | EnterPlus(`PlusContext` context) |  | 
| `void` | EnterPlusFactor(`PlusFactorContext` context) |  | 
| `void` | EnterPrimary(`PrimaryContext` context) |  | 
| `void` | EnterPrimeVar(`PrimeVarContext` context) |  | 
| `void` | EnterQuery(`QueryContext` context) |  | 
| `void` | EnterSpecialTerm(`SpecialTermContext` context) |  | 
| `void` | EnterString(`StringContext` context) |  | 
| `void` | EnterToAdd(`ToAddContext` context) |  | 
| `void` | EnterToAnd(`ToAndContext` context) |  | 
| `void` | EnterToCompare(`ToCompareContext` context) |  | 
| `void` | EnterToEquals(`ToEqualsContext` context) |  | 
| `void` | EnterToFactor(`ToFactorContext` context) |  | 
| `void` | EnterToMul(`ToMulContext` context) |  | 
| `void` | EnterToOr(`ToOrContext` context) |  | 
| `void` | EnterToSpecial(`ToSpecialContext` context) |  | 
| `void` | EnterTrue(`TrueContext` context) |  | 
| `void` | EnterTypeName(`TypeNameContext` context) |  | 
| `void` | EnterVarExp(`VarExpContext` context) |  | 
| `void` | ExitAddTerm(`AddTermContext` context) |  | 
| `void` | ExitAnd(`AndContext` context) |  | 
| `void` | ExitArrayAccess(`ArrayAccessContext` context) |  | 
| `void` | ExitBool(`BoolContext` context) |  | 
| `void` | ExitBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `void` | ExitBraceElems(`BraceElemsContext` context) |  | 
| `void` | ExitBracketElems(`BracketElemsContext` context) |  | 
| `void` | ExitCastFactor(`CastFactorContext` context) |  | 
| `void` | ExitChain_element(`Chain_elementContext` context) |  | 
| `void` | ExitCompareTerm(`CompareTermContext` context) |  | 
| `void` | ExitComplexFactor(`ComplexFactorContext` context) |  | 
| `void` | ExitConditional(`ConditionalContext` context) |  | 
| `void` | ExitConst(`ConstContext` context) |  | 
| `void` | ExitConstant(`ConstantContext` context) |  | 
| `void` | ExitContains(`ContainsContext` context) |  | 
| `void` | ExitDecimal(`DecimalContext` context) |  | 
| `void` | ExitDiv(`DivContext` context) |  | 
| `void` | ExitDoesNotContain(`DoesNotContainContext` context) |  | 
| `void` | ExitElementList(`ElementListContext` context) |  | 
| `void` | ExitElemList(`ElemListContext` context) |  | 
| `void` | ExitElemSingle(`ElemSingleContext` context) |  | 
| `void` | ExitEmpty(`EmptyContext` context) |  | 
| `void` | ExitEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `void` | ExitEquals(`EqualsContext` context) |  | 
| `void` | ExitEqualsTerm(`EqualsTermContext` context) |  | 
| `void` | ExitExpr(`ExprContext` context) |  | 
| `void` | ExitExpression(`ExpressionContext` context) |  | 
| `void` | ExitFactor(`FactorContext` context) |  | 
| `void` | ExitFalse(`FalseContext` context) |  | 
| `void` | ExitGt(`GtContext` context) |  | 
| `void` | ExitGte(`GteContext` context) |  | 
| `void` | ExitIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `void` | ExitIn(`InContext` context) |  | 
| `void` | ExitIs(`IsContext` context) |  | 
| `void` | ExitList(`ListContext` context) |  | 
| `void` | ExitLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `void` | ExitLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `void` | ExitLs(`LsContext` context) |  | 
| `void` | ExitLt(`LtContext` context) |  | 
| `void` | ExitLte(`LteContext` context) |  | 
| `void` | ExitMember(`MemberContext` context) |  | 
| `void` | ExitMemberCall(`MemberCallContext` context) |  | 
| `void` | ExitMemberName(`MemberNameContext` context) |  | 
| `void` | ExitMethodCall(`MethodCallContext` context) |  | 
| `void` | ExitMinus(`MinusContext` context) |  | 
| `void` | ExitMinusFactor(`MinusFactorContext` context) |  | 
| `void` | ExitMod(`ModContext` context) |  | 
| `void` | ExitMul(`MulContext` context) |  | 
| `void` | ExitMulTerm(`MulTermContext` context) |  | 
| `void` | ExitNotEquals(`NotEqualsContext` context) |  | 
| `void` | ExitNotFactor(`NotFactorContext` context) |  | 
| `void` | ExitNotIn(`NotInContext` context) |  | 
| `void` | ExitNull(`NullContext` context) |  | 
| `void` | ExitNullLiteral(`NullLiteralContext` context) |  | 
| `void` | ExitOr(`OrContext` context) |  | 
| `void` | ExitParameterList(`ParameterListContext` context) |  | 
| `void` | ExitParamList(`ParamListContext` context) |  | 
| `void` | ExitParamSingle(`ParamSingleContext` context) |  | 
| `void` | ExitPlus(`PlusContext` context) |  | 
| `void` | ExitPlusFactor(`PlusFactorContext` context) |  | 
| `void` | ExitPrimary(`PrimaryContext` context) |  | 
| `void` | ExitPrimeVar(`PrimeVarContext` context) |  | 
| `void` | ExitQuery(`QueryContext` context) |  | 
| `void` | ExitSpecialTerm(`SpecialTermContext` context) |  | 
| `void` | ExitString(`StringContext` context) |  | 
| `void` | ExitToAdd(`ToAddContext` context) |  | 
| `void` | ExitToAnd(`ToAndContext` context) |  | 
| `void` | ExitToCompare(`ToCompareContext` context) |  | 
| `void` | ExitToEquals(`ToEqualsContext` context) |  | 
| `void` | ExitToFactor(`ToFactorContext` context) |  | 
| `void` | ExitToMul(`ToMulContext` context) |  | 
| `void` | ExitToOr(`ToOrContext` context) |  | 
| `void` | ExitToSpecial(`ToSpecialContext` context) |  | 
| `void` | ExitTrue(`TrueContext` context) |  | 
| `void` | ExitTypeName(`TypeNameContext` context) |  | 
| `void` | ExitVarExp(`VarExpContext` context) |  | 


## `ICQLVisitor<Result>`

```csharp
public interface CQL.ICQLVisitor<Result>
    : IParseTreeVisitor<Result>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Result` | VisitAddTerm(`AddTermContext` context) |  | 
| `Result` | VisitAnd(`AndContext` context) |  | 
| `Result` | VisitArrayAccess(`ArrayAccessContext` context) |  | 
| `Result` | VisitBool(`BoolContext` context) |  | 
| `Result` | VisitBooleanLiteral(`BooleanLiteralContext` context) |  | 
| `Result` | VisitBraceElems(`BraceElemsContext` context) |  | 
| `Result` | VisitBracketElems(`BracketElemsContext` context) |  | 
| `Result` | VisitCastFactor(`CastFactorContext` context) |  | 
| `Result` | VisitChain_element(`Chain_elementContext` context) |  | 
| `Result` | VisitCompareTerm(`CompareTermContext` context) |  | 
| `Result` | VisitComplexFactor(`ComplexFactorContext` context) |  | 
| `Result` | VisitConditional(`ConditionalContext` context) |  | 
| `Result` | VisitConst(`ConstContext` context) |  | 
| `Result` | VisitConstant(`ConstantContext` context) |  | 
| `Result` | VisitContains(`ContainsContext` context) |  | 
| `Result` | VisitDecimal(`DecimalContext` context) |  | 
| `Result` | VisitDiv(`DivContext` context) |  | 
| `Result` | VisitDoesNotContain(`DoesNotContainContext` context) |  | 
| `Result` | VisitElementList(`ElementListContext` context) |  | 
| `Result` | VisitElemList(`ElemListContext` context) |  | 
| `Result` | VisitElemSingle(`ElemSingleContext` context) |  | 
| `Result` | VisitEmpty(`EmptyContext` context) |  | 
| `Result` | VisitEmptyLiteral(`EmptyLiteralContext` context) |  | 
| `Result` | VisitEquals(`EqualsContext` context) |  | 
| `Result` | VisitEqualsTerm(`EqualsTermContext` context) |  | 
| `Result` | VisitExpr(`ExprContext` context) |  | 
| `Result` | VisitExpression(`ExpressionContext` context) |  | 
| `Result` | VisitFactor(`FactorContext` context) |  | 
| `Result` | VisitFalse(`FalseContext` context) |  | 
| `Result` | VisitGt(`GtContext` context) |  | 
| `Result` | VisitGte(`GteContext` context) |  | 
| `Result` | VisitIfThenElseTerm(`IfThenElseTermContext` context) |  | 
| `Result` | VisitIn(`InContext` context) |  | 
| `Result` | VisitIs(`IsContext` context) |  | 
| `Result` | VisitList(`ListContext` context) |  | 
| `Result` | VisitLogicalAndTerm(`LogicalAndTermContext` context) |  | 
| `Result` | VisitLogicalOrTerm(`LogicalOrTermContext` context) |  | 
| `Result` | VisitLs(`LsContext` context) |  | 
| `Result` | VisitLt(`LtContext` context) |  | 
| `Result` | VisitLte(`LteContext` context) |  | 
| `Result` | VisitMember(`MemberContext` context) |  | 
| `Result` | VisitMemberCall(`MemberCallContext` context) |  | 
| `Result` | VisitMemberName(`MemberNameContext` context) |  | 
| `Result` | VisitMethodCall(`MethodCallContext` context) |  | 
| `Result` | VisitMinus(`MinusContext` context) |  | 
| `Result` | VisitMinusFactor(`MinusFactorContext` context) |  | 
| `Result` | VisitMod(`ModContext` context) |  | 
| `Result` | VisitMul(`MulContext` context) |  | 
| `Result` | VisitMulTerm(`MulTermContext` context) |  | 
| `Result` | VisitNotEquals(`NotEqualsContext` context) |  | 
| `Result` | VisitNotFactor(`NotFactorContext` context) |  | 
| `Result` | VisitNotIn(`NotInContext` context) |  | 
| `Result` | VisitNull(`NullContext` context) |  | 
| `Result` | VisitNullLiteral(`NullLiteralContext` context) |  | 
| `Result` | VisitOr(`OrContext` context) |  | 
| `Result` | VisitParameterList(`ParameterListContext` context) |  | 
| `Result` | VisitParamList(`ParamListContext` context) |  | 
| `Result` | VisitParamSingle(`ParamSingleContext` context) |  | 
| `Result` | VisitPlus(`PlusContext` context) |  | 
| `Result` | VisitPlusFactor(`PlusFactorContext` context) |  | 
| `Result` | VisitPrimary(`PrimaryContext` context) |  | 
| `Result` | VisitPrimeVar(`PrimeVarContext` context) |  | 
| `Result` | VisitQuery(`QueryContext` context) |  | 
| `Result` | VisitSpecialTerm(`SpecialTermContext` context) |  | 
| `Result` | VisitString(`StringContext` context) |  | 
| `Result` | VisitToAdd(`ToAddContext` context) |  | 
| `Result` | VisitToAnd(`ToAndContext` context) |  | 
| `Result` | VisitToCompare(`ToCompareContext` context) |  | 
| `Result` | VisitToEquals(`ToEqualsContext` context) |  | 
| `Result` | VisitToFactor(`ToFactorContext` context) |  | 
| `Result` | VisitToMul(`ToMulContext` context) |  | 
| `Result` | VisitToOr(`ToOrContext` context) |  | 
| `Result` | VisitToSpecial(`ToSpecialContext` context) |  | 
| `Result` | VisitTrue(`TrueContext` context) |  | 
| `Result` | VisitTypeName(`TypeNameContext` context) |  | 
| `Result` | VisitVarExp(`VarExpContext` context) |  | 


## `Queries`

```csharp
public static class CQL.Queries

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Query` | True |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<Suggestion>` | AutoComplete(`String` textUntilCaret, `IEvaluationScope` context) |  | 
| `Nullable<Boolean>` | Evaluate(`String` text, `TSubject` subject, `IEvaluationScope` context, `IErrorListener` errorListener = null) |  | 
| `Query` | Parse(`String` text, `IEvaluationScope` context, `IErrorListener` errorListener = null) |  | 
| `Query` | ParseForSyntaxOnly(`String` text, `IErrorListener` errorListener = null) |  | 


## `StringExtensions`

```csharp
public static class CQL.StringExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Escape(this `String` input) |  | 
| `String` | Unescape(this `String` this) |  | 


## `TypeExtensions`

```csharp
public static class CQL.TypeExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | GetCommonBaseClass(this `IEnumerable<Type>` this) |  | 
| `Boolean` | IfEnumerableTryGetElementType(this `Type` this, `Type&` elementType) |  | 
| `Boolean` | IsNumeric(this `Type` this) |  | 


