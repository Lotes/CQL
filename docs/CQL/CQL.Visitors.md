## `ExpressionsVisitor`

```csharp
public class CQL.Visitors.ExpressionsVisitor
    : CQLBaseVisitor<IEnumerable<IExpression>>, IParseTreeVisitor<IEnumerable<IExpression>>, ICQLVisitor<IEnumerable<IExpression>>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<IExpression>` | VisitElemList(`ElemListContext` context) |  | 
| `IEnumerable<IExpression>` | VisitElemSingle(`ElemSingleContext` context) |  | 
| `IEnumerable<IExpression>` | VisitParamList(`ParamListContext` context) |  | 
| `IEnumerable<IExpression>` | VisitParamSingle(`ParamSingleContext` context) |  | 


## `ExpressionVisitor`

```csharp
public class CQL.Visitors.ExpressionVisitor
    : CQLBaseVisitor<IExpression>, IParseTreeVisitor<IExpression>, ICQLVisitor<IExpression>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | VisitAnd(`AndContext` context) |  | 
| `IExpression` | VisitBool(`BoolContext` context) |  | 
| `IExpression` | VisitBraceElems(`BraceElemsContext` context) |  | 
| `IExpression` | VisitBracketElems(`BracketElemsContext` context) |  | 
| `IExpression` | VisitCastFactor(`CastFactorContext` context) |  | 
| `IExpression` | VisitComplexFactor(`ComplexFactorContext` context) |  | 
| `IExpression` | VisitConditional(`ConditionalContext` context) |  | 
| `IExpression` | VisitConst(`ConstContext` context) |  | 
| `IExpression` | VisitContains(`ContainsContext` context) |  | 
| `IExpression` | VisitDecimal(`DecimalContext` context) |  | 
| `IExpression` | VisitDiv(`DivContext` context) |  | 
| `IExpression` | VisitDoesNotContain(`DoesNotContainContext` context) |  | 
| `IExpression` | VisitEmpty(`EmptyContext` context) |  | 
| `IExpression` | VisitEquals(`EqualsContext` context) |  | 
| `IExpression` | VisitExpr(`ExprContext` context) |  | 
| `IExpression` | VisitExpression(`ExpressionContext` context) |  | 
| `IExpression` | VisitGt(`GtContext` context) |  | 
| `IExpression` | VisitGte(`GteContext` context) |  | 
| `IExpression` | VisitIn(`InContext` context) |  | 
| `IExpression` | VisitIs(`IsContext` context) |  | 
| `IExpression` | VisitLs(`LsContext` context) |  | 
| `IExpression` | VisitLt(`LtContext` context) |  | 
| `IExpression` | VisitLte(`LteContext` context) |  | 
| `IExpression` | VisitMinus(`MinusContext` context) |  | 
| `IExpression` | VisitMinusFactor(`MinusFactorContext` context) |  | 
| `IExpression` | VisitMod(`ModContext` context) |  | 
| `IExpression` | VisitMul(`MulContext` context) |  | 
| `IExpression` | VisitNotEquals(`NotEqualsContext` context) |  | 
| `IExpression` | VisitNotFactor(`NotFactorContext` context) |  | 
| `IExpression` | VisitNotIn(`NotInContext` context) |  | 
| `IExpression` | VisitNull(`NullContext` context) |  | 
| `IExpression` | VisitOr(`OrContext` context) |  | 
| `IExpression` | VisitPlus(`PlusContext` context) |  | 
| `IExpression` | VisitPlusFactor(`PlusFactorContext` context) |  | 
| `IExpression` | VisitString(`StringContext` context) |  | 
| `IExpression` | VisitVarExp(`VarExpContext` context) |  | 


## `NameVisitor`

```csharp
public class CQL.Visitors.NameVisitor
    : CQLBaseVisitor<String>, IParseTreeVisitor<String>, ICQLVisitor<String>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | VisitFalse(`FalseContext` context) |  | 
| `String` | VisitMemberName(`MemberNameContext` context) |  | 
| `String` | VisitPrimeVar(`PrimeVarContext` context) |  | 
| `String` | VisitTrue(`TrueContext` context) |  | 
| `String` | VisitTypeName(`TypeNameContext` context) |  | 


## `QueryVisitor`

```csharp
public class CQL.Visitors.QueryVisitor
    : CQLBaseVisitor<Query>, IParseTreeVisitor<Query>, ICQLVisitor<Query>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Query` | VisitQuery(`QueryContext` context) |  | 


