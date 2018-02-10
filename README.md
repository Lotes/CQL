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

First, installation... TODO

Second, let me shortly explain the concepts. You actually need to provide three objects:

* the *query*, which can be edited by the user
* the *context*, which contains all variables, that are accessible for the query
* the *type system*, which setups the way the variables can be queried or can be combined

Third, study the following code snippet:

```csharp
//SETUP
var tbuilder = new TypeSystemBuilder(true); //true = creates a type system with typically expected behaviour
tbuilder.AddType<Person>("Person", "Object of interest.");
var typeSystem = tbuilder.Build();

var builder = new ContextBuilder(typeSystem);
builder.AddField<Person, string>("Name", "Name of the person", subject => subject.Name, subject => subject == null);
builder.AddField<Person, int>("Age", "Age of person", subject => subject.Age, subject => false);
var context = builder.Build();

//USE
var query = Queries.Parse("age > 30", context);
var person1 = new Person(Name="Lotes", Age=31);
var person2 = new Person(Name="Amai", Age=30);
query.Evaluate<Person>(person1)); //returns true
query.Evaluate<Person>(person2)); //returns false
```

Features
--------

* configurable type system
* configurable context
* configurable WPF component
	* beginner mode
	* expert mode
	* auto completion
	* syntax highlighting