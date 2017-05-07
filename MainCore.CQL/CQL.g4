grammar CQL;

/*
 * Parser Rules
 */

/* Queries */
query: expr=expression order=orderByPart? selection=selectPart? EOF;

orderByPart: ORDER BY exprs=orderByExpressions;

orderByExpressions
	: firsts=orderByExpressions COMMA next=orderByExpression #orderByConcat
	| last=orderByExpression                                 #orderBySingle
	;

orderByExpression
	: expr=expression ASC   #orderByAsc
	| expr=expression DESC  #orderByDesc
	| expr=expression       #orderByDefault
	;

/* Selections */
selectPart: SELECT exprs=namedExpressions;

namedExpressions
	: firsts=namedExpressions next=namedExpression #selectConcat
	| last=namedExpression                         #selectSingle
	;

namedExpression
	: expr=expression AS name=STRING_LITERAL       #exprWithStringName
	| expr=expression AS name=ID                   #exprWithIdName
	| expr=expression                              #exprWithoutName
	;

/* Expressions */
expression
	: expr=ifThenElseTerm
	;

ifThenElseTerm
	: cond=logicalOrTerm QUESTION then=expression COLON else=ifThenElseTerm #conditional
	| expr=logicalOrTerm                                                    #toOr
	;
logicalOrTerm
	: lhs=logicalOrTerm OR rhs=logicalAndTerm #or
	| expr=logicalAndTerm                     #toAnd
	;
logicalAndTerm
	: lhs=logicalAndTerm AND rhs=equalsTerm   #and
	| expr=equalsTerm                         #toEquals
	;
equalsTerm
	: lhs=equalsTerm EQUALS rhs=compareTerm      #equals
	| lhs=equalsTerm NOT_EQUALS rhs=compareTerm  #notEquals
	| expr=compareTerm                           #toCompare
	;
compareTerm
	: lhs=compareTerm GREATER_THAN rhs=addTerm        #gt
	| lhs=compareTerm GREATER_THAN_EQUALS rhs=addTerm #gte
	| lhs=compareTerm LESS_THAN rhs=addTerm           #lt
	| lhs=compareTerm LESS_THAN_EQUALS rhs=addTerm    #lte
	| expr=addTerm                                    #toAdd
	;
addTerm
	: lhs=addTerm PLUS rhs=mulTerm   #plus
	| lhs=addTerm MINUS rhs=mulTerm #minus
	| expr=mulTerm                   #toMul
	;
mulTerm
	: lhs=mulTerm MUL rhs=specialTerm #mul
	| lhs=mulTerm DIV rhs=specialTerm #div
	| lhs=mulTerm MOD rhs=specialTerm #mod
	| expr=specialTerm                #toSpecial
	;
specialTerm
    : lhs=specialTerm CONTAINS rhs=factor          #contains
	| lhs=specialTerm DOES_NOT_CONTAIN rhs=factor  #doesNotContain
	| lhs=specialTerm IN rhs=factor                #in
	| lhs=specialTerm NOT IN rhs=factor            #notIn
	| lhs=specialTerm IS rhs=factor                #is
	| lhs=specialTerm IS NOT rhs=factor            #isNot
	| expr=factor                                  #toFactor
	;
factor
    : var=ID                        #var
    | LPAREN expr=expression RPAREN #expr
    | name=ID LPAREN params=parameterList? RPAREN #function
    | NOT expr=factor               #notFactor
    | PLUS expr=factor              #plusFactor
    | MINUS expr=factor             #minusFactor
    | expr=constant                 #const
    | expr=list                     #ls
    | tag=TAG                       #tagFactor
    | metric=METRIC_KEY             #metricFactor      
    ;
list
    : LBRACE elems=elementList RBRACE     #braceElems
    | LBRACKET elems=elementList RBRACKET #bracketElems
    ;
elementList
	: elems=elementList COMMA next=expression #elemList
	| expr=expression                         #elemSingle
	;
parameterList
	: elems=parameterList COMMA next=expression #paramList
	| expression                                #paramSingle
	;
constant
    : value=STRING_LITERAL  #string
    | value=DECIMAL_LITERAL #decimal
    | value=NULL_LITERAL    #null
    | value=EMPTY_LITERAL   #empty
    | value=BOOLEAN_LITERAL #bool
    ;

/*
 * Lexer Rules
 */
LBRACE: '{';
TAG: ID? DIV ID;
METRIC_KEY: ID DOT ID;
DOT: '.';
RBRACE: '}';
LBRACKET: '[';
RBRACKET: ']';
QUESTION: '?';
COLON: ':';
ID : [a-zA-Z_][A-Za-z_0-9]*;
LPAREN: '(';
RPAREN: ')';
COMMA: ',';
AND : A N D | '&&';
OR : O R | '||';
ORDER : O R D E R;
NOT : N O T | '!';
BY : B Y;
ASC: A S C;
DESC: D E S C;
PLUS : '+';
MINUS : '-';
MUL : '*';
MOD : '%';
DIV : '/';
EQUALS: '=';
NOT_EQUALS: '!=';
GREATER_THAN: '>';
GREATER_THAN_EQUALS: '>=';
LESS_THAN: '<';
LESS_THAN_EQUALS: '<=';
IN: I N;
CONTAINS: '~';
DOES_NOT_CONTAIN: '!~';
IS: I S;
SELECT: S E L E C T;
AS: A S;

fragment A : ('A'|'a') ;
fragment B : ('B'|'b') ;
fragment C : ('C'|'c') ;
fragment D : ('D'|'d') ;
fragment E : ('E'|'e') ;
fragment F : ('F'|'f') ;
fragment G : ('G'|'g') ;
fragment H : ('H'|'h') ;
fragment I : ('I'|'i') ;
fragment J : ('J'|'j') ;
fragment K : ('K'|'k') ;
fragment L : ('L'|'l') ;
fragment M : ('M'|'m') ;
fragment N : ('N'|'n') ;
fragment O : ('O'|'o') ;
fragment P : ('P'|'p') ;
fragment Q : ('Q'|'q') ;
fragment R : ('R'|'r') ;
fragment S : ('S'|'s') ;
fragment T : ('T'|'t') ;
fragment U : ('U'|'u') ;
fragment V : ('V'|'v') ;
fragment W : ('W'|'w') ;
fragment X : ('X'|'x') ;
fragment Y : ('Y'|'y') ;
fragment Z : ('Z'|'z') ;

/* Strings */
STRING_LITERAL: '"' CHAR_SEQUENCE '"';
fragment CHAR_SEQUENCE: CHAR+;
fragment CHAR
    :   ~["\\\r\n\t]
    |   ESCAPE_SEQUENCE
    ;
fragment ESCAPE_SEQUENCE
    :   SIMPLE_ESCAPE_SEQUENCE
    |   UNIVERSAL_CHARACTER_NAME
    ;
fragment SIMPLE_ESCAPE_SEQUENCE:   '\\' ['"?abfnrtv\\];
fragment UNIVERSAL_CHARACTER_NAME
    :   '\\u' HEX_QUAD
    |   '\\U' HEX_QUAD HEX_QUAD
    ;
fragment HEX_QUAD: HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT;
fragment HEX_DIGIT: [0-9a-fA-F];

/* Numbers */
DECIMAL_LITERAL
    : DECIMAL_INTEGER_LITERAL '.' DECIMAL_DIGIT* EXPONENT_PART?
    | '.' DECIMAL_DIGIT+ EXPONENT_PART?
    | DECIMAL_INTEGER_LITERAL EXPONENT_PART?
    ;
fragment DECIMAL_INTEGER_LITERAL
    : '0'
    | [1-9] DECIMAL_DIGIT*
    ;
fragment EXPONENT_PART
    : [eE] [+-]? DECIMAL_DIGIT+
    ;
fragment DECIMAL_DIGIT
    : [0-9]
    ;

/* Booleans */
BOOLEAN_LITERAL
    : T R U E
    | F A L S E
    ;

/* Other constants */
NULL_LITERAL: N U L L;
EMPTY_LITERAL: E M P T Y;

WHITESPACE :  ( ' ' | '\t' | '\n' | '\r' )+ -> skip;