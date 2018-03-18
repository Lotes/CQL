## `EvaluationScope`

```csharp
public class CQL.Contexts.Implementation.EvaluationScope
    : IEvaluationScope, IScope<Object, IEvaluationScope, IVariableDefinition>, IEnumerable<IVariableDefinition>, IEnumerable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEvaluationScope` | Parent |  | 
| `ITypeSystem` | TypeSystem |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IVariableDefinition` | DefineVariable(`String` name, `Object` value) |  | 
| `IEnumerator<IVariableDefinition>` | GetEnumerator() |  | 
| `Object` | GetPropertyValue(`Object` value, `IProperty` property) |  | 
| `Type` | GetValueType(`Object` value) |  | 
| `Boolean` | TryGetVariable(`String` name, `IVariableDefinition&` variable) |  | 


## `ValidationScope`

```csharp
public class CQL.Contexts.Implementation.ValidationScope
    : IValidationScope, IScope<Type, IValidationScope, IVariableDeclaration>, IEnumerable<IVariableDeclaration>, IEnumerable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IValidationScope` | Parent |  | 
| `ITypeSystem` | TypeSystem |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IVariableDeclaration` | DefineVariable(`String` name, `Type` value) |  | 
| `IEnumerator<IVariableDeclaration>` | GetEnumerator() |  | 
| `Type` | GetPropertyValue(`Type` value, `IProperty` property) |  | 
| `Type` | GetValueType(`Type` value) |  | 
| `Boolean` | TryGetVariable(`String` name, `IVariableDeclaration&` variable) |  | 


## `VariableDeclaration`

```csharp
public class CQL.Contexts.Implementation.VariableDeclaration
    : IVariableDeclaration, IVariable<Type>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `Type` | Value |  | 


## `VariableDefinition`

```csharp
public class CQL.Contexts.Implementation.VariableDefinition
    : IVariableDefinition, IVariable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `Object` | Value |  | 


