## `ErrorListener`

```csharp
public class CQL.ErrorHandling.ErrorListener
    : IErrorListener, IAntlrErrorListener<IToken>

```

Events

| Type | Name | Summary | 
| --- | --- | --- | 
| `EventHandler<LocateableException>` | ErrorDetected |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SyntaxError(`IRecognizer` recognizer, `IToken` offendingSymbol, `Int32` line, `Int32` charPositionInLine, `String` msg, `RecognitionException` e) |  | 
| `void` | TriggerError(`LocateableException` error) |  | 


## `IErrorListener`

```csharp
public interface CQL.ErrorHandling.IErrorListener
    : IAntlrErrorListener<IToken>

```

Events

| Type | Name | Summary | 
| --- | --- | --- | 
| `EventHandler<LocateableException>` | ErrorDetected |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | TriggerError(`LocateableException` error) |  | 


## `LocateableException`

```csharp
public class CQL.ErrorHandling.LocateableException
    : Exception, ISerializable, _Exception

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Length |  | 
| `Int32` | StartIndex |  | 


