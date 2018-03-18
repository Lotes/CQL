## `AutoCompletionSuggester`

```csharp
public class CQL.AutoCompletion.AutoCompletionSuggester
    : IAutoCompletionSuggester

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<Suggestion>` | GetSuggestions(`String` code) |  | 


## `Extensions`

```csharp
public static class CQL.AutoCompletion.Extensions

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | TokenType_Caret |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<IToken>` | ToList(this `CQLLexer` this) |  | 


## `IAutoCompletionSuggester`

```csharp
public interface CQL.AutoCompletion.IAutoCompletionSuggester

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<Suggestion>` | GetSuggestions(`String` code) |  | 


## `MyTokenStream`

```csharp
public class CQL.AutoCompletion.MyTokenStream

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | AtCaret() |  | 
| `MyTokenStream` | Move() |  | 
| `IToken` | Next() |  | 
| `IToken` | NextNext() |  | 


## `ParserStack`

```csharp
public class CQL.AutoCompletion.ParserStack

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ATNState` | Top |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Tuple<Boolean, ParserStack>` | Process(`ATNState` state) |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsCompatibleWith(`ATNState` state, `ParserStack` parserStack) |  | 


## `Suggestion`

```csharp
public class CQL.AutoCompletion.Suggestion

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Position |  | 
| `Int32` | SelectionLength |  | 
| `SuggestionType` | SuggestionType |  | 
| `String` | Text |  | 
| `String` | Usage |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Object` obj) |  | 
| `Int32` | GetHashCode() |  | 


## `SuggestionType`

```csharp
public enum CQL.AutoCompletion.SuggestionType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Token |  | 
| `1` | Variable |  | 
| `2` | Function |  | 
| `3` | Type |  | 


## `Token`

```csharp
public class CQL.AutoCompletion.Token

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `String` | Usage |  | 


