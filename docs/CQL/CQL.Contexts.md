## `IEvaluationScope`

```csharp
public interface CQL.Contexts.IEvaluationScope
    : IScope<Object, IEvaluationScope, IVariableDefinition>, IEnumerable<IVariableDefinition>, IEnumerable

```

## `IScope<TAbstraction, TSelf, TVariable>`

```csharp
public interface CQL.Contexts.IScope<TAbstraction, TSelf, TVariable>
    : IEnumerable<TVariable>, IEnumerable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `TSelf` | Parent |  | 
| `ITypeSystem` | TypeSystem |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `TVariable` | DefineVariable(`String` name, `TAbstraction` value) |  | 
| `TAbstraction` | GetPropertyValue(`TAbstraction` value, `IProperty` property) |  | 
| `Type` | GetValueType(`TAbstraction` value) |  | 
| `Boolean` | TryGetVariable(`String` name, `TVariable&` variable) |  | 


## `IValidationScope`

```csharp
public interface CQL.Contexts.IValidationScope
    : IScope<Type, IValidationScope, IVariableDeclaration>, IEnumerable<IVariableDeclaration>, IEnumerable

```

## `IVariable<TAbstraction>`

```csharp
public interface CQL.Contexts.IVariable<TAbstraction>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `TAbstraction` | Value |  | 


## `IVariableDeclaration`

```csharp
public interface CQL.Contexts.IVariableDeclaration
    : IVariable<Type>

```

## `IVariableDefinition`

```csharp
public interface CQL.Contexts.IVariableDefinition
    : IVariable<Object>

```

## `ScopeExtensions`

```csharp
public static class CQL.Contexts.ScopeExtensions

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ThisName |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddFromScan(this `IEvaluationScope` this, `Type` type) |  | 
| `void` | AddFromScan(this `IEvaluationScope` this, `Assembly` assembly) |  | 
| `void` | AddTypeScan(this `IEvaluationScope` this, `Type` type) |  | 
| `IVariableDefinition` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>` func) |  | 
| `IVariable<Object>` | DefineForeignGlobalFunction(this `EvaluationScope` this, `String` name, `Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>` func) |  | 
| `void` | DefineNativeGlobalFunction(this `IEvaluationScope` this, `String` name, `MethodInfo` info) |  | 
| `IVariableDefinition` | DefineThis(this `IEvaluationScope` this, `Object` value) |  | 
| `String` | NormalizeVariableName(`String` str) |  | 
| `IValidationScope` | ToValidationScope(this `IEvaluationScope` this) |  | 
| `Boolean` | TryGetThis(this `IEvaluationScope` this, `IVariableDefinition&` variable) |  | 


## `VariableExtensions`

```csharp
public static class CQL.Contexts.VariableExtensions

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IVariableDeclaration` | ToValidationVariable(this `IVariableDefinition` this) |  | 


