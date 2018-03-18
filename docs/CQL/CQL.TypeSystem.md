## `AmbigiousTypeException`

```csharp
public class CQL.TypeSystem.AmbigiousTypeException
    : Exception, ISerializable, _Exception

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | GivenType |  | 
| `IEnumerable<IType>` | KnownTypes |  | 


## `BinaryOperation`

```csharp
public class CQL.TypeSystem.BinaryOperation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | LeftType |  | 
| `Func<Object, Object, Object>` | Operation |  | 
| `BinaryOperator` | Operator |  | 
| `Type` | ResultType |  | 
| `Type` | RightType |  | 


## `CoercionKind`

```csharp
public enum CQL.TypeSystem.CoercionKind
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Implicit |  | 
| `1` | Explicit |  | 


## `CoercionRule`

```csharp
public class CQL.TypeSystem.CoercionRule

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Func<Object, Object>` | Cast |  | 
| `Type` | CastingType |  | 
| `CoercionKind` | Kind |  | 
| `Type` | OriginalType |  | 


## `CQLGlobalFunction`

```csharp
public class CQL.TypeSystem.CQLGlobalFunction
    : Attribute, _Attribute

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 


## `CQLNativeMemberFunctionAttribute`

```csharp
public class CQL.TypeSystem.CQLNativeMemberFunctionAttribute
    : Attribute, _Attribute

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IdDelimiter` | Delimiter |  | 
| `String` | Name |  | 


## `CQLNativeMemberIndexerAttribute`

```csharp
public class CQL.TypeSystem.CQLNativeMemberIndexerAttribute
    : Attribute, _Attribute

```

## `CQLNativeMemberPropertyAttribute`

```csharp
public class CQL.TypeSystem.CQLNativeMemberPropertyAttribute
    : Attribute, _Attribute

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IdDelimiter` | Delimiter |  | 
| `String` | Name |  | 


## `CQLTypeAttribute`

```csharp
public class CQL.TypeSystem.CQLTypeAttribute
    : Attribute, _Attribute

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `String` | Usage |  | 


## `GlobalFunctionSignature`

```csharp
public class CQL.TypeSystem.GlobalFunctionSignature

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type[]` | ParameterTypes |  | 
| `Type` | ReturnType |  | 


## `IGlobalFunction`

```csharp
public interface CQL.TypeSystem.IGlobalFunction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `GlobalFunctionSignature` | Signature |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Invoke(`Object[]` parameters) |  | 


## `IGlobalFunctionClosure`

```csharp
public interface CQL.TypeSystem.IGlobalFunctionClosure

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Invoke(`Object[]` parameters) |  | 


## `IGlobalFunctionClosure<TFunction>`

```csharp
public interface CQL.TypeSystem.IGlobalFunctionClosure<TFunction>
    : IGlobalFunctionClosure

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `TFunction` | Function |  | 


## `IMemberFunction`

```csharp
public interface CQL.TypeSystem.IMemberFunction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IMemberFunctionSignature` | Signature |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Invoke(`Object` this, `Object[]` parameters) |  | 


## `IMemberFunctionClosure`

```csharp
public interface CQL.TypeSystem.IMemberFunctionClosure

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | ThisObject |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Invoke(`Object[]` parameters) |  | 


## `IMemberFunctionClosure<TMemberFunction>`

```csharp
public interface CQL.TypeSystem.IMemberFunctionClosure<TMemberFunction>
    : IMemberFunctionClosure

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `TMemberFunction` | Function |  | 


## `IMemberFunctionSignature`

```csharp
public class CQL.TypeSystem.IMemberFunctionSignature

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type[]` | ParameterTypes |  | 
| `Type` | ReturnType |  | 
| `Type` | ThisType |  | 


## `IMemberIndexer`

```csharp
public interface CQL.TypeSystem.IMemberIndexer

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type[]` | FormalParameters |  | 
| `Type` | ReturnType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Get(`Object` this, `Object[]` indices) |  | 


## `IProperty`

```csharp
public interface CQL.TypeSystem.IProperty

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `Type` | ReturnType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Get(`Object` this) |  | 


## `IType`

```csharp
public interface CQL.TypeSystem.IType

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IMemberIndexer` | Indexer |  | 
| `IEnumerable<IProperty>` | Members |  | 
| `Type` | NativeType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IMemberFunction` | AddNativeFunction(`IdDelimiter` delimiter, `String` name, `MethodInfo` methodInfo) |  | 
| `IMemberIndexer` | AddNativeIndexer(`PropertyInfo` propertyInfo) |  | 
| `IProperty` | AddNativeProperty(`IdDelimiter` delimiter, `String` name, `PropertyInfo` propertyInfo) |  | 
| `IProperty` | GetByName(`IdDelimiter` delimiter, `String` name) |  | 


## `IType<TType>`

```csharp
public interface CQL.TypeSystem.IType<TType>
    : IType

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>` func) |  | 
| `IMemberFunction` | AddForeignFunction(`IdDelimiter` delimiter, `String` name, `Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>` func) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>` getter) |  | 
| `IMemberIndexer` | AddForeignIndexer(`Func<TType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>` getter) |  | 
| `IProperty` | AddForeignProperty(`IdDelimiter` delimiter, `String` name, `Func<TType, TProperty>` getter) |  | 


## `ITypeSystem`

```csharp
public interface CQL.TypeSystem.ITypeSystem

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | EmptyType |  | 
| `Type` | NullType |  | 
| `IEnumerable<IType>` | Types |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `BinaryOperation` | GetBinaryOperation(`BinaryOperator` op, `Type` left, `Type` right) |  | 
| `IEnumerable<BinaryOperation>` | GetBinaryOperations() |  | 
| `CoercionRule` | GetCoercionRule(`Type` original, `Type` casting) |  | 
| `IEnumerable<CoercionRule>` | GetImplicitlyCastChain(`Type` original, `Type` destinationType) |  | 
| `IEnumerable<Type>` | GetImplicitlyCastsTo(`Type` target) |  | 
| `IType` | GetTypeByName(`String` name) |  | 
| `IType` | GetTypeByNative(`Type` type) |  | 
| `IType<TType>` | GetTypeByNative() |  | 
| `IEnumerable<IType>` | GetTypesByPrefix(`String` prefix) |  | 
| `UnaryOperation` | GetUnaryOperation(`UnaryOperator` op, `Type` operand) |  | 


## `ITypeSystemBuilder`

```csharp
public interface CQL.TypeSystem.ITypeSystemBuilder

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddCoercionRule(`CoercionKind` kind, `Func<TOriginalType, TCastingType>` cast) |  | 
| `void` | AddContainsRule(`Func<TLeft, TRight, Boolean>` aggregate) |  | 
| `void` | AddEqualsRule(`Func<TOperand, TOperand, Boolean>` aggregate) |  | 
| `void` | AddLessRule(`Func<TOperand, TOperand, Boolean>` aggregate) |  | 
| `void` | AddRule(`UnaryOperator` op, `Func<TOperand, TResult>` func) |  | 
| `void` | AddRule(`BinaryOperator` op, `Func<TLeft, TRight, TResult>` aggregate) |  | 
| `IType<TType>` | AddType(`String` name, `String` usage, `TypeDefaultFlags` flags = All) |  | 
| `ITypeSystem` | Build() |  | 


## `MethodExtensions`

```csharp
public static class CQL.TypeSystem.MethodExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IMemberFunctionClosure<TMemberFunction>` | BindThis(this `TMemberFunction` function, `Object` this) |  | 
| `Boolean` | IfFunctionClosureTryGetFunctionType(this `Type` this, `GlobalFunctionSignature&` signature) |  | 
| `Boolean` | IfMemberFunctionClosureTryGetMethodSignature(this `Type` this, `IMemberFunctionSignature&` signature) |  | 


## `SystemDefaultFlags`

```csharp
public enum CQL.TypeSystem.SystemDefaultFlags
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | None |  | 
| `1` | HasBoolean |  | 
| `2` | HasIntegers |  | 
| `4` | HasDoubles |  | 
| `8` | HasStrings |  | 
| `15` | All |  | 


## `TypeDefaultFlags`

```csharp
public enum CQL.TypeSystem.TypeDefaultFlags
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | None |  | 
| `1` | Equals |  | 
| `2` | Comparable |  | 
| `4` | Numeric |  | 
| `7` | All |  | 


## `TypeSystemBuilderExtensions`

```csharp
public static class CQL.TypeSystem.TypeSystemBuilderExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddFromScan(this `ITypeSystemBuilder` this, `Type` type) |  | 
| `void` | AddFromScan(this `ITypeSystemBuilder` this, `Assembly` assembly) |  | 
| `void` | AddTypeScan(this `ITypeSystemBuilder` this, `Type` type) |  | 
| `Type` | Unvoid(this `Type` this) |  | 


## `TypeSystemExtensions`

```csharp
public static class CQL.TypeSystem.TypeSystemExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | AlignTypes(this `IValidationScope` this, `IExpression&` lhs, `IExpression&` rhs, `Func<Exception>` generateError) |  | 
| `IExpression` | ApplyCast(this `IEnumerable<CoercionRule>` this, `IExpression` expression, `IValidationScope` context, `Func<Exception>` generateError = null) |  | 


## `UnaryOperation`

```csharp
public class CQL.TypeSystem.UnaryOperation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | OperandType |  | 
| `Func<Object, Object>` | Operation |  | 
| `UnaryOperator` | Operator |  | 
| `Type` | ResultType |  | 


## `UnknownTypeException`

```csharp
public class CQL.TypeSystem.UnknownTypeException
    : Exception, ISerializable, _Exception

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Type` | UnknownType |  | 


## `Void`

```csharp
public class CQL.TypeSystem.Void

```

