Configurable Query Language (CQL)
=================================

![Example](example.png)

What is the problem?
--------------------

The raison d'être for this project is the typical filter problem:
On one side, your product delivers a dataset of complex types. On the other side
the user wants to **easily** query certain rows in the dataset. But you also want
to empower him to address **complex properties**.

Here is a solution!
-------------------

The two components, provided here, are

* a query language, that can be configured from a high-level point of view
  (like "my data has a field 'Name' of type 'String'") or/and from a low-level
  point of view (like "Use '+' to concat strings.")
* a WPF user control (using the language) with auto-completion and tooltips for
  syntactical and semantical errors. The query can be typed in using the keyboard
  OR by clicking all ingredients together.

Quickstart
----------

First, installation

```
nuget Install-Package CQL
```

Second, let me shortly explain the concepts. You actually need to provide three objects:

* the *query*, which can be edited by the user
* the *context*, which contains all variables, that are accessible for the query
* the *type system*, which setups the way the variables can be queried or can be combined

Third, study the following code snippet:

```csharp
//SETUP
var typeSystemBuilder = new TypeSystemBuilder();
var Ticket = typeSystemBuilder.AddType<Ticket>("Ticket", "The object of interest ;-) ");
Ticket.AddProperty(IdDelimiter.Dot, "id", t => t.Id);
Ticket.AddProperty(IdDelimiter.Dot, "owner", t => t.Owner);
var typeSystem = typeSystemBuilder.Build();

//DATA
var ticket1 = new Ticket() { Id = 123, Owner = "Me" };
var ticket2 = new Ticket() { Id = 124, Owner = "Myself" };
var ticket3 = new Ticket() { Id = 125, Owner = "I" };

//QUERY
var context = new EvaluationScope(typeSystem);
Assert.IsFalse(Queries.Evaluate("id > 123", ticket1, context));
Assert.IsFalse(Queries.Evaluate("id > 123 AND Owner = \"I\"", ticket2, context));
Assert.IsTrue(Queries.Evaluate("ID > 123 AND oWnEr = \"I\"", ticket3, context));
```

API
---

### Type system

#### Default types

There are 4 default types that can be setup without big effort using flags: booleans, integers, doubles and strings. Set them up like this:

```csharp
var typeSystemBuilder = new TypeSystemBuilder(SystemDefaultFlags.HasBoolean | ...);
```

#### Custom types

You can introduce new types with `ITypeSystemBuilder.AddType(NAME, USAGE[, FLAGS])`.

```csharp
typeSystemBuilder.AddType<Ticket>("Ticket", "Object of interest", ...);
```

The flags will trigger the builder to include Equals/Compare/Numeric operators if they do already exist.
Use the `TypeDefaultFlags.Equals|Comparable|Numeric` flags for this purpose.

After adding a type you can configure accessible properties, methods and indexer.

```csharp
var String = typeSystem.GetTypeByNative<string>(); //assuming string where already added

//add method
String.AddFunction(IdDelimiter.Dot, "length", str => str.Length);
//enables you to query name.length(), don't worry parameters are possible

//add property
String.AddProperty(IdDelimiter.Dot, "size", str => str.Length);
//enables you to query name.size

//add indexer
String.AddIndexer<int, string>((str, index) => str[index-1].ToString());
//enables you to access via index: name[1] = "M"
```

### Context

The context is actually a variable scope, containing string-object pairs.

The variable `this` has a special treatment: you are able to access its properties and methods directly.

Beside variables you can define functions.

```csharp
var context = new EvaluationScope(typeSystem);
context.DefineFunction<int, int, int>("max", (a, b) => Math.Max(a, b));
//enables you to call max(1, 2) = 2
```

### Query

The sequence of actions to run a query is `Parse` and `Evaluate`. Each step can throw exceptions to inform you if an error occurred.

```csharp
var context = ...;
var query = Queries.Parse("1 + 1 = 2");
var result = query.Evaluate(context);
//result == true
```

Current features
----------------

* configurable type system
* configurable context
* configurable WPF component
	* beginner mode
	* expert mode
	* auto completion
	* syntax highlighting