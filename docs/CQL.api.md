#CQL


##AutoCompletion.AutoCompletionSuggester
            
Default implementation of .
        
###Methods


####Constructor
Creates an auto completion suggester from the evaluation scope.
> #####Parameters
> **context:** 


####GetSuggestions(System.String)
Given the code, let the suggester provide next tokens (suggestions).
> #####Parameters
> **code:** 

> #####Return value
> 

##AutoCompletion.Extensions
            
Auto completion extensions.
        
###Fields

####TokenType_Caret
Special id for the caret.
###Methods


####ToList(CQL.CQLLexer)
Converts lexer processings into a set of resulting tokens.
> #####Parameters
> **this:** 

> #####Return value
> 

##AutoCompletion.IAutoCompletionSuggester
            
Interface providing suggestion on incomplete code.
        
###Methods


####GetSuggestions(System.String)
Returns all possible parts, suggestions, how to continue the code.
> #####Parameters
> **code:** 

> #####Return value
> 

##AutoCompletion.MyTokenStream
            
Helper class for handling the token stream.
        
###Methods


####Constructor
Constructor.
> #####Parameters
> **tokens:** 

> **start:** 


####Next
Reads the next token. If the end is reached the type will be -1.
> #####Return value
> 

####NextNext
Same as Next(). But returns the token ofter the next token.
> #####Return value
> 

####AtCaret
Returns true, if the cursor is at the caret.
> #####Return value
> 

####Move
Forks a stream from current position.
> #####Return value
> 

##AutoCompletion.ParserStack
            
The parser stack is a helper class. It helps to find the right rule state. Different states have different suggestions.
        
###Properties

####Top
Tip of the stack.
###Methods


####IsCompatibleWith(Antlr4.Runtime.Atn.ATNState,CQL.AutoCompletion.ParserStack)
Checks whether the ATNState is compatiple with the given stack.
> #####Parameters
> **state:** 

> **parserStack:** 

> #####Return value
> 

####Constructor
Constructor.
> #####Parameters
> **states:** 


####Process(Antlr4.Runtime.Atn.ATNState)
One step of reading in ATNState.
> #####Parameters
> **state:** 

> #####Return value
> 

##AutoCompletion.Suggestion
            
A suggestion from the AutoCompleteSuggester.
        
###Fields

####
Operators
####
Variable names
####
Function names
####
Type names
###Properties

####Position
??? TODO
####SelectionLength
??? TODO
####Text
Text to be inserted when coosed by user.
####SuggestionType
Type of this suggestion.
####Usage
User documentation
###Methods


####Constructor
Constructor
> #####Parameters
> **suggestionType:** 

> **position:** 

> **selectionLength:** 

> **text:** 

> **usage:** 


####Equals(System.Object)
Equals...
> #####Parameters
> **obj:** 

> #####Return value
> 

####GetHashCode
Get hash code
> #####Return value
> 

##AutoCompletion.SuggestionType
            
Types of suggestion answers
        
###Fields

####Token
Operators
####Variable
Variable names
####Function
Function names
####Type
Type names

##AutoCompletion.Token
            
Token like operators or parentheses.
        
###Properties

####Name
Name of the token.
####Usage
What does they mean?
###Methods


####Constructor
Constructor.
> #####Parameters
> **name:** 

> **usage:** 


##Contexts.IEvaluationScope
            
An evaluation scope contains all variables (name and value) for user accessible objects during evaluation (runtime object).
        

##Contexts.Implementation.EvaluationScope
            
Default implementation of
        
###Properties

####Parent
Parent of the scope. If a lookup in this scope fails, search continues in the parent scope.
####TypeSystem
The typesystem applied to this scope.
###Methods


####Constructor
Creates an empty evaluation scope.
> #####Parameters
> **system:** 

> **parent:** 


####GetPropertyValue(System.Object,CQL.TypeSystem.IProperty)
Get the property value of a THIS value.
> #####Parameters
> **value:** THIS

> **property:** 

> #####Return value
> 

####GetValueType(System.Object)
Get the type of a value.
> #####Parameters
> **value:** 

> #####Return value
> 

####DefineVariable(System.String,System.Object)
Defines a variable in this scope.
> #####Parameters
> **name:** 

> **value:** 

> #####Return value
> 

####TryGetVariable(System.String,CQL.Contexts.IVariableDefinition@)
Lookups a variable in this and parent scopes. Returns TRUE and a variable if found, FALSE otherwise.
> #####Parameters
> **name:** 

> **variable:** 

> #####Return value
> 

####GetEnumerator
Enumerator over this scope.
> #####Return value
> 

##Contexts.Implementation.ValidationScope
            
Default implementation of
        
###Properties

####TypeSystem
Returns the applied type system.
####Parent
Returns the optional parent scope (can be null).
###Methods


####Constructor
Creates an empty validation scope.
> #####Parameters
> **system:** 

> **parent:** 


####DefineVariable(System.String,System.Type)
Defines a variable with name and type.
> #####Parameters
> **name:** 

> **value:** 

> #####Return value
> 

####GetEnumerator
Returns variable enumerator.
> #####Return value
> 

####GetPropertyValue(System.Type,CQL.TypeSystem.IProperty)
Returns the type of a property.
> #####Parameters
> **value:** 

> **property:** 

> #####Return value
> 

####GetValueType(System.Type)
Returns the type itself...
> #####Parameters
> **value:** 

> #####Return value
> 

####TryGetVariable(System.String,CQL.Contexts.IVariableDeclaration@)
Lookups for a variable definition. If variable exists returns TRUE and the variable, otherwise FALSE.
> #####Parameters
> **name:** 

> **variable:** 

> #####Return value
> 

##Contexts.Implementation.VariableDeclaration
            
Default implementation of
        
###Properties

####Name
Name of the definition.
####Value
Type of the definition.
###Methods


####Constructor
Creates a variable declaration
> #####Parameters
> **name:** 

> **value:** actual the type...


##Contexts.Implementation.VariableDefinition
            
Default implementation of
        
###Properties

####Name
Name of the definition.
####Value
Value of the definition.
###Methods


####Constructor
Creates a variable definition
> #####Parameters
> **name:** 

> **value:** 


##Contexts.IValidationScope
            
A validation scope is a dictionary of variables exposing only their type. The value is not important during validation process.
        

##Contexts.IVariable`1
            
An abstract variable.
            
> *See: T:System.Type*
   or 
> *See: T:System.Object*
  
        
###Properties

####Name
Name of the variable.
####Value
Abstract value.

##Contexts.IVariableDeclaration
            
Declaration of a variable. Just thy type, no value.
        

##Contexts.IVariableDefinition
            
Concrete variable with value.
        

##Contexts.ScopeExtensions
            
Extensions for scopes
        
###Fields

####ThisName
The name of the THIS object.
###Methods


####NormalizeVariableName(System.String)
Global name normalization function.
> #####Parameters
> **str:** 

> #####Return value
> 

####AddFromScan(CQL.Contexts.IEvaluationScope,System.Type)
Scans a type and its nested types for e.g. to extend the scope with global functions and variables.
> #####Parameters
> **this:** 

> **type:** 


####AddFromScan(CQL.Contexts.IEvaluationScope,System.Reflection.Assembly)
Scans an assembly for e.g. to extend the scope with global functions and variables.
> #####Parameters
> **this:** 

> **assembly:** 


####AddTypeScan(CQL.Contexts.IEvaluationScope,System.Type)
Checks type for e.g. to extend the scope with global functions and variables.
> #####Parameters
> **this:** 

> **type:** 


####DefineNativeGlobalFunction(CQL.Contexts.IEvaluationScope,System.String,System.Reflection.MethodInfo)
Defines a global function by its .
> #####Parameters
> **this:** 

> **name:** 

> **info:** 


####ToValidationScope(CQL.Contexts.IEvaluationScope)
Converts a concrete evaluation scope into a abstract validation scope.
> #####Parameters
> **this:** 

> #####Return value
> 

####TryGetThis(CQL.Contexts.IEvaluationScope,CQL.Contexts.IVariableDefinition@)
Lookup THIS
> #####Parameters
> **this:** 

> **variable:** 

> #####Return value
> 

####DefineThis(CQL.Contexts.IEvaluationScope,System.Object)
Define THIS.
> #####Parameters
> **this:** 

> **value:** 

> #####Return value
> 

####DefineForeignGlobalFunction``1(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``2(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``3(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``4(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``5(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``6(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``7(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``8(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``9(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``10(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``11(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``12(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``13(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``14(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``15(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

####DefineForeignGlobalFunction``16(CQL.Contexts.Implementation.EvaluationScope,System.String,System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15})
Defines a global function using a lambda function.
> #####Parameters
> **this:** 

> **name:** 

> **func:** 

> #####Return value
> 

##Contexts.VariableExtensions
            
Extensions for variables.
        
###Methods


####ToValidationVariable(CQL.Contexts.IVariableDefinition)
Converts a evaluation into a validation variable.
> #####Parameters
> **this:** 

> #####Return value
> 

##Contexts.IScope`3
            
A scope is a structure containing all accessible variables.
            should be 
> *See: T:System.Type*
   or 
> *See: T:System.Object*
  
            
            
        
###Properties

####TypeSystem
The type system applied to the scope.
####Parent
Inherited parent scope. If a requested variable was not found in this scope, the search continues in the parent scope(s).
###Methods


####TryGetVariable(System.String,`2@)
Searches for a variable in this scope by name. Returns TRUE and the variable if found, otherwise FALSE
> #####Parameters
> **name:** 

> **variable:** 

> #####Return value
> 

####DefineVariable(System.String,`0)
Defines oroverwrites a variable.
> #####Parameters
> **name:** 

> **value:** 

> #####Return value
> 

####GetPropertyValue(`0,CQL.TypeSystem.IProperty)
Returns the value of a given property.
> #####Parameters
> **value:** 

> **property:** 

> #####Return value
> 

####GetValueType(`0)
Returns the type of a given value.
> #####Parameters
> **value:** 

> #####Return value
> 

##EnumerableExtensions
            
Extensions for IEnumerable interface.
        
###Methods


####Plus``1(System.Collections.Generic.IEnumerable{``0},``0[])
Extends a IEnumerable by single elements.
> #####Parameters
> **this:** 

> **added:** 

> #####Return value
> 

##HashExtensions
            
Extensions for hashing.
        
###Methods


####GetCommonHashCode(System.Collections.Generic.IEnumerable{System.Object})
Given a set of objects, computes a combined hash value. Order matters!
> #####Parameters
> **this:** 

> #####Return value
> 

##ErrorHandling.IErrorListener
            
Listens to ANTLR errors and forwards them as LocateableExceptions ().
        
###Methods


####TriggerError(CQL.ErrorHandling.LocateableException)
Fires a locateable exception via the event.
> #####Parameters
> **error:** 


##ErrorHandling.ErrorListener
            
Concrete error listener to wrap ANTLR exceptions to locateable exception.
        
###Methods


####SyntaxError(Antlr4.Runtime.IRecognizer,Antlr4.Runtime.IToken,System.Int32,System.Int32,System.String,Antlr4.Runtime.RecognitionException)
Will be called by ANTLR when a syntax error was detected. Wraps the error into a locateable exception.
> #####Parameters
> **recognizer:** 

> **offendingSymbol:** 

> **line:** 

> **charPositionInLine:** 

> **msg:** 

> **e:** 


####TriggerError(CQL.ErrorHandling.LocateableException)
Triggers event with given exception.
> #####Parameters
> **error:** 


##ErrorHandling.LocateableException
            
Exception with positional information. Where in the user query was an error detected?
        
###Fields

####StartIndex
first character index
####Length
Length of the errornous piece of code.
###Methods


####Constructor
Creates a exception using a
> #####Parameters
> **location:** 

> **message:** 

> **innerException:** 


####Constructor
Creates an exception using the start and end character index.
> #####Parameters
> **startIndex:** 

> **endIndex:** 

> **message:** 

> **innerException:** 


##SyntaxTree.ArrayAccessExpression
            
Represents an array index accessment.
        
###Properties

####Indices
All indices passed to the array accessment.
####Location
Position in the user query text of this AST node.
####SemanticType
Type of the resulting value.
####ThisExpression
THIS expression, which must be an array type after validation.
###Methods


####Constructor
Creates a AST node for array index accessing.
> #####Parameters
> **location:** 

> **primary:** 

> **indices:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validates THIS, which must have an indexer. If parameter count or type does not match, throws a .
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates the THIS expression and applies the evaluated indices as an array access.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.CastExpression
            
AST node representing one type cast.
        
###Fields

####Kind
Implicit or explicit cast? Implicits will be created during validation process. Explicits can be used by the user.
####CastTypeName
The type name which has to be validated.
###Properties

####Expression
The source expression which has to be converted.
####Location
Position in the query text.
####SemanticType
Type of the cast, e.g. the casting type itself.
###Methods


####Constructor
Constructor.
> #####Parameters
> **parserContext:** 

> **kind:** 

> **castTypeName:** 

> **expression:** 


####Constructor
Constructor.
> #####Parameters
> **rule:** 

> **validatedExpression:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Outputs user-friendly representation as string.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation: Checks whether the type really exists and whether the conversion is allowed.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation: Casts the input value.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.IdDelimiter
            
Types of delimiters
        
###Fields

####Slash
Slash, '/'
####Dot
Dot, '.'
####SingleArrow
Arrow, '->'
####Hash
Hash, '#'
####Dollar
Dollar, '$'

##SyntaxTree.IExpression
            
An expression is a syntax node that can be validated and evaluated. During the validation process, the syntax tree could be extended with further nodes and annotated with (semantic) types.
            
> *See also: T:CQL.SyntaxTree.ISyntaxTreeNode
        
###Properties

####SemanticType
Initially is null! After calling the method the actual type will be set.
###Methods


####Validate(CQL.Contexts.IValidationScope)
Validates this node and sets the semantic type.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates this node to a value of the validated semantic type.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.IExpression`1
            
The generic side of an expression. Subtype from this interface!
            
        

##SyntaxTree.IntegerLiteralExpression
            
Represents an integer literal.
        
###Fields

####Value
The actual value.
###Properties

####Location
Position in the user query text.
####SemanticType
Validated type, always Int32.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **value:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation: Returns the value.
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Outputs a user-friendly string of this expression.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation: Nothing to do.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.IParserLocation
            
Position of a AST node in the query text.
        
###Properties

####StartIndex
Index of the first character.
####StopIndex
Index of the last character.

##SyntaxTree.ISyntaxTreeNode
            
Base class of all abstract syntax tree nodes (AST).
        
###Properties

####Location
String position of the node in the input text (from...to).
###Methods


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals of a AST node.
> #####Parameters
> **node:** 

> #####Return value
> 

####
The validation checks the node for validaty and may replace it by conversion nodes. The result returns an extended AST.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.ISyntaxTreeNode`1
            
Actual generic base of all AST nodes.
            
        
###Methods


####Validate(CQL.Contexts.IValidationScope)
The validation checks the node for validaty and may replace it by conversion nodes. The result returns an extended AST.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.MemberExpression
            
AST node representing a member usage outgoing from a this object.
        
###Properties

####Delimiter
Delimiter outgoing from the THIS object.
####MemberName
Name of the member ofter the delimiter.
####ThisExpression
The actual THIS expression looking for member.
####Location
Position of this expression in the query text.
####SemanticType
Validated type of the member.
###Methods


####Constructor
Constructor.
> #####Parameters
> **location:** 

> **this:** 

> **delimiter:** 

> **memberName:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation, checking whether the member is a valid property.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation.
> #####Parameters
> **context:** 

> #####Return value
> 

####ToString
Outputs a user-friendly representation of this expression.
> #####Return value
> 

##SyntaxTree.ParserLocation
            
Positional helper, containing all information to address an expression in the query text.
        
###Fields

####EmptyContext
Default instance with invalid position (0,0).
###Properties

####StartIndex
Starting character index.
####StopIndex
Stopping character index.
###Methods


####Constructor
Constructor.
> #####Parameters
> **startIndex:** 

> **stopIndex:** 


####op_Implicit(Antlr4.Runtime.ParserRuleContext)~CQL.SyntaxTree.ParserLocation
Implicit conversion form parser context to ParserLocation.
> #####Parameters
> **ctx:** 


####
Computes the length of a range.
> #####Parameters
> **loc:** 

> #####Return value
> 

##SyntaxTree.ParserLocationExtensions
            
Extensions for parser locations
        
###Methods


####GetLength(CQL.SyntaxTree.IParserLocation)
Computes the length of a range.
> #####Parameters
> **loc:** 

> #####Return value
> 

##SyntaxTree.SyntaxTreeExtensions
            
Extension for the syntax tree.
        
###Methods


####WasValidated(CQL.SyntaxTree.IExpression)
Check whether semantic type was already set
> #####Parameters
> **this:** 

> #####Return value
> 

####StructurallyEquals(System.Collections.Generic.IEnumerable{CQL.SyntaxTree.ISyntaxTreeNode},System.Collections.Generic.IEnumerable{CQL.SyntaxTree.ISyntaxTreeNode})
Deep equals sets of syntax trees.
> #####Parameters
> **this:** 

> **other:** 

> #####Return value
> 

####IfArrayTryGetElementType(CQL.SyntaxTree.IExpression,System.Type@)
Get the element type if the expression is an array expression.
> #####Parameters
> **this:** 

> **elementType:** 

> #####Return value
> 

##SyntaxTree.VariableExpression
            
An expression that addresses a variable from the EvaluationScope.
            
> *See also: T:CQL.SyntaxTree.IExpression
            
> *See also: T:CQL.Contexts.Implementation.EvaluationScope
        
###Properties

####Identifier
The variable identifier of this expresssion.
####Location
The location of this expression, when parsed from a user query.
####SemanticType
The semantic type of this variable expression, after it was parsed and validated.
###Methods


####Constructor
Initializes a new instance of the class.
> #####Parameters
> **location:** The location when parsed from a user query.

> **identifier:** The identifier addressing the variable in the evaluation scope.


####ToString
Outputs a user-readable representation of this variable expression.
> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** The node.

> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation of expression: checks whether the variable is known and returns its type.
> #####Parameters
> **context:** The context.

> #####Return value
> 
> #####Exceptions
> **CQL.ErrorHandling.LocateableException:** Unknown field!


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation of expression: reads the value of the variable from the given context.
> #####Parameters
> **context:** The context.

> #####Return value
> 
> #####Exceptions
> **CQL.ErrorHandling.LocateableException:** Unknown field!


##SyntaxTree.ArrayExpression
            
Represents an array literal.
        
###Properties

####Elements
Expressions of all elements.
####Location
Position of the literal in the user query test.
####SemanticType
Validated type of the array.
###Methods


####Constructor
Creates a ArrayExpression.
> #####Parameters
> **context:** 

> **elements:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Outputs user friendly string representing this expression.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validates expression. Trys to align types.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates the value of this array expression.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.BinaryOperationExpression
            
AST node representing binary operator expressions (with two operands).
        
###Fields

####Operator
Binary operator.
###Properties

####LeftExpression
Operand on the left side of the operator.
####RightExpression
Operand on the right side of the operand.
####SemanticType
Validated type.
####Location
Position of this expression in the query text.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **operator:** 

> **leftExpression:** 

> **rightExpression:** 


####ToString
Outputs user-friendly representation string.
> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation: determines the actual operation and its return type.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation: Executes the binary operation.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.BinaryOperator
            
Types of binary operation.
        
###Fields

####Or
Logical OR
####And
Logical AND
####Equals
Equality
####NotEquals
Negated equality
####GreaterThan
Greater than relation
####GreaterThanEquals
Greater or equals relation
####LessThan
Less than relation
####LessThanEquals
Less or equals than relation.
####Add
Addition of numerics or concat for strings
####Sub
Substraction
####Mul
Multiplication
####Mod
Modulo
####Div
Division
####Contains
Contains check on strings
####DoesNotContain
Does not contain check on strings.
####Is
Type and Null check
####In
Element IN Array
####NotIn
Element NOT IN Array

##SyntaxTree.BooleanLiteralExpression
            
Expression representing boolean constants.
        
###Fields

####Value
The actual value, true or false.
###Properties

####Location
The position of the literal in the user query text.
####SemanticType
The type of a boolean literal (is always typeof(bool)).
###Methods


####Constructor
Creates a AST node for boolean literal.
> #####Parameters
> **context:** 

> **value:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates literal to its value.
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
AST to string.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validates literal.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.ConditionalExpression
            
AST node representing the ternary ?-operator.
        
###Properties

####Condition
Condition expression.
####Then
Then expression.
####Else
Else expression.
####Location
Location in the query text
####SemanticType
Validated type.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **condition:** 

> **then:** 

> **else:** 


####ToString
User-friendly representation as string.
> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation... does only execute the branch with the corressponding condition
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.FloatingPointLiteralExpression
            
AST node representing a decimal number.
        
###Fields

####Value
The actual value.
###Properties

####Location
Position of the expression in the query text.
####SemanticType
Validated type... always double here.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **value:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation returning the value.
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
User-friendly representation as string.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation... nothing to do here.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.EmptyExpression
            
AST node representing the EMPTY expression.
        
###Properties

####Location
Position of the expression in the query text.
####SemanticType
Validated type.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation...
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Outputs a user-friendly representation as string.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation...
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.FunctionCallExpression
            
A method call consists of a THIS expression (its value should contain a member function closure) and zero to several parameter expressions.
        
###Fields

####ThisExpression
The evaluated THIS expression must evaluate to a member function closure.
###Properties

####Parameters
Contains the expressions of the member function call parameters.
####Location
Contains the position of the member function call if parsed from a user query.
####SemanticType
After validation, this property will contain the return type of the member function call.
###Methods


####Constructor
Creates a member function call expression.
> #####Parameters
> **context:** 

> **this:** 

> **parameters:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals for this syntax node.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Creates a user-readable string, representing the member function call.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validates this function call, by checking the signature, parameter count. Sets the semantic type to the return type of the found function.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates the THIS expression first. If the result is a function closure, the closure will be invoked with the evaluated parameters.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.NullExpression
            
AST node representing the NULL literal.
        
###Properties

####Location
Position in the query text.
####SemanticType
Validated type.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation. Nothing to do.
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
User-friendly representation.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.ParenthesisExpression
            
AST node representing a parenthesed expression (is important to transform back to a string!).
        
###Properties

####Expression
Inner expression.
####Location
Position in the query text.
####SemanticType
Validated type
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **expression:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
User-friendly representation of this expression.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation...
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation...
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.Query
            
Represents the top-level boolean expression.
        
###Properties

####Expression
Queries expression. Must be boolean.
####Location
Position in the user query text.
###Methods


####Constructor

> #####Parameters
> **context:** 

> **expression:** not null


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
AST to string.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validates the query. If the expression is not boolean, throws a .
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluates the query.
> #####Parameters
> **subject:** 

> #####Return value
> 

##SyntaxTree.StringLiteralExpression
            
AST node representing a string literal.
        
###Fields

####Value
Actual value of the literal (unescaped).
###Properties

####Location
Location of this literal in query text.
####SemanticType
The validated type... always System.String
###Methods


####Constructor
Constructor
> #####Parameters
> **context:** 

> **value:** 


####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation by returning the string value.
> #####Parameters
> **context:** 

> #####Return value
> 

####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Escaped string literal.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation, nothing important for strings.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.UnaryOperationExpression
            
AST node, representing a unary operation.
        
###Fields

####Operator
The applied operator.
####operation
The operation behind the operator. Will be set during validation.
###Properties

####Expression
The expression on whcih the unary operator will be applied.
####Location
Location in the query text of this AST node.
####SemanticType
The validated type of this expression.
###Methods


####Constructor
Constructor.
> #####Parameters
> **context:** 

> **operator:** 

> **expression:** 


####StructurallyEquals(CQL.SyntaxTree.ISyntaxTreeNode)
Deep equals.
> #####Parameters
> **node:** 

> #####Return value
> 

####ToString
Outputs a user-friendly string representation of this expression.
> #####Return value
> 

####Validate(CQL.Contexts.IValidationScope)
Validation: Determine the actual operation and return type of this unary operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####Evaluate(CQL.Contexts.IEvaluationScope)
Evaluation: execute the unary operation.
> #####Parameters
> **context:** 

> #####Return value
> 

##SyntaxTree.UnaryOperator
            
Unary operator types
        
###Fields

####Plus
Positive sign
####Minus
Negative sign
####Not
Not operator

##TypeExtensions
            
Extensions defined for types.
        
###Methods


####IsNumeric(System.Type)
Check whether a type is numeric.
> #####Parameters
> **this:** 

> #####Return value
> 

####IfEnumerableTryGetElementType(System.Type,System.Type@)
Checks whether the type contains the interface. If yes, returns its element type and returns true. If no, returns false.
> #####Parameters
> **this:** 

> **elementType:** 

> #####Return value
> 

####GetCommonBaseClass(System.Collections.Generic.IEnumerable{System.Type})
Given a set of types, trys to determine the common type.
> #####Parameters
> **this:** 

> #####Return value
> 

##TypeSystem.CQLGlobalFunction
            
Marks a static function as global function in a evaluation scope.
        
###Properties

####Name
The name of the function within the evaluation scope.
###Methods


####Constructor
Creates the attribute.
> #####Parameters
> **name:** 


##TypeSystem.CQLNativeMemberFunctionAttribute
            
Marks a member function to be registered in the type system builder.
        
###Properties

####Name
Name of the method within the type system.
####Delimiter
The delimiter to access the method.
###Methods


####Constructor
Creates the attribute
> #####Parameters
> **name:** 

> **delimiter:** 


##TypeSystem.CQLNativeMemberIndexerAttribute
            
Marks an indexer property to be registered in the type and type system builder.
        

##TypeSystem.CQLNativeMemberPropertyAttribute
            
Marks a class property to be registered as native property for a CQL type.
        
###Properties

####Name
Name of the property within the type.
####Delimiter
Delimiter to this property.
###Methods


####Constructor
creates the attribute
> #####Parameters
> **name:** 

> **delimiter:** 


##TypeSystem.CQLTypeAttribute
            
Marks a class as CQL type. Classes with this attribute can be scanned by the type system builder .
        
###Properties

####Name
Name of the type within the type system
####Usage
Usage documentation
###Methods


####Constructor
Creates an attribute.
> #####Parameters
> **name:** 

> **usage:** 


##TypeSystem.GlobalFunctionSignature
            
Signatrue of a glbal function.
        
###Properties

####ReturnType
the return type.
####ParameterTypes
The parameter types.
###Methods


####Constructor
Creates a type signature of a global function.
> #####Parameters
> **returnType:** 

> **parameterTypes:** 


##TypeSystem.IGlobalFunctionClosure
            
The closure of a global function...
        
###Properties

####
The bound global function.
###Methods


####Invoke(System.Object[])
Calls the bound global function.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.IMemberFunctionSignature
            
This, Parameters and Return type of a member function.
        
###Properties

####ThisType
This type
####ReturnType
Return type
####ParameterTypes
Parameter types
###Methods


####Constructor
Create a signature.
> #####Parameters
> **thisType:** 

> **returnType:** 

> **parameterTypes:** 


##TypeSystem.Implementation.ForeignIndexer
            
A foreign indexer is a lambda function used as index property.
        
###Properties

####FormalParameters
Types of the indices.
####ReturnType
Return type.
###Methods


####Constructor
Creates a foreign indexer.
> #####Parameters
> **formalParameters:** 

> **returnType:** 

> **getter:** 


####Get(System.Object,System.Object[])
Evaluates the foreign lambda function on the THIS object with a set of indices.
> #####Parameters
> **this:** 

> **indices:** 

> #####Return value
> 

##TypeSystem.Implementation.ForeignProperty
            
A foreign property is a lambda function extracting information out of a THIS object.
        
###Properties

####Delimiter
Delimiter of the property.
####Name
Name of the proeprty.
####ReturnType
Return type of this property.
###Methods


####Constructor
Creates a property using a lambda.
> #####Parameters
> **delimiter:** 

> **name:** 

> **returnType:** 

> **getter:** 


####Get(System.Object)
Extracts the property value out of the THIS object.
> #####Parameters
> **this:** 

> #####Return value
> 

##TypeSystem.Implementation.LambdaGlobalFunction`1
            
Defines a global function by a lambda function.
            
        
###Methods


####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`2
            
Defines a global function by a lambda function.
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`3
            
Defines a global function by a lambda function.
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`4
            
Defines a global function by a lambda function.
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`5
            
Defines a global function by a lambda function.
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`6
            
Defines a global function by a lambda function.
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`7
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`8
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`9
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`10
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`11
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`12
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`13
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`14
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`15
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.LambdaGlobalFunction`16
            
Defines a global function by a lambda function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global lambda function.

##TypeSystem.Implementation.NativeGlobalFunction`1
            
Defines a global function by a native MethodInfo.
            
        
###Methods


####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`2
            
Defines a global function by MethodInfo.
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`3
            
Defines a global function by MethodInfo.
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`4
            
Defines a global function by MethodInfo.
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`5
            
Defines a global function by MethodInfo.
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`6
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`7
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`8
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`9
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`10
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`11
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`12
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`13
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`14
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`15
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunction`16
            
Defines a global function by MethodInfo.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a global native function.

##TypeSystem.Implementation.NativeGlobalFunctionExtensions
            
Extensions for native global functions.
        
###Methods


####CreateByMethodInfo(System.Reflection.MethodInfo)
Converts a MethodInfo into a global function.
> #####Parameters
> **info:** 

> #####Return value
> 

##TypeSystem.Implementation.LambdaGlobalFunction
            
A global function defined using a lambda function.
        
###Properties

####Signature
Type signature of the function.
###Methods


####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Creates a global lambda function.

####Constructor
Abstract constructor.
> #####Parameters
> **formalParameters:** 

> **returnType:** 

> **body:** 


####Invoke(System.Object[])
Calls the global function.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.Implementation.ForeignMemberFunction`2
            
Types wrapping foreign member function.
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`3
            
Types wrapping foreign member function.
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`4
            
Types wrapping foreign member function.
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`5
            
Types wrapping foreign member function.
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`6
            
Types wrapping foreign member function.
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`7
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`8
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`9
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`10
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`11
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`12
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`13
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`14
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`15
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`16
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.ForeignMemberFunction`17
            
Types wrapping foreign member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


##TypeSystem.Implementation.NativeMemberFunction`2
            
Types wrapping native member function.
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`3
            
Types wrapping native member function.
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`4
            
Types wrapping native member function.
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`5
            
Types wrapping native member function.
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`6
            
Types wrapping native member function.
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`7
            
Types wrapping native member function.
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`8
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`9
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`10
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`11
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`12
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`13
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`14
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`15
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`16
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunction`17
            
Types wrapping native member function.
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


##TypeSystem.Implementation.NativeMemberFunctionExtensions
            
Extensions for native member functions.
        
###Methods


####CreateByMethodInfo(System.Type,System.Reflection.MethodInfo)
Converts a MethodInfo into a native member function.
> #####Parameters
> **this:** 

> **info:** 

> #####Return value
> 

##TypeSystem.Implementation.NativeGlobalFunction
            
Abstract base class of all native global functions.
        
###Properties

####Signature
Type signature.
###Methods


####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####Constructor
Creates a global native function.

####
Converts a MethodInfo into a global function.
> #####Parameters
> **info:** 

> #####Return value
> 

####Constructor
Creates a native global function from a MethodInfo.
> #####Parameters
> **method:** 


####Invoke(System.Object[])
Calls the native function using the concrete parameters.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.Implementation.NativeIndexer
            
A native indexer is a PropertyInfo of the native type of the corressponding .
        
###Properties

####FormalParameters
Indices types.
####ReturnType
Return type.
###Methods


####Constructor
Creates a native indexer.
> #####Parameters
> **property:** 


####Get(System.Object,System.Object[])
Evaluates the indexer property.
> #####Parameters
> **this:** 

> **indices:** 

> #####Return value
> 

##TypeSystem.Implementation.NativeProperty
            
A native property is a property of an by accessing a real of the type TType.
        
###Properties

####Name
Name of the property.
####ReturnType
Return type.
###Methods


####Constructor
Creates a native property.
> #####Parameters
> **name:** 

> **property:** 


####Get(System.Object)
Returns the property value of the THIS parameter.
> #####Parameters
> **this:** 

> #####Return value
> 

##TypeSystem.Implementation.Type`1
            
The default implementation of
            
        
###Properties

####Name
Name under which the native type was registered.
####Usage
Usage documentation of this type.
####NativeType
The CSharp type.
####Indexer
Returns the registered indexer of this type, or null.
####Members
Returns all members of this type.
###Methods


####AddForeignIndexer``2(System.Func{`0,``0,``1})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``3(System.Func{`0,``0,``1,``2})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``4(System.Func{`0,``0,``1,``2,``3})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``5(System.Func{`0,``0,``1,``2,``3,``4})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``6(System.Func{`0,``0,``1,``2,``3,``4,``5})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``7(System.Func{`0,``0,``1,``2,``3,``4,``5,``6})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``8(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``9(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``10(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``11(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``12(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``13(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``14(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``15(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``16(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15})
Add a indexer using a lambda function.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignFunction``1(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``2(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``3(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``4(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``5(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``6(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``7(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``8(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``9(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``10(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``11(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``12(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``13(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``14(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``15(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``16(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15})
Add a lambda function as foreign member function to a type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####Constructor
Create a new type.
> #####Parameters
> **name:** 

> **usage:** 


####AddForeignProperty``1(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0})
Adds a lambda function to create a foreign property.
> #####Parameters
> **delimiter:** 

> **name:** 

> **getter:** 

> #####Return value
> 

####GetByName(CQL.SyntaxTree.IdDelimiter,System.String)
Get a property by its name and delimiter.
> #####Parameters
> **delimiter:** 

> **name:** 

> #####Return value
> 

####AddNativeFunction(CQL.SyntaxTree.IdDelimiter,System.String,System.Reflection.MethodInfo)
Adds a native function. The function must be a MethodInfo of a real method of the native type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **methodInfo:** 

> #####Return value
> 

####AddNativeProperty(CQL.SyntaxTree.IdDelimiter,System.String,System.Reflection.PropertyInfo)
Adds a native MethodInfo which is a real method of the native type.
> #####Parameters
> **delimiter:** 

> **name:** 

> **propertyInfo:** 

> #####Return value
> 

####AddNativeIndexer(System.Reflection.PropertyInfo)
Adds a real indexer property of the native type.
> #####Parameters
> **propertyInfo:** 

> #####Return value
> 

##TypeSystem.Implementation.NativeMemberFunction
            
Native member functions are members of the original ("this") type. They are declared in the class definition of the THIS type. Use attribute to mark a function for a type in the typesystem.
        
###Properties

####Signature
Summarizes the signature of the function.
###Methods


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####Constructor
Creates a native member function.
> #####Parameters
> **info:** 


####
Converts a MethodInfo into a native member function.
> #####Parameters
> **this:** 

> **info:** 

> #####Return value
> 

####Constructor
Creates a native member function. Requires the actual THIS type and the of the requested function.
> #####Parameters
> **this:** 

> **method:** 


####Invoke(System.Object,System.Object[])
Invokes the function by passing the THIS object and the parameter objects.
> #####Parameters
> **this:** 

> **parameters:** 

> #####Return value
> 

##TypeSystem.Implementation.ForeignMemberFunction
            
Foreign member functions are lambda functions that extend types without changing its class definition.
        
###Properties

####Signature
The signature of the foreign member function.
###Methods


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function.
> #####Parameters
> **body:** 


####Constructor
Creates a foreign member function. Needs the interface types and a lambda function with this signature.
> #####Parameters
> **thisType:** 

> **formalParameters:** 

> **returnType:** 

> **body:** 


####Invoke(System.Object,System.Object[])
Calls the lambda function, passing the THIS object and the parameters.
> #####Parameters
> **this:** 

> **parameters:** 

> #####Return value
> 

##TypeSystem.Implementation.TypeSystem
            
The default implementation of
        
###Properties

####Types
Returns all registered types.
####NullType
Returns the null type.
####EmptyType
Returns the empty type.
###Methods


####AddType``1(System.String,System.String)
Adds a new native type.
> #####Parameters
> **name:** 

> **usage:** 

> #####Return value
> 

####AddCoercionRule``2(CQL.TypeSystem.CoercionKind,System.Func{``0,``1})
Adds a new coercion rule. Trys to avoid cyclic implicit casts chains.
> #####Parameters
> **kind:** 

> **cast:** 


####AddRule``3(CQL.SyntaxTree.BinaryOperator,System.Func{``0,``1,``2})
Adds binary rules.
> #####Parameters
> **op:** 

> **aggregate:** 


####AddRule``2(CQL.SyntaxTree.UnaryOperator,System.Func{``0,``1})
Adds unary rules.
> #####Parameters
> **op:** 

> **func:** 


####GetBinaryOperation(CQL.SyntaxTree.BinaryOperator,System.Type,System.Type)
Lookup for binary operations.
> #####Parameters
> **op:** 

> **left:** 

> **right:** 

> #####Return value
> 

####GetUnaryOperation(CQL.SyntaxTree.UnaryOperator,System.Type)
Lookup for unary operations.
> #####Parameters
> **op:** 

> **operand:** 

> #####Return value
> 

####GetCoercionRule(System.Type,System.Type)
Returns a coercion rule if given, null otherwise.
> #####Parameters
> **original:** 

> **casting:** 

> #####Return value
> 

####GetTypeByName(System.String)
get a registered type by its name (case insensitive)
> #####Parameters
> **name:** 

> #####Return value
> 

####GetTypesByPrefix(System.String)
Get all types matching a prefix (case insensitve).
> #####Parameters
> **prefix:** 

> #####Return value
> 

####GetImplicitlyCastChain(System.Type,System.Type)
Returns a possible implicit cast chain.
> #####Parameters
> **original:** 

> **destinationType:** 

> #####Return value
> 

####GetTypeByNative(System.Type)
Get a type by its native representation.
> #####Parameters
> **type:** 

> #####Return value
> 

####GetBinaryOperations
Returns all registered binary operations.
> #####Return value
> 

####GetImplicitlyCastsTo(System.Type)
Gets all source types for a given target type, that can be gained by implicit cast.
> #####Parameters
> **target:** 

> #####Return value
> 

####GetTypeByNative``1
Returns a registered type by its native representation.
> #####Return value
> 

####Constructor
Creates a type system builder.
> #####Parameters
> **flags:** Setups the initial types.


####
Registers a native type to be known under the given name.
> #####Parameters
> **name:** 

> **usage:** 

> **flags:** 

> #####Return value
> 

####
Adds a coercion rule.
> #####Parameters
> **kind:** 

> **cast:** 


####
Adds a contains rule.
> #####Parameters
> **aggregate:** 


####
Adds equality rules
> #####Parameters
> **aggregate:** 


####
Adds "less" rules
> #####Parameters
> **aggregate:** 


####
Eventually builds the type system.
> #####Return value
> 

####
Add unary rules.
> #####Parameters
> **op:** 

> **func:** 


####
Adds binary rules.
> #####Parameters
> **op:** 

> **aggregate:** 


##TypeSystem.Implementation.TypeSystem.Null
            
Default NULL class
        
###Properties

####
Returns the null type.

##TypeSystem.Implementation.TypeSystem.Empty
            
Default EMPTY class
        
###Properties

####
Returns the empty type.

##TypeSystem.Implementation.TypeSystemBuilder
            
Default implementation of
        
###Methods


####Constructor
Creates a type system builder.
> #####Parameters
> **flags:** Setups the initial types.


####AddType``1(System.String,System.String,CQL.TypeSystem.TypeDefaultFlags)
Registers a native type to be known under the given name.
> #####Parameters
> **name:** 

> **usage:** 

> **flags:** 

> #####Return value
> 

####AddCoercionRule``2(CQL.TypeSystem.CoercionKind,System.Func{``0,``1})
Adds a coercion rule.
> #####Parameters
> **kind:** 

> **cast:** 


####AddContainsRule``2(System.Func{``0,``1,System.Boolean})
Adds a contains rule.
> #####Parameters
> **aggregate:** 


####AddEqualsRule``1(System.Func{``0,``0,System.Boolean})
Adds equality rules
> #####Parameters
> **aggregate:** 


####AddLessRule``1(System.Func{``0,``0,System.Boolean})
Adds "less" rules
> #####Parameters
> **aggregate:** 


####Build
Eventually builds the type system.
> #####Return value
> 

####AddRule``2(CQL.SyntaxTree.UnaryOperator,System.Func{``0,``1})
Add unary rules.
> #####Parameters
> **op:** 

> **func:** 


####AddRule``3(CQL.SyntaxTree.BinaryOperator,System.Func{``0,``1,``2})
Adds binary rules.
> #####Parameters
> **op:** 

> **aggregate:** 


##TypeSystem.IType`1
            
A registered type in the type system, representing a C# native type.
            the native type
        
###Methods


####AddForeignIndexer``2(System.Func{`0,``0,``1})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``3(System.Func{`0,``0,``1,``2})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``4(System.Func{`0,``0,``1,``2,``3})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``5(System.Func{`0,``0,``1,``2,``3,``4})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``6(System.Func{`0,``0,``1,``2,``3,``4,``5})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``7(System.Func{`0,``0,``1,``2,``3,``4,``5,``6})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``8(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``9(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``10(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``11(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``12(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``13(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``14(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``15(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignIndexer``16(System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15})
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####AddForeignFunction``1(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``2(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``3(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``4(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``5(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``6(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``7(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``8(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``9(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``10(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``11(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``12(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``13(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``14(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``15(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignFunction``16(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15})
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####AddForeignProperty``1(CQL.SyntaxTree.IdDelimiter,System.String,System.Func{`0,``0})
Adds a foreign (lambda) property.
> #####Parameters
> **delimiter:** 

> **name:** 

> **getter:** 

> #####Return value
> 

##TypeSystem.SystemDefaultFlags
            
Setup flags for the type system initialization.
        
###Fields

####None
No default behaviour.
####HasBoolean
Add boolean type to the type system.
####HasIntegers
Add integer type to the type system.
####HasDoubles
Add double type to the type system.
####HasStrings
Add string type to the type system.
####All
Add all default types to the type system.

##TypeSystem.IGlobalFunction
            
Describes a global function.
        
###Properties

####Signature
Type signature of this function.
####
The bound global function.
###Methods


####
Calls the bound global function.
> #####Parameters
> **parameters:** 

> #####Return value
> 

####Invoke(System.Object[])
Calls the function by passing concrete parameters.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.IGlobalFunctionClosure`1
            
Generic variant of
            
        
###Properties

####Function
The bound global function.

##TypeSystem.TypeDefaultFlags
            
Flags for manually adding types to a type system. These flags represents groups of operators which will be added automatically.
        
###Fields

####None
No automatic type operations.
####Equals
Add Equals (=, !=) operators
####Comparable
Add CompareTo operators, if is defined on given type.
####Numeric
Add numeric operations (+,-,/,*,%), if type is numeric.
####All
Try to add all default operations if possible.

##TypeSystem.IMemberIndexer
            
Represenst an indexer for a type.
        
###Properties

####ReturnType
Return type of the indexer.
####FormalParameters
Types of all indices for the access.
###Methods


####Get(System.Object,System.Object[])
Access via indexer by passing concrete parameters and a THIS object.
> #####Parameters
> **this:** 

> **indices:** 

> #####Return value
> 

##TypeSystem.IMemberFunction
            
A non-global function belonging to a type.
        
###Properties

####
This type
####
Return type
####
Parameter types
####Signature
This, Parameters and Return type of this function.
####
THIS bound to a member function.
####
The actual function bound to this closure.
###Methods


####Constructor
Create a signature.
> #####Parameters
> **thisType:** 

> **returnType:** 

> **parameterTypes:** 


####Invoke(System.Object,System.Object[])
Call the function by passing THIS and PARAMETERS.
> #####Parameters
> **this:** 

> **parameters:** 

> #####Return value
> 

####
Invoke function by passing the parameters only.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.IMemberFunctionClosure
            
A closure (THIS + FUNCTION) for a member function.
        
###Properties

####ThisObject
THIS bound to a member function.
####
The actual function bound to this closure.
###Methods


####Invoke(System.Object[])
Invoke function by passing the parameters only.
> #####Parameters
> **parameters:** 

> #####Return value
> 

##TypeSystem.IMemberFunctionClosure`1
            
Generic variant of . Used in the validation process to reconstruct the function signature.
            
        
###Properties

####Function
The actual function bound to this closure.

##TypeSystem.IProperty
            
Represents a property of a type.
        
###Properties

####Name
Name of the property.
####ReturnType
Return type of the property.
###Methods


####Get(System.Object)
Returns the property for a given THIS value.
> #####Parameters
> **this:** 

> #####Return value
> 

##TypeSystem.MethodExtensions
            
Extensions for .
        
###Methods


####IfMemberFunctionClosureTryGetMethodSignature(System.Type,CQL.TypeSystem.IMemberFunctionSignature@)
Check type if it is a member function. Returns true and a signature if that is the case. FALSE otherwise.
> #####Parameters
> **this:** 

> **signature:** 

> #####Return value
> 

####IfFunctionClosureTryGetFunctionType(System.Type,CQL.TypeSystem.GlobalFunctionSignature@)
Checks whether THIS is a global function closure and returns TRUE with a signature if it is the case, otherwise FALSE.
> #####Parameters
> **this:** 

> **signature:** 

> #####Return value
> 

####BindThis``1(``0,System.Object)
Binds a member function to a THIS object resulting in a
> #####Parameters
> **function:** 

> **this:** 

> #####Return value
> 

##TypeSystem.TypeSystemBuilderExtensions
            
Extensions for .
        
###Methods


####AddTypeScan(CQL.TypeSystem.ITypeSystemBuilder,System.Type)
Scans a SINGLE type for e.g. the and extends the builder with these types including properties, indexers and methods.
> #####Parameters
> **this:** 

> **type:** 


####Unvoid(System.Type)
Converts the type to , because C# does not allow using the original type.
> #####Parameters
> **this:** 

> #####Return value
> 

####AddFromScan(CQL.TypeSystem.ITypeSystemBuilder,System.Type)
Scans type including its nested type for CQL types that could be registrated in this builder.
> #####Parameters
> **this:** 

> **type:** 


####AddFromScan(CQL.TypeSystem.ITypeSystemBuilder,System.Reflection.Assembly)
Scans a assembly for all types with and registers these types as CQL types in the builder.
> #####Parameters
> **this:** 

> **assembly:** 


##TypeSystem.UnknownTypeException
            
Exception for types that are not in a given type system.
        
###Fields

####UnknownType
The unknown type.
###Methods


####Constructor
Creates a exception.
> #####Parameters
> **type:** 


##TypeSystem.BinaryOperation
            
Binary operation rule.
        
###Fields

####LeftType
Type of the left operand.
####RightType
Type of the right operand.
####ResultType
Type of the result.
####Operator
Used operator.
####Operation
Actual operation as lambda function.
###Methods


####Constructor
Creates a binary operation.
> #####Parameters
> **leftType:** 

> **rightType:** 

> **resultType:** 

> **operator:** 

> **operation:** 


##TypeSystem.CoercionKind
            
Kind of coercion rules
        
###Fields

####Implicit
Implicit rules can be called during the validation process. New AST node could be included during this step.
####Explicit
Explicit rules can only be used by writing a type name between two parentheses.

##TypeSystem.CoercionRule
            
This rule class defines the conversion of an original type to a destination (casting) type. The rule can be implicit or explicit. Implicit rules can be applied during validation process.
        
###Fields

####Kind
Implicit or explicit.
####OriginalType
Source type of conversion.
####CastingType
Destination type of conversion.
####Cast
The actual conversion method.
###Methods


####Constructor
Creates a coercion rule
> #####Parameters
> **kind:** 

> **originalType:** 

> **castingType:** 

> **cast:** 


##TypeSystem.ITypeSystemBuilder
            
Helper for building type systems.
        
###Methods


####AddType``1(System.String,System.String,CQL.TypeSystem.TypeDefaultFlags)
Adds a new type known in CQL under the given name. See for default initialization.
> #####Parameters
> **name:** 

> **usage:** 

> **flags:** 

> #####Return value
> 

####AddCoercionRule``2(CQL.TypeSystem.CoercionKind,System.Func{``0,``1})
Add a casting rule, implicit or explicit. Implicit rules will be applied during validation process if needed.
> #####Parameters
> **kind:** 

> **cast:** 


####AddContainsRule``2(System.Func{``0,``1,System.Boolean})
Adds a containment rule "left contains right".
> #####Parameters
> **aggregate:** 


####AddEqualsRule``1(System.Func{``0,``0,System.Boolean})
Adds an equality relation for a given type.
> #####Parameters
> **aggregate:** 


####AddLessRule``1(System.Func{``0,``0,System.Boolean})
The less rule is sufficient to realize all comparsion operations (greater, greater equals, less and less equals).
> #####Parameters
> **aggregate:** 


####AddRule``2(CQL.SyntaxTree.UnaryOperator,System.Func{``0,``1})
Low level function to add any unary operation.
> #####Parameters
> **op:** 

> **func:** 


####AddRule``3(CQL.SyntaxTree.BinaryOperator,System.Func{``0,``1,``2})
Low level function to add any binary operation.
> #####Parameters
> **op:** 

> **aggregate:** 


####Build
Takes all added rules and creates a type system from these.
> #####Return value
> 

##TypeSystem.IType
            
A non-generic type registered in a type system.
        
###Properties

####NativeType
The CSharp type.
####Indexer
Is null when not defined.
####Members
Returns all registered members (properties and functions).
####
Returns all registered types.
####
The null type.
####
The empty type.
###Methods


####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds an foreign indexer by adding a lambda function to get the value.
> #####Parameters
> **getter:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign function to the type by a given lambda function.
> #####Parameters
> **delimiter:** 

> **name:** 

> **func:** 

> #####Return value
> 

####
Adds a foreign (lambda) property.
> #####Parameters
> **delimiter:** 

> **name:** 

> **getter:** 

> #####Return value
> 

####
Adds a new type known in CQL under the given name. See for default initialization.
> #####Parameters
> **name:** 

> **usage:** 

> **flags:** 

> #####Return value
> 

####
Add a casting rule, implicit or explicit. Implicit rules will be applied during validation process if needed.
> #####Parameters
> **kind:** 

> **cast:** 


####
Adds a containment rule "left contains right".
> #####Parameters
> **aggregate:** 


####
Adds an equality relation for a given type.
> #####Parameters
> **aggregate:** 


####
The less rule is sufficient to realize all comparsion operations (greater, greater equals, less and less equals).
> #####Parameters
> **aggregate:** 


####
Low level function to add any unary operation.
> #####Parameters
> **op:** 

> **func:** 


####
Low level function to add any binary operation.
> #####Parameters
> **op:** 

> **aggregate:** 


####
Takes all added rules and creates a type system from these.
> #####Return value
> 

####GetByName(CQL.SyntaxTree.IdDelimiter,System.String)
Return a property by name.
> #####Parameters
> **delimiter:** 

> **name:** 

> #####Return value
> 

####AddNativeFunction(CQL.SyntaxTree.IdDelimiter,System.String,System.Reflection.MethodInfo)
Adds a native member function by its .
> #####Parameters
> **delimiter:** 

> **name:** 

> **methodInfo:** 

> #####Return value
> 

####AddNativeProperty(CQL.SyntaxTree.IdDelimiter,System.String,System.Reflection.PropertyInfo)
Adds a native member property by its .
> #####Parameters
> **delimiter:** 

> **name:** 

> **propertyInfo:** 

> #####Return value
> 

####AddNativeIndexer(System.Reflection.PropertyInfo)
Adds a native indexer by its
> #####Parameters
> **propertyInfo:** 

> #####Return value
> 

####
Returns null or a type by its name which was used to register it (case insensitive).
> #####Parameters
> **name:** 

> #####Return value
> 

####
Returns a set of types that start with the given prefix (case insensitive).
> #####Parameters
> **prefix:** 

> #####Return value
> 

####
Returns a registered type when passing the native type. Return null, if it can not be found. Throws an when more than one type is possible.
> #####Parameters
> **type:** 

> #####Return value
> 

####

> #####Return value
> 

####
Returns a coercion rule between two type, if it exists. NULL otherwise.
> #####Parameters
> **original:** 

> **casting:** 

> #####Return value
> 

####
Returns a chain of implicit casts for converting a variable of an original type into a destination type.
> #####Parameters
> **original:** 

> **destinationType:** 

> #####Return value
> 

####
Returns all possible implicit casts from a given type.
> #####Parameters
> **target:** 

> #####Return value
> 

####
Returns a binary operation between two types if it exists. NULL otherwise.
> #####Parameters
> **op:** 

> **left:** 

> **right:** 

> #####Return value
> 

####
Returns all binary operations registered.
> #####Return value
> 

####
Returns all unary operations registered.
> #####Parameters
> **op:** 

> **operand:** 

> #####Return value
> 

##TypeSystem.TypeSystemExtensions
            
Extensions for .
        
###Methods


####ApplyCast(System.Collections.Generic.IEnumerable{CQL.TypeSystem.CoercionRule},CQL.SyntaxTree.IExpression,CQL.Contexts.IValidationScope,System.Func{System.Exception})
Applies a set of type casts to an expression. This will insert several cast expressions.
> #####Parameters
> **this:** 

> **expression:** 

> **context:** 

> **generateError:** 

> #####Return value
> 

####AlignTypes(CQL.Contexts.IValidationScope,CQL.SyntaxTree.IExpression@,CQL.SyntaxTree.IExpression@,System.Func{System.Exception})
Given to R-values, trys to unify both value's type by calling implicit type conversions.
> #####Parameters
> **this:** 

> **lhs:** 

> **rhs:** 

> **generateError:** 

> #####Return value
> 

##TypeSystem.UnaryOperation
            
Represents a unary operation.
        
###Fields

####OperandType
Type of the operand.
####ResultType
Return type of the operation.
####Operator
The applied operator.
####Operation
Operation delegate which has to be applied to the input operand.
###Methods


####Constructor
Creates an unary operation info object.
> #####Parameters
> **operandType:** 

> **resultType:** 

> **operator:** 

> **operation:** 


##TypeSystem.ITypeSystem
            
A typesystem a a set of types and rules (operations, relations) between these types.
        
###Properties

####Types
Returns all registered types.
####NullType
The null type.
####EmptyType
The empty type.
###Methods


####
Adds a new type known in CQL under the given name. See for default initialization.
> #####Parameters
> **name:** 

> **usage:** 

> **flags:** 

> #####Return value
> 

####
Add a casting rule, implicit or explicit. Implicit rules will be applied during validation process if needed.
> #####Parameters
> **kind:** 

> **cast:** 


####
Adds a containment rule "left contains right".
> #####Parameters
> **aggregate:** 


####
Adds an equality relation for a given type.
> #####Parameters
> **aggregate:** 


####
The less rule is sufficient to realize all comparsion operations (greater, greater equals, less and less equals).
> #####Parameters
> **aggregate:** 


####
Low level function to add any unary operation.
> #####Parameters
> **op:** 

> **func:** 


####
Low level function to add any binary operation.
> #####Parameters
> **op:** 

> **aggregate:** 


####
Takes all added rules and creates a type system from these.
> #####Return value
> 

####GetTypeByName(System.String)
Returns null or a type by its name which was used to register it (case insensitive).
> #####Parameters
> **name:** 

> #####Return value
> 

####GetTypesByPrefix(System.String)
Returns a set of types that start with the given prefix (case insensitive).
> #####Parameters
> **prefix:** 

> #####Return value
> 

####GetTypeByNative(System.Type)
Returns a registered type when passing the native type. Return null, if it can not be found. Throws an when more than one type is possible.
> #####Parameters
> **type:** 

> #####Return value
> 

####GetTypeByNative``1

> #####Return value
> 

####GetCoercionRule(System.Type,System.Type)
Returns a coercion rule between two type, if it exists. NULL otherwise.
> #####Parameters
> **original:** 

> **casting:** 

> #####Return value
> 

####GetImplicitlyCastChain(System.Type,System.Type)
Returns a chain of implicit casts for converting a variable of an original type into a destination type.
> #####Parameters
> **original:** 

> **destinationType:** 

> #####Return value
> 

####GetImplicitlyCastsTo(System.Type)
Returns all possible implicit casts from a given type.
> #####Parameters
> **target:** 

> #####Return value
> 

####GetBinaryOperation(CQL.SyntaxTree.BinaryOperator,System.Type,System.Type)
Returns a binary operation between two types if it exists. NULL otherwise.
> #####Parameters
> **op:** 

> **left:** 

> **right:** 

> #####Return value
> 

####GetBinaryOperations
Returns all binary operations registered.
> #####Return value
> 

####GetUnaryOperation(CQL.SyntaxTree.UnaryOperator,System.Type)
Returns all unary operations registered.
> #####Parameters
> **op:** 

> **operand:** 

> #####Return value
> 

##TypeSystem.AmbigiousTypeException
            
This exception describes the situation when a native type was resolved with more than one type in the type system.
        
###Fields

####GivenType
The requested type.
####KnownTypes
The resolved types.
###Methods


####Constructor
Creates the exception.
> #####Parameters
> **type:** 

> **knownTypes:** 


##TypeSystem.Void
            
Replacement for
        

##DictionaryExtensions
            
Extensions for dictionaries.
        
###Methods


####MergeWith``2(System.Collections.Generic.IReadOnlyDictionary{``0,``1},System.Collections.Generic.IReadOnlyDictionary{``0,``1}[])
Merges THIS dictionary with other dictionaries and returns a new dictionary.
> #####Parameters
> **this:** 

> **others:** 

> #####Return value
> 

####AlterValueOrDefault``2(System.Collections.Generic.IDictionary{``0,``1},``0,System.Func{``1,``1},``1)
Alters a value in a dictionary. If not present it executes the action on a given default value.
> #####Parameters
> **dictionary:** 

> **key:** 

> **action:** 

> **default:** 


####GetValueOrInsertedDefault``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1)
Gets a value for the given key, or if the key does not exist, does insert a default value.
> #####Parameters
> **dictionary:** 

> **key:** 

> **default:** 

> #####Return value
> 

####GetValueOrInsertedLazyDefault``2(System.Collections.Generic.IDictionary{``0,``1},``0,System.Func{``1})
Gets a value for the given key, or if the key does not exist, does insert a default value lazyly.
> #####Parameters
> **dictionary:** 

> **key:** 

> **default:** 

> #####Return value
> 

####GetOrDefault``2(System.Collections.Generic.IReadOnlyDictionary{``0,``1},``0,``1)
Returns the value for an existing key, or, if not existing, a default value.
> #####Parameters
> **_this:** 

> **key:** 

> **default:** 

> #####Return value
> 

##Queries
            
A facade for the user to quickly access the parser and evaluation API.
        
###Fields

####True
A query that returns true.
###Methods


####ParseForSyntaxOnly(System.String,CQL.ErrorHandling.IErrorListener)
Parses a user query (without validating it). You practically only get the syntax tree.
> #####Parameters
> **text:** 

> **errorListener:** 

> #####Return value
> 

####Parse(System.String,CQL.Contexts.IEvaluationScope,CQL.ErrorHandling.IErrorListener)
Parses AND validates a query string.
> #####Parameters
> **text:** 

> **context:** 

> **errorListener:** 

> #####Return value
> 

####AutoComplete(System.String,CQL.Contexts.IEvaluationScope)
Trys to complete the user input by a given context.
> #####Parameters
> **textUntilCaret:** 

> **context:** 

> #####Return value
> 

####Evaluate``1(System.String,``0,CQL.Contexts.IEvaluationScope,CQL.ErrorHandling.IErrorListener)
Evaluates a user query string with a given context and an optional error listener. If no listener is given, this method will throw exceptions instead. Do not use this method if you want to evaluate a query for multiple subjects. Use instead in combination with .
> #####Parameters
> **text:** 

> **subject:** 

> **context:** 

> **errorListener:** 

> #####Return value
> 

##StringExtensions
            
Contains extensions for strings.
        
###Methods


####Escape(System.String)
Escapes a string from special charaters, using the C# compiler environment.
> #####Parameters
> **input:** 

> #####Return value
> 

####Unescape(System.String)
Unescapes an escaped string.
> #####Parameters
> **this:** 

> #####Return value
> 

##Visitors.ExpressionsVisitor
            
Visitor that produces a list of expressions.
        
###Methods


####Constructor
Creates a visitor producing lists of expressions, like parameter list etc.
> #####Parameters
> **exprVisitor:** 


####VisitElemList(CQL.CQLParser.ElemListContext)
Returns expression list from parser's . Represents a list of multiple expressions.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitParamList(CQL.CQLParser.ParamListContext)
Returns expression list from parser's . Represents multiple expressions in a parameter list.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitParamSingle(CQL.CQLParser.ParamSingleContext)
Returns expression list from parser's . Represents one expression of a parameter list.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitElemSingle(CQL.CQLParser.ElemSingleContext)
Returns expression list from parser's . Represents one expression of a list.
> #####Parameters
> **context:** 

> #####Return value
> 

##Visitors.ExpressionVisitor
            
Visitor producing objects from parts of the abstract syntax tree (AST).
        
###Methods


####Constructor
Creates the expression visitor.

####VisitExpression(CQL.CQLParser.ExpressionContext)
Returns expression from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitConditional(CQL.CQLParser.ConditionalContext)
Returns expression from parser's . Represents the ternary ?-operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitOr(CQL.CQLParser.OrContext)
Returns expression from parser's . Represents the OR-operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitAnd(CQL.CQLParser.AndContext)
Returns expression from parser's . Represents the AND operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitEquals(CQL.CQLParser.EqualsContext)
Returns expression from parser's Represents the = operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitNotEquals(CQL.CQLParser.NotEqualsContext)
Returns expression from parser's . Represents the != operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitGt(CQL.CQLParser.GtContext)
Returns expression from parser's . Represents the > operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitGte(CQL.CQLParser.GteContext)
Returns expression from parser's . Represents the >= operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitLt(CQL.CQLParser.LtContext)
Returns expression from parser's . Represents the < operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitLte(CQL.CQLParser.LteContext)
Returns expression from parser's . Represents <= operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitPlus(CQL.CQLParser.PlusContext)
Returns expression from parser's . Represents addition + operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitMinus(CQL.CQLParser.MinusContext)
Returns expression from parser's . Represents substraction.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitMul(CQL.CQLParser.MulContext)
Returns expression from parser's . Represents multiplication.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitDiv(CQL.CQLParser.DivContext)
Returns expression from parser's . Represents division.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitMod(CQL.CQLParser.ModContext)
Returns expression from parser's . Represents modulo operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitContains(CQL.CQLParser.ContainsContext)
Returns expression from parser's . Represents contains operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Returns expression from parser's . Represents the "does not contain" operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitIs(CQL.CQLParser.IsContext)
Returns expression from parser's . Represents the IS operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitIn(CQL.CQLParser.InContext)
Returns expression from parser's . Represents the IN operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitNotIn(CQL.CQLParser.NotInContext)
Returns expression from parser's . Represents the NOT IN operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitExpr(CQL.CQLParser.ExprContext)
Returns expression from parser's . Represents a expression surrounded by parentheses.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitNotFactor(CQL.CQLParser.NotFactorContext)
Returns expression from parser's . Represents the NOT operator.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitMinusFactor(CQL.CQLParser.MinusFactorContext)
Returns expression from parser's . Represents numerical negation.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitComplexFactor(CQL.CQLParser.ComplexFactorContext)
Returns expression from parser's . Represents complex factors like array access, property lookup or function call.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitPlusFactor(CQL.CQLParser.PlusFactorContext)
Returns expression from parser's . Represents unary plus.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitConst(CQL.CQLParser.ConstContext)
Returns expression from parser's . Represents several literals.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitLs(CQL.CQLParser.LsContext)
Returns expression from parser's . Represents array literals.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitBraceElems(CQL.CQLParser.BraceElemsContext)
Returns expression from parser's . Represents array literals, too.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitBracketElems(CQL.CQLParser.BracketElemsContext)
Returns expression from parser's . Represents array literal.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitBool(CQL.CQLParser.BoolContext)
Returns expression from parser's . Represents bool literals.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitDecimal(CQL.CQLParser.DecimalContext)
Returns expression from parser's . Represents integer and float literals.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitEmpty(CQL.CQLParser.EmptyContext)
Returns expression from parser's . Represents the EMPTY literal.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitNull(CQL.CQLParser.NullContext)
Returns expression from parser's . Represents a NULL literal.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitString(CQL.CQLParser.StringContext)
Returns expression from parser's . Represents a string literal.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitCastFactor(CQL.CQLParser.CastFactorContext)
Returns expression from parser's . Represents a type casting expression.
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitVarExp(CQL.CQLParser.VarExpContext)
Returns expression from parser's . Represents a variable usage.
> #####Parameters
> **context:** 

> #####Return value
> 

##Visitors.NameVisitor
            
Visitor producing names from parts of the abstract syntax tree (AST).
        
###Methods


####VisitMemberName(CQL.CQLParser.MemberNameContext)
Returns name from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitTypeName(CQL.CQLParser.TypeNameContext)
Returns name from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitTrue(CQL.CQLParser.TrueContext)
Returns name from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitFalse(CQL.CQLParser.FalseContext)
Returns name from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

####VisitPrimeVar(CQL.CQLParser.PrimeVarContext)
Returns name from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

##Visitors.QueryVisitor
            
Visitor producing objects from parts of the abstract syntax tree (AST).
        
###Methods


####Constructor
Creates a query visitor.

####VisitQuery(CQL.CQLParser.QueryContext)
Returns query from parser's
> #####Parameters
> **context:** 

> #####Return value
> 

##ICQLListener
            
This interface defines a complete listener for a parse tree produced by .
        
###Methods


####EnterString(CQL.CQLParser.StringContext)
Enter a parse tree produced by the string labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitString(CQL.CQLParser.StringContext)
Exit a parse tree produced by the string labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterNull(CQL.CQLParser.NullContext)
Enter a parse tree produced by the null labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitNull(CQL.CQLParser.NullContext)
Exit a parse tree produced by the null labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterBool(CQL.CQLParser.BoolContext)
Enter a parse tree produced by the bool labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitBool(CQL.CQLParser.BoolContext)
Exit a parse tree produced by the bool labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterDecimal(CQL.CQLParser.DecimalContext)
Enter a parse tree produced by the decimal labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitDecimal(CQL.CQLParser.DecimalContext)
Exit a parse tree produced by the decimal labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterEmpty(CQL.CQLParser.EmptyContext)
Enter a parse tree produced by the empty labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitEmpty(CQL.CQLParser.EmptyContext)
Exit a parse tree produced by the empty labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMinus(CQL.CQLParser.MinusContext)
Enter a parse tree produced by the minus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMinus(CQL.CQLParser.MinusContext)
Exit a parse tree produced by the minus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterPlus(CQL.CQLParser.PlusContext)
Enter a parse tree produced by the plus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitPlus(CQL.CQLParser.PlusContext)
Exit a parse tree produced by the plus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToMul(CQL.CQLParser.ToMulContext)
Enter a parse tree produced by the toMul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToMul(CQL.CQLParser.ToMulContext)
Exit a parse tree produced by the toMul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterArrayAccess(CQL.CQLParser.ArrayAccessContext)
Enter a parse tree produced by the arrayAccess labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitArrayAccess(CQL.CQLParser.ArrayAccessContext)
Exit a parse tree produced by the arrayAccess labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMethodCall(CQL.CQLParser.MethodCallContext)
Enter a parse tree produced by the methodCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMethodCall(CQL.CQLParser.MethodCallContext)
Exit a parse tree produced by the methodCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMemberCall(CQL.CQLParser.MemberCallContext)
Enter a parse tree produced by the memberCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMemberCall(CQL.CQLParser.MemberCallContext)
Exit a parse tree produced by the memberCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterBraceElems(CQL.CQLParser.BraceElemsContext)
Enter a parse tree produced by the braceElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitBraceElems(CQL.CQLParser.BraceElemsContext)
Exit a parse tree produced by the braceElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterBracketElems(CQL.CQLParser.BracketElemsContext)
Enter a parse tree produced by the bracketElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitBracketElems(CQL.CQLParser.BracketElemsContext)
Exit a parse tree produced by the bracketElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterOr(CQL.CQLParser.OrContext)
Enter a parse tree produced by the or labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitOr(CQL.CQLParser.OrContext)
Exit a parse tree produced by the or labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToAnd(CQL.CQLParser.ToAndContext)
Enter a parse tree produced by the toAnd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToAnd(CQL.CQLParser.ToAndContext)
Exit a parse tree produced by the toAnd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToEquals(CQL.CQLParser.ToEqualsContext)
Enter a parse tree produced by the toEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToEquals(CQL.CQLParser.ToEqualsContext)
Exit a parse tree produced by the toEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterAnd(CQL.CQLParser.AndContext)
Enter a parse tree produced by the and labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitAnd(CQL.CQLParser.AndContext)
Exit a parse tree produced by the and labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterEquals(CQL.CQLParser.EqualsContext)
Enter a parse tree produced by the equals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitEquals(CQL.CQLParser.EqualsContext)
Exit a parse tree produced by the equals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterNotEquals(CQL.CQLParser.NotEqualsContext)
Enter a parse tree produced by the notEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitNotEquals(CQL.CQLParser.NotEqualsContext)
Exit a parse tree produced by the notEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToCompare(CQL.CQLParser.ToCompareContext)
Enter a parse tree produced by the toCompare labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToCompare(CQL.CQLParser.ToCompareContext)
Exit a parse tree produced by the toCompare labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterDiv(CQL.CQLParser.DivContext)
Enter a parse tree produced by the div labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitDiv(CQL.CQLParser.DivContext)
Exit a parse tree produced by the div labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMod(CQL.CQLParser.ModContext)
Enter a parse tree produced by the mod labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMod(CQL.CQLParser.ModContext)
Exit a parse tree produced by the mod labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMul(CQL.CQLParser.MulContext)
Enter a parse tree produced by the mul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMul(CQL.CQLParser.MulContext)
Exit a parse tree produced by the mul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToSpecial(CQL.CQLParser.ToSpecialContext)
Enter a parse tree produced by the toSpecial labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToSpecial(CQL.CQLParser.ToSpecialContext)
Exit a parse tree produced by the toSpecial labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMemberName(CQL.CQLParser.MemberNameContext)
Enter a parse tree produced by the memberName labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMemberName(CQL.CQLParser.MemberNameContext)
Exit a parse tree produced by the memberName labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterConditional(CQL.CQLParser.ConditionalContext)
Enter a parse tree produced by the conditional labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitConditional(CQL.CQLParser.ConditionalContext)
Exit a parse tree produced by the conditional labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToOr(CQL.CQLParser.ToOrContext)
Enter a parse tree produced by the toOr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToOr(CQL.CQLParser.ToOrContext)
Exit a parse tree produced by the toOr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterParamSingle(CQL.CQLParser.ParamSingleContext)
Enter a parse tree produced by the paramSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitParamSingle(CQL.CQLParser.ParamSingleContext)
Exit a parse tree produced by the paramSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterParamList(CQL.CQLParser.ParamListContext)
Enter a parse tree produced by the paramList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitParamList(CQL.CQLParser.ParamListContext)
Exit a parse tree produced by the paramList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToAdd(CQL.CQLParser.ToAddContext)
Enter a parse tree produced by the toAdd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToAdd(CQL.CQLParser.ToAddContext)
Exit a parse tree produced by the toAdd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterLt(CQL.CQLParser.LtContext)
Enter a parse tree produced by the lt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitLt(CQL.CQLParser.LtContext)
Exit a parse tree produced by the lt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterGte(CQL.CQLParser.GteContext)
Enter a parse tree produced by the gte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitGte(CQL.CQLParser.GteContext)
Exit a parse tree produced by the gte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterLte(CQL.CQLParser.LteContext)
Enter a parse tree produced by the lte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitLte(CQL.CQLParser.LteContext)
Exit a parse tree produced by the lte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterGt(CQL.CQLParser.GtContext)
Enter a parse tree produced by the gt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitGt(CQL.CQLParser.GtContext)
Exit a parse tree produced by the gt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterContains(CQL.CQLParser.ContainsContext)
Enter a parse tree produced by the contains labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitContains(CQL.CQLParser.ContainsContext)
Exit a parse tree produced by the contains labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Enter a parse tree produced by the doesNotContain labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Exit a parse tree produced by the doesNotContain labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterIn(CQL.CQLParser.InContext)
Enter a parse tree produced by the in labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitIn(CQL.CQLParser.InContext)
Exit a parse tree produced by the in labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterNotIn(CQL.CQLParser.NotInContext)
Enter a parse tree produced by the notIn labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitNotIn(CQL.CQLParser.NotInContext)
Exit a parse tree produced by the notIn labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterIs(CQL.CQLParser.IsContext)
Enter a parse tree produced by the is labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitIs(CQL.CQLParser.IsContext)
Exit a parse tree produced by the is labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterToFactor(CQL.CQLParser.ToFactorContext)
Enter a parse tree produced by the toFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitToFactor(CQL.CQLParser.ToFactorContext)
Exit a parse tree produced by the toFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterComplexFactor(CQL.CQLParser.ComplexFactorContext)
Enter a parse tree produced by the complexFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitComplexFactor(CQL.CQLParser.ComplexFactorContext)
Exit a parse tree produced by the complexFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterElemSingle(CQL.CQLParser.ElemSingleContext)
Enter a parse tree produced by the elemSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitElemSingle(CQL.CQLParser.ElemSingleContext)
Exit a parse tree produced by the elemSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterElemList(CQL.CQLParser.ElemListContext)
Enter a parse tree produced by the elemList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitElemList(CQL.CQLParser.ElemListContext)
Exit a parse tree produced by the elemList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterTrue(CQL.CQLParser.TrueContext)
Enter a parse tree produced by the true labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitTrue(CQL.CQLParser.TrueContext)
Exit a parse tree produced by the true labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterFalse(CQL.CQLParser.FalseContext)
Enter a parse tree produced by the false labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitFalse(CQL.CQLParser.FalseContext)
Exit a parse tree produced by the false labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterVarExp(CQL.CQLParser.VarExpContext)
Enter a parse tree produced by the varExp labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitVarExp(CQL.CQLParser.VarExpContext)
Exit a parse tree produced by the varExp labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterConst(CQL.CQLParser.ConstContext)
Enter a parse tree produced by the const labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitConst(CQL.CQLParser.ConstContext)
Exit a parse tree produced by the const labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterPlusFactor(CQL.CQLParser.PlusFactorContext)
Enter a parse tree produced by the plusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitPlusFactor(CQL.CQLParser.PlusFactorContext)
Exit a parse tree produced by the plusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterNotFactor(CQL.CQLParser.NotFactorContext)
Enter a parse tree produced by the notFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitNotFactor(CQL.CQLParser.NotFactorContext)
Exit a parse tree produced by the notFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterLs(CQL.CQLParser.LsContext)
Enter a parse tree produced by the ls labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitLs(CQL.CQLParser.LsContext)
Exit a parse tree produced by the ls labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterMinusFactor(CQL.CQLParser.MinusFactorContext)
Enter a parse tree produced by the minusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitMinusFactor(CQL.CQLParser.MinusFactorContext)
Exit a parse tree produced by the minusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterCastFactor(CQL.CQLParser.CastFactorContext)
Enter a parse tree produced by the castFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitCastFactor(CQL.CQLParser.CastFactorContext)
Exit a parse tree produced by the castFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterExpr(CQL.CQLParser.ExprContext)
Enter a parse tree produced by the expr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####ExitExpr(CQL.CQLParser.ExprContext)
Exit a parse tree produced by the expr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####EnterQuery(CQL.CQLParser.QueryContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitQuery(CQL.CQLParser.QueryContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterExpression(CQL.CQLParser.ExpressionContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitExpression(CQL.CQLParser.ExpressionContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterEqualsTerm(CQL.CQLParser.EqualsTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitEqualsTerm(CQL.CQLParser.EqualsTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterCompareTerm(CQL.CQLParser.CompareTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitCompareTerm(CQL.CQLParser.CompareTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterAddTerm(CQL.CQLParser.AddTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitAddTerm(CQL.CQLParser.AddTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterMulTerm(CQL.CQLParser.MulTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitMulTerm(CQL.CQLParser.MulTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterSpecialTerm(CQL.CQLParser.SpecialTermContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitSpecialTerm(CQL.CQLParser.SpecialTermContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterFactor(CQL.CQLParser.FactorContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitFactor(CQL.CQLParser.FactorContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterChain_element(CQL.CQLParser.Chain_elementContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitChain_element(CQL.CQLParser.Chain_elementContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterPrimary(CQL.CQLParser.PrimaryContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitPrimary(CQL.CQLParser.PrimaryContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterPrimeVar(CQL.CQLParser.PrimeVarContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitPrimeVar(CQL.CQLParser.PrimeVarContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterMember(CQL.CQLParser.MemberContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitMember(CQL.CQLParser.MemberContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterTypeName(CQL.CQLParser.TypeNameContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitTypeName(CQL.CQLParser.TypeNameContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterList(CQL.CQLParser.ListContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitList(CQL.CQLParser.ListContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterElementList(CQL.CQLParser.ElementListContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitElementList(CQL.CQLParser.ElementListContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterParameterList(CQL.CQLParser.ParameterListContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitParameterList(CQL.CQLParser.ParameterListContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterConstant(CQL.CQLParser.ConstantContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitConstant(CQL.CQLParser.ConstantContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterNullLiteral(CQL.CQLParser.NullLiteralContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitNullLiteral(CQL.CQLParser.NullLiteralContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####EnterEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Enter a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####ExitEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Exit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


##CQLBaseListener
            
This class provides an empty implementation of , which can be extended to create a listener which only needs to handle a subset of the available methods.
        
###Methods


####EnterString(CQL.CQLParser.StringContext)
Enter a parse tree produced by the string labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitString(CQL.CQLParser.StringContext)
Exit a parse tree produced by the string labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterNull(CQL.CQLParser.NullContext)
Enter a parse tree produced by the null labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitNull(CQL.CQLParser.NullContext)
Exit a parse tree produced by the null labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterBool(CQL.CQLParser.BoolContext)
Enter a parse tree produced by the bool labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitBool(CQL.CQLParser.BoolContext)
Exit a parse tree produced by the bool labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterDecimal(CQL.CQLParser.DecimalContext)
Enter a parse tree produced by the decimal labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitDecimal(CQL.CQLParser.DecimalContext)
Exit a parse tree produced by the decimal labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterEmpty(CQL.CQLParser.EmptyContext)
Enter a parse tree produced by the empty labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitEmpty(CQL.CQLParser.EmptyContext)
Exit a parse tree produced by the empty labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMinus(CQL.CQLParser.MinusContext)
Enter a parse tree produced by the minus labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMinus(CQL.CQLParser.MinusContext)
Exit a parse tree produced by the minus labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterPlus(CQL.CQLParser.PlusContext)
Enter a parse tree produced by the plus labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitPlus(CQL.CQLParser.PlusContext)
Exit a parse tree produced by the plus labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToMul(CQL.CQLParser.ToMulContext)
Enter a parse tree produced by the toMul labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToMul(CQL.CQLParser.ToMulContext)
Exit a parse tree produced by the toMul labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterArrayAccess(CQL.CQLParser.ArrayAccessContext)
Enter a parse tree produced by the arrayAccess labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitArrayAccess(CQL.CQLParser.ArrayAccessContext)
Exit a parse tree produced by the arrayAccess labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMethodCall(CQL.CQLParser.MethodCallContext)
Enter a parse tree produced by the methodCall labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMethodCall(CQL.CQLParser.MethodCallContext)
Exit a parse tree produced by the methodCall labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMemberCall(CQL.CQLParser.MemberCallContext)
Enter a parse tree produced by the memberCall labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMemberCall(CQL.CQLParser.MemberCallContext)
Exit a parse tree produced by the memberCall labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterBraceElems(CQL.CQLParser.BraceElemsContext)
Enter a parse tree produced by the braceElems labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitBraceElems(CQL.CQLParser.BraceElemsContext)
Exit a parse tree produced by the braceElems labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterBracketElems(CQL.CQLParser.BracketElemsContext)
Enter a parse tree produced by the bracketElems labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitBracketElems(CQL.CQLParser.BracketElemsContext)
Exit a parse tree produced by the bracketElems labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterOr(CQL.CQLParser.OrContext)
Enter a parse tree produced by the or labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitOr(CQL.CQLParser.OrContext)
Exit a parse tree produced by the or labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToAnd(CQL.CQLParser.ToAndContext)
Enter a parse tree produced by the toAnd labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToAnd(CQL.CQLParser.ToAndContext)
Exit a parse tree produced by the toAnd labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToEquals(CQL.CQLParser.ToEqualsContext)
Enter a parse tree produced by the toEquals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToEquals(CQL.CQLParser.ToEqualsContext)
Exit a parse tree produced by the toEquals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterAnd(CQL.CQLParser.AndContext)
Enter a parse tree produced by the and labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitAnd(CQL.CQLParser.AndContext)
Exit a parse tree produced by the and labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterEquals(CQL.CQLParser.EqualsContext)
Enter a parse tree produced by the equals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitEquals(CQL.CQLParser.EqualsContext)
Exit a parse tree produced by the equals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterNotEquals(CQL.CQLParser.NotEqualsContext)
Enter a parse tree produced by the notEquals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitNotEquals(CQL.CQLParser.NotEqualsContext)
Exit a parse tree produced by the notEquals labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToCompare(CQL.CQLParser.ToCompareContext)
Enter a parse tree produced by the toCompare labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToCompare(CQL.CQLParser.ToCompareContext)
Exit a parse tree produced by the toCompare labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterDiv(CQL.CQLParser.DivContext)
Enter a parse tree produced by the div labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitDiv(CQL.CQLParser.DivContext)
Exit a parse tree produced by the div labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMod(CQL.CQLParser.ModContext)
Enter a parse tree produced by the mod labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMod(CQL.CQLParser.ModContext)
Exit a parse tree produced by the mod labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMul(CQL.CQLParser.MulContext)
Enter a parse tree produced by the mul labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMul(CQL.CQLParser.MulContext)
Exit a parse tree produced by the mul labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToSpecial(CQL.CQLParser.ToSpecialContext)
Enter a parse tree produced by the toSpecial labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToSpecial(CQL.CQLParser.ToSpecialContext)
Exit a parse tree produced by the toSpecial labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMemberName(CQL.CQLParser.MemberNameContext)
Enter a parse tree produced by the memberName labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMemberName(CQL.CQLParser.MemberNameContext)
Exit a parse tree produced by the memberName labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterConditional(CQL.CQLParser.ConditionalContext)
Enter a parse tree produced by the conditional labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitConditional(CQL.CQLParser.ConditionalContext)
Exit a parse tree produced by the conditional labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToOr(CQL.CQLParser.ToOrContext)
Enter a parse tree produced by the toOr labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToOr(CQL.CQLParser.ToOrContext)
Exit a parse tree produced by the toOr labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterParamSingle(CQL.CQLParser.ParamSingleContext)
Enter a parse tree produced by the paramSingle labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitParamSingle(CQL.CQLParser.ParamSingleContext)
Exit a parse tree produced by the paramSingle labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterParamList(CQL.CQLParser.ParamListContext)
Enter a parse tree produced by the paramList labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitParamList(CQL.CQLParser.ParamListContext)
Exit a parse tree produced by the paramList labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToAdd(CQL.CQLParser.ToAddContext)
Enter a parse tree produced by the toAdd labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToAdd(CQL.CQLParser.ToAddContext)
Exit a parse tree produced by the toAdd labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterLt(CQL.CQLParser.LtContext)
Enter a parse tree produced by the lt labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitLt(CQL.CQLParser.LtContext)
Exit a parse tree produced by the lt labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterGte(CQL.CQLParser.GteContext)
Enter a parse tree produced by the gte labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitGte(CQL.CQLParser.GteContext)
Exit a parse tree produced by the gte labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterLte(CQL.CQLParser.LteContext)
Enter a parse tree produced by the lte labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitLte(CQL.CQLParser.LteContext)
Exit a parse tree produced by the lte labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterGt(CQL.CQLParser.GtContext)
Enter a parse tree produced by the gt labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitGt(CQL.CQLParser.GtContext)
Exit a parse tree produced by the gt labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterContains(CQL.CQLParser.ContainsContext)
Enter a parse tree produced by the contains labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitContains(CQL.CQLParser.ContainsContext)
Exit a parse tree produced by the contains labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Enter a parse tree produced by the doesNotContain labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Exit a parse tree produced by the doesNotContain labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterIn(CQL.CQLParser.InContext)
Enter a parse tree produced by the in labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitIn(CQL.CQLParser.InContext)
Exit a parse tree produced by the in labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterNotIn(CQL.CQLParser.NotInContext)
Enter a parse tree produced by the notIn labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitNotIn(CQL.CQLParser.NotInContext)
Exit a parse tree produced by the notIn labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterIs(CQL.CQLParser.IsContext)
Enter a parse tree produced by the is labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitIs(CQL.CQLParser.IsContext)
Exit a parse tree produced by the is labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterToFactor(CQL.CQLParser.ToFactorContext)
Enter a parse tree produced by the toFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitToFactor(CQL.CQLParser.ToFactorContext)
Exit a parse tree produced by the toFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterComplexFactor(CQL.CQLParser.ComplexFactorContext)
Enter a parse tree produced by the complexFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitComplexFactor(CQL.CQLParser.ComplexFactorContext)
Exit a parse tree produced by the complexFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterElemSingle(CQL.CQLParser.ElemSingleContext)
Enter a parse tree produced by the elemSingle labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitElemSingle(CQL.CQLParser.ElemSingleContext)
Exit a parse tree produced by the elemSingle labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterElemList(CQL.CQLParser.ElemListContext)
Enter a parse tree produced by the elemList labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitElemList(CQL.CQLParser.ElemListContext)
Exit a parse tree produced by the elemList labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterTrue(CQL.CQLParser.TrueContext)
Enter a parse tree produced by the true labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitTrue(CQL.CQLParser.TrueContext)
Exit a parse tree produced by the true labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterFalse(CQL.CQLParser.FalseContext)
Enter a parse tree produced by the false labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitFalse(CQL.CQLParser.FalseContext)
Exit a parse tree produced by the false labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterVarExp(CQL.CQLParser.VarExpContext)
Enter a parse tree produced by the varExp labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitVarExp(CQL.CQLParser.VarExpContext)
Exit a parse tree produced by the varExp labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterConst(CQL.CQLParser.ConstContext)
Enter a parse tree produced by the const labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitConst(CQL.CQLParser.ConstContext)
Exit a parse tree produced by the const labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterPlusFactor(CQL.CQLParser.PlusFactorContext)
Enter a parse tree produced by the plusFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitPlusFactor(CQL.CQLParser.PlusFactorContext)
Exit a parse tree produced by the plusFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterNotFactor(CQL.CQLParser.NotFactorContext)
Enter a parse tree produced by the notFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitNotFactor(CQL.CQLParser.NotFactorContext)
Exit a parse tree produced by the notFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterLs(CQL.CQLParser.LsContext)
Enter a parse tree produced by the ls labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitLs(CQL.CQLParser.LsContext)
Exit a parse tree produced by the ls labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMinusFactor(CQL.CQLParser.MinusFactorContext)
Enter a parse tree produced by the minusFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMinusFactor(CQL.CQLParser.MinusFactorContext)
Exit a parse tree produced by the minusFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterCastFactor(CQL.CQLParser.CastFactorContext)
Enter a parse tree produced by the castFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitCastFactor(CQL.CQLParser.CastFactorContext)
Exit a parse tree produced by the castFactor labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterExpr(CQL.CQLParser.ExprContext)
Enter a parse tree produced by the expr labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitExpr(CQL.CQLParser.ExprContext)
Exit a parse tree produced by the expr labeled alternative in . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterQuery(CQL.CQLParser.QueryContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitQuery(CQL.CQLParser.QueryContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterExpression(CQL.CQLParser.ExpressionContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitExpression(CQL.CQLParser.ExpressionContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterEqualsTerm(CQL.CQLParser.EqualsTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitEqualsTerm(CQL.CQLParser.EqualsTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterCompareTerm(CQL.CQLParser.CompareTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitCompareTerm(CQL.CQLParser.CompareTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterAddTerm(CQL.CQLParser.AddTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitAddTerm(CQL.CQLParser.AddTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMulTerm(CQL.CQLParser.MulTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMulTerm(CQL.CQLParser.MulTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterSpecialTerm(CQL.CQLParser.SpecialTermContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitSpecialTerm(CQL.CQLParser.SpecialTermContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterFactor(CQL.CQLParser.FactorContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitFactor(CQL.CQLParser.FactorContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterChain_element(CQL.CQLParser.Chain_elementContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitChain_element(CQL.CQLParser.Chain_elementContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterPrimary(CQL.CQLParser.PrimaryContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitPrimary(CQL.CQLParser.PrimaryContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterPrimeVar(CQL.CQLParser.PrimeVarContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitPrimeVar(CQL.CQLParser.PrimeVarContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterMember(CQL.CQLParser.MemberContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitMember(CQL.CQLParser.MemberContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterTypeName(CQL.CQLParser.TypeNameContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitTypeName(CQL.CQLParser.TypeNameContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterList(CQL.CQLParser.ListContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitList(CQL.CQLParser.ListContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterElementList(CQL.CQLParser.ElementListContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitElementList(CQL.CQLParser.ElementListContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterParameterList(CQL.CQLParser.ParameterListContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitParameterList(CQL.CQLParser.ParameterListContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterConstant(CQL.CQLParser.ConstantContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitConstant(CQL.CQLParser.ConstantContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterNullLiteral(CQL.CQLParser.NullLiteralContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitNullLiteral(CQL.CQLParser.NullLiteralContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Enter a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####ExitEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Exit a parse tree produced by . The default implementation does nothing.
> #####Parameters
> **context:** The parse tree.


####EnterEveryRule(Antlr4.Runtime.ParserRuleContext)
The default implementation does nothing.

####ExitEveryRule(Antlr4.Runtime.ParserRuleContext)
The default implementation does nothing.

####VisitTerminal(Antlr4.Runtime.Tree.ITerminalNode)
The default implementation does nothing.

####VisitErrorNode(Antlr4.Runtime.Tree.IErrorNode)
The default implementation does nothing.

##ICQLVisitor`1
            
This interface defines a complete generic visitor for a parse tree produced by .
            The return type of the visit operation.
        
###Methods


####VisitString(CQL.CQLParser.StringContext)
Visit a parse tree produced by the string labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitNull(CQL.CQLParser.NullContext)
Visit a parse tree produced by the null labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitBool(CQL.CQLParser.BoolContext)
Visit a parse tree produced by the bool labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitDecimal(CQL.CQLParser.DecimalContext)
Visit a parse tree produced by the decimal labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitEmpty(CQL.CQLParser.EmptyContext)
Visit a parse tree produced by the empty labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMinus(CQL.CQLParser.MinusContext)
Visit a parse tree produced by the minus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitPlus(CQL.CQLParser.PlusContext)
Visit a parse tree produced by the plus labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToMul(CQL.CQLParser.ToMulContext)
Visit a parse tree produced by the toMul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitArrayAccess(CQL.CQLParser.ArrayAccessContext)
Visit a parse tree produced by the arrayAccess labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMethodCall(CQL.CQLParser.MethodCallContext)
Visit a parse tree produced by the methodCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMemberCall(CQL.CQLParser.MemberCallContext)
Visit a parse tree produced by the memberCall labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitBraceElems(CQL.CQLParser.BraceElemsContext)
Visit a parse tree produced by the braceElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitBracketElems(CQL.CQLParser.BracketElemsContext)
Visit a parse tree produced by the bracketElems labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitOr(CQL.CQLParser.OrContext)
Visit a parse tree produced by the or labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToAnd(CQL.CQLParser.ToAndContext)
Visit a parse tree produced by the toAnd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToEquals(CQL.CQLParser.ToEqualsContext)
Visit a parse tree produced by the toEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitAnd(CQL.CQLParser.AndContext)
Visit a parse tree produced by the and labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitEquals(CQL.CQLParser.EqualsContext)
Visit a parse tree produced by the equals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitNotEquals(CQL.CQLParser.NotEqualsContext)
Visit a parse tree produced by the notEquals labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToCompare(CQL.CQLParser.ToCompareContext)
Visit a parse tree produced by the toCompare labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitDiv(CQL.CQLParser.DivContext)
Visit a parse tree produced by the div labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMod(CQL.CQLParser.ModContext)
Visit a parse tree produced by the mod labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMul(CQL.CQLParser.MulContext)
Visit a parse tree produced by the mul labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToSpecial(CQL.CQLParser.ToSpecialContext)
Visit a parse tree produced by the toSpecial labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMemberName(CQL.CQLParser.MemberNameContext)
Visit a parse tree produced by the memberName labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitConditional(CQL.CQLParser.ConditionalContext)
Visit a parse tree produced by the conditional labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToOr(CQL.CQLParser.ToOrContext)
Visit a parse tree produced by the toOr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitParamSingle(CQL.CQLParser.ParamSingleContext)
Visit a parse tree produced by the paramSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitParamList(CQL.CQLParser.ParamListContext)
Visit a parse tree produced by the paramList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToAdd(CQL.CQLParser.ToAddContext)
Visit a parse tree produced by the toAdd labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitLt(CQL.CQLParser.LtContext)
Visit a parse tree produced by the lt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitGte(CQL.CQLParser.GteContext)
Visit a parse tree produced by the gte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitLte(CQL.CQLParser.LteContext)
Visit a parse tree produced by the lte labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitGt(CQL.CQLParser.GtContext)
Visit a parse tree produced by the gt labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitContains(CQL.CQLParser.ContainsContext)
Visit a parse tree produced by the contains labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Visit a parse tree produced by the doesNotContain labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitIn(CQL.CQLParser.InContext)
Visit a parse tree produced by the in labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitNotIn(CQL.CQLParser.NotInContext)
Visit a parse tree produced by the notIn labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitIs(CQL.CQLParser.IsContext)
Visit a parse tree produced by the is labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitToFactor(CQL.CQLParser.ToFactorContext)
Visit a parse tree produced by the toFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitComplexFactor(CQL.CQLParser.ComplexFactorContext)
Visit a parse tree produced by the complexFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitElemSingle(CQL.CQLParser.ElemSingleContext)
Visit a parse tree produced by the elemSingle labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitElemList(CQL.CQLParser.ElemListContext)
Visit a parse tree produced by the elemList labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitTrue(CQL.CQLParser.TrueContext)
Visit a parse tree produced by the true labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitFalse(CQL.CQLParser.FalseContext)
Visit a parse tree produced by the false labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitVarExp(CQL.CQLParser.VarExpContext)
Visit a parse tree produced by the varExp labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitConst(CQL.CQLParser.ConstContext)
Visit a parse tree produced by the const labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitPlusFactor(CQL.CQLParser.PlusFactorContext)
Visit a parse tree produced by the plusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitNotFactor(CQL.CQLParser.NotFactorContext)
Visit a parse tree produced by the notFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitLs(CQL.CQLParser.LsContext)
Visit a parse tree produced by the ls labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitMinusFactor(CQL.CQLParser.MinusFactorContext)
Visit a parse tree produced by the minusFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitCastFactor(CQL.CQLParser.CastFactorContext)
Visit a parse tree produced by the castFactor labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitExpr(CQL.CQLParser.ExprContext)
Visit a parse tree produced by the expr labeled alternative in .
> #####Parameters
> **context:** The parse tree.


####VisitQuery(CQL.CQLParser.QueryContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitExpression(CQL.CQLParser.ExpressionContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitEqualsTerm(CQL.CQLParser.EqualsTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitCompareTerm(CQL.CQLParser.CompareTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitAddTerm(CQL.CQLParser.AddTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitMulTerm(CQL.CQLParser.MulTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitSpecialTerm(CQL.CQLParser.SpecialTermContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitFactor(CQL.CQLParser.FactorContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitChain_element(CQL.CQLParser.Chain_elementContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitPrimary(CQL.CQLParser.PrimaryContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitPrimeVar(CQL.CQLParser.PrimeVarContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitMember(CQL.CQLParser.MemberContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitTypeName(CQL.CQLParser.TypeNameContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitList(CQL.CQLParser.ListContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitElementList(CQL.CQLParser.ElementListContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitParameterList(CQL.CQLParser.ParameterListContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitConstant(CQL.CQLParser.ConstantContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitNullLiteral(CQL.CQLParser.NullLiteralContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


####VisitEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Visit a parse tree produced by .
> #####Parameters
> **context:** The parse tree.


##CQLBaseVisitor`1
            
This class provides an empty implementation of , which can be extended to create a visitor which only needs to handle a subset of the available methods.
            The return type of the visit operation.
        
###Methods


####VisitString(CQL.CQLParser.StringContext)
Visit a parse tree produced by the string labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitNull(CQL.CQLParser.NullContext)
Visit a parse tree produced by the null labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitBool(CQL.CQLParser.BoolContext)
Visit a parse tree produced by the bool labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitDecimal(CQL.CQLParser.DecimalContext)
Visit a parse tree produced by the decimal labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitEmpty(CQL.CQLParser.EmptyContext)
Visit a parse tree produced by the empty labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMinus(CQL.CQLParser.MinusContext)
Visit a parse tree produced by the minus labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitPlus(CQL.CQLParser.PlusContext)
Visit a parse tree produced by the plus labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToMul(CQL.CQLParser.ToMulContext)
Visit a parse tree produced by the toMul labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitArrayAccess(CQL.CQLParser.ArrayAccessContext)
Visit a parse tree produced by the arrayAccess labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMethodCall(CQL.CQLParser.MethodCallContext)
Visit a parse tree produced by the methodCall labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMemberCall(CQL.CQLParser.MemberCallContext)
Visit a parse tree produced by the memberCall labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitBraceElems(CQL.CQLParser.BraceElemsContext)
Visit a parse tree produced by the braceElems labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitBracketElems(CQL.CQLParser.BracketElemsContext)
Visit a parse tree produced by the bracketElems labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitOr(CQL.CQLParser.OrContext)
Visit a parse tree produced by the or labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToAnd(CQL.CQLParser.ToAndContext)
Visit a parse tree produced by the toAnd labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToEquals(CQL.CQLParser.ToEqualsContext)
Visit a parse tree produced by the toEquals labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitAnd(CQL.CQLParser.AndContext)
Visit a parse tree produced by the and labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitEquals(CQL.CQLParser.EqualsContext)
Visit a parse tree produced by the equals labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitNotEquals(CQL.CQLParser.NotEqualsContext)
Visit a parse tree produced by the notEquals labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToCompare(CQL.CQLParser.ToCompareContext)
Visit a parse tree produced by the toCompare labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitDiv(CQL.CQLParser.DivContext)
Visit a parse tree produced by the div labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMod(CQL.CQLParser.ModContext)
Visit a parse tree produced by the mod labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMul(CQL.CQLParser.MulContext)
Visit a parse tree produced by the mul labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToSpecial(CQL.CQLParser.ToSpecialContext)
Visit a parse tree produced by the toSpecial labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMemberName(CQL.CQLParser.MemberNameContext)
Visit a parse tree produced by the memberName labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitConditional(CQL.CQLParser.ConditionalContext)
Visit a parse tree produced by the conditional labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToOr(CQL.CQLParser.ToOrContext)
Visit a parse tree produced by the toOr labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitParamSingle(CQL.CQLParser.ParamSingleContext)
Visit a parse tree produced by the paramSingle labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitParamList(CQL.CQLParser.ParamListContext)
Visit a parse tree produced by the paramList labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToAdd(CQL.CQLParser.ToAddContext)
Visit a parse tree produced by the toAdd labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitLt(CQL.CQLParser.LtContext)
Visit a parse tree produced by the lt labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitGte(CQL.CQLParser.GteContext)
Visit a parse tree produced by the gte labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitLte(CQL.CQLParser.LteContext)
Visit a parse tree produced by the lte labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitGt(CQL.CQLParser.GtContext)
Visit a parse tree produced by the gt labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitContains(CQL.CQLParser.ContainsContext)
Visit a parse tree produced by the contains labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitDoesNotContain(CQL.CQLParser.DoesNotContainContext)
Visit a parse tree produced by the doesNotContain labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitIn(CQL.CQLParser.InContext)
Visit a parse tree produced by the in labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitNotIn(CQL.CQLParser.NotInContext)
Visit a parse tree produced by the notIn labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitIs(CQL.CQLParser.IsContext)
Visit a parse tree produced by the is labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitToFactor(CQL.CQLParser.ToFactorContext)
Visit a parse tree produced by the toFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitComplexFactor(CQL.CQLParser.ComplexFactorContext)
Visit a parse tree produced by the complexFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitElemSingle(CQL.CQLParser.ElemSingleContext)
Visit a parse tree produced by the elemSingle labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitElemList(CQL.CQLParser.ElemListContext)
Visit a parse tree produced by the elemList labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitTrue(CQL.CQLParser.TrueContext)
Visit a parse tree produced by the true labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitFalse(CQL.CQLParser.FalseContext)
Visit a parse tree produced by the false labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitVarExp(CQL.CQLParser.VarExpContext)
Visit a parse tree produced by the varExp labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitConst(CQL.CQLParser.ConstContext)
Visit a parse tree produced by the const labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitPlusFactor(CQL.CQLParser.PlusFactorContext)
Visit a parse tree produced by the plusFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitNotFactor(CQL.CQLParser.NotFactorContext)
Visit a parse tree produced by the notFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitLs(CQL.CQLParser.LsContext)
Visit a parse tree produced by the ls labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMinusFactor(CQL.CQLParser.MinusFactorContext)
Visit a parse tree produced by the minusFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitCastFactor(CQL.CQLParser.CastFactorContext)
Visit a parse tree produced by the castFactor labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitExpr(CQL.CQLParser.ExprContext)
Visit a parse tree produced by the expr labeled alternative in . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitQuery(CQL.CQLParser.QueryContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitExpression(CQL.CQLParser.ExpressionContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitIfThenElseTerm(CQL.CQLParser.IfThenElseTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitLogicalOrTerm(CQL.CQLParser.LogicalOrTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitLogicalAndTerm(CQL.CQLParser.LogicalAndTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitEqualsTerm(CQL.CQLParser.EqualsTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitCompareTerm(CQL.CQLParser.CompareTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitAddTerm(CQL.CQLParser.AddTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMulTerm(CQL.CQLParser.MulTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitSpecialTerm(CQL.CQLParser.SpecialTermContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitFactor(CQL.CQLParser.FactorContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitChain_element(CQL.CQLParser.Chain_elementContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitPrimary(CQL.CQLParser.PrimaryContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitPrimeVar(CQL.CQLParser.PrimeVarContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitMember(CQL.CQLParser.MemberContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitTypeName(CQL.CQLParser.TypeNameContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitList(CQL.CQLParser.ListContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitElementList(CQL.CQLParser.ElementListContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitParameterList(CQL.CQLParser.ParameterListContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitConstant(CQL.CQLParser.ConstantContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitBooleanLiteral(CQL.CQLParser.BooleanLiteralContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitNullLiteral(CQL.CQLParser.NullLiteralContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.


####VisitEmptyLiteral(CQL.CQLParser.EmptyLiteralContext)
Visit a parse tree produced by . The default implementation returns the result of calling on .
> #####Parameters
> **context:** The parse tree.
