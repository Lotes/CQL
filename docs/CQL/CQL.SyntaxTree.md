## `ArrayAccessExpression`

```csharp
public class CQL.SyntaxTree.ArrayAccessExpression
    : IExpression<ArrayAccessExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<ArrayAccessExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<IExpression>` | Indices |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 
| `IExpression` | ThisExpression |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `ArrayAccessExpression` | Validate(`IValidationScope` context) |  | 


## `ArrayExpression`

```csharp
public class CQL.SyntaxTree.ArrayExpression
    : IExpression<ArrayExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<ArrayExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<IExpression>` | Elements |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `ArrayExpression` | Validate(`IValidationScope` context) |  | 


## `BinaryOperationExpression`

```csharp
public class CQL.SyntaxTree.BinaryOperationExpression
    : IExpression<BinaryOperationExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<BinaryOperationExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `BinaryOperator` | Operator |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | LeftExpression |  | 
| `IParserLocation` | Location |  | 
| `IExpression` | RightExpression |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `BinaryOperationExpression` | Validate(`IValidationScope` context) |  | 


## `BinaryOperator`

```csharp
public enum CQL.SyntaxTree.BinaryOperator
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Or |  | 
| `1` | And |  | 
| `2` | Equals |  | 
| `3` | NotEquals |  | 
| `4` | GreaterThan |  | 
| `5` | GreaterThanEquals |  | 
| `6` | LessThan |  | 
| `7` | LessThanEquals |  | 
| `8` | Add |  | 
| `9` | Sub |  | 
| `10` | Mul |  | 
| `11` | Mod |  | 
| `12` | Div |  | 
| `13` | Contains |  | 
| `14` | DoesNotContain |  | 
| `15` | Is |  | 
| `16` | In |  | 
| `17` | NotIn |  | 


## `BooleanLiteralExpression`

```csharp
public class CQL.SyntaxTree.BooleanLiteralExpression
    : IExpression<BooleanLiteralExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<BooleanLiteralExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Value |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `BooleanLiteralExpression` | Validate(`IValidationScope` context) |  | 


## `CastExpression`

```csharp
public class CQL.SyntaxTree.CastExpression
    : IExpression<CastExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<CastExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | CastTypeName |  | 
| `CoercionKind` | Kind |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | Expression |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `CastExpression` | Validate(`IValidationScope` context) |  | 


## `ConditionalExpression`

```csharp
public class CQL.SyntaxTree.ConditionalExpression
    : IExpression<ConditionalExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<ConditionalExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | Condition |  | 
| `IExpression` | Else |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 
| `IExpression` | Then |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `ConditionalExpression` | Validate(`IValidationScope` context) |  | 


## `EmptyExpression`

```csharp
public class CQL.SyntaxTree.EmptyExpression
    : IExpression<EmptyExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<EmptyExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `EmptyExpression` | Validate(`IValidationScope` context) |  | 


## `FloatingPointLiteralExpression`

```csharp
public class CQL.SyntaxTree.FloatingPointLiteralExpression
    : IExpression<FloatingPointLiteralExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<FloatingPointLiteralExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Double` | Value |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `FloatingPointLiteralExpression` | Validate(`IValidationScope` context) |  | 


## `FunctionCallExpression`

```csharp
public class CQL.SyntaxTree.FunctionCallExpression
    : IExpression<FunctionCallExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<FunctionCallExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | ThisExpression |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `IEnumerable<IExpression>` | Parameters |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `FunctionCallExpression` | Validate(`IValidationScope` context) |  | 


## `IdDelimiter`

```csharp
public enum CQL.SyntaxTree.IdDelimiter
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Slash |  | 
| `1` | Dot |  | 
| `2` | SingleArrow |  | 
| `3` | Hash |  | 
| `4` | Dollar |  | 


## `IExpression`

```csharp
public interface CQL.SyntaxTree.IExpression
    : ISyntaxTreeNode

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `IExpression` | Validate(`IValidationScope` context) |  | 


## `IExpression<TSelf>`

```csharp
public interface CQL.SyntaxTree.IExpression<TSelf>
    : IExpression, ISyntaxTreeNode, ISyntaxTreeNode<TSelf>

```

## `IntegerLiteralExpression`

```csharp
public class CQL.SyntaxTree.IntegerLiteralExpression
    : IExpression<IntegerLiteralExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<IntegerLiteralExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Value |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `IntegerLiteralExpression` | Validate(`IValidationScope` context) |  | 


## `IParserLocation`

```csharp
public interface CQL.SyntaxTree.IParserLocation

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | StartIndex |  | 
| `Int32` | StopIndex |  | 


## `ISyntaxTreeNode`

```csharp
public interface CQL.SyntaxTree.ISyntaxTreeNode

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 


## `ISyntaxTreeNode<TSelf>`

```csharp
public interface CQL.SyntaxTree.ISyntaxTreeNode<TSelf>
    : ISyntaxTreeNode

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `TSelf` | Validate(`IValidationScope` context) |  | 


## `MemberExpression`

```csharp
public class CQL.SyntaxTree.MemberExpression
    : IExpression<MemberExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<MemberExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IdDelimiter` | Delimiter |  | 
| `IParserLocation` | Location |  | 
| `String` | MemberName |  | 
| `Type` | SemanticType |  | 
| `IExpression` | ThisExpression |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `MemberExpression` | Validate(`IValidationScope` context) |  | 


## `NullExpression`

```csharp
public class CQL.SyntaxTree.NullExpression
    : IExpression<NullExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<NullExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `NullExpression` | Validate(`IValidationScope` context) |  | 


## `ParenthesisExpression`

```csharp
public class CQL.SyntaxTree.ParenthesisExpression
    : IExpression<ParenthesisExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<ParenthesisExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | Expression |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `ParenthesisExpression` | Validate(`IValidationScope` context) |  | 


## `ParserLocation`

```csharp
public class CQL.SyntaxTree.ParserLocation
    : IParserLocation

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | StartIndex |  | 
| `Int32` | StopIndex |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | EmptyContext |  | 


## `ParserLocationExtensions`

```csharp
public static class CQL.SyntaxTree.ParserLocationExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | GetLength(this `IParserLocation` loc) |  | 


## `Query`

```csharp
public class CQL.SyntaxTree.Query
    : ISyntaxTreeNode<Query>, ISyntaxTreeNode

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | Expression |  | 
| `IParserLocation` | Location |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Evaluate(`IEvaluationScope` subject) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `Query` | Validate(`IValidationScope` context) |  | 


## `StringLiteralExpression`

```csharp
public class CQL.SyntaxTree.StringLiteralExpression
    : IExpression<StringLiteralExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<StringLiteralExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Value |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `StringLiteralExpression` | Validate(`IValidationScope` context) |  | 


## `SyntaxTreeExtensions`

```csharp
public static class CQL.SyntaxTree.SyntaxTreeExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IfArrayTryGetElementType(this `IExpression` this, `Type&` elementType) |  | 
| `Boolean` | StructurallyEquals(this `IEnumerable<ISyntaxTreeNode>` this, `IEnumerable<ISyntaxTreeNode>` other) |  | 
| `Boolean` | WasValidated(this `IExpression` this) |  | 


## `UnaryOperationExpression`

```csharp
public class CQL.SyntaxTree.UnaryOperationExpression
    : IExpression<UnaryOperationExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<UnaryOperationExpression>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `UnaryOperator` | Operator |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IExpression` | Expression |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `UnaryOperationExpression` | Validate(`IValidationScope` context) |  | 


## `UnaryOperator`

```csharp
public enum CQL.SyntaxTree.UnaryOperator
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Plus |  | 
| `1` | Minus |  | 
| `2` | Not |  | 


## `VariableExpression`

```csharp
public class CQL.SyntaxTree.VariableExpression
    : IExpression<VariableExpression>, IExpression, ISyntaxTreeNode, ISyntaxTreeNode<VariableExpression>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Identifier |  | 
| `IParserLocation` | Location |  | 
| `Type` | SemanticType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Evaluate(`IEvaluationScope` context) |  | 
| `Boolean` | StructurallyEquals(`ISyntaxTreeNode` node) |  | 
| `String` | ToString() |  | 
| `VariableExpression` | Validate(`IValidationScope` context) |  | 


