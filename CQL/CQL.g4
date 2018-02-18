grammar CQL;

/*
 * Parser Rules
 */

/* Queries */
query: expr=expression EOF;

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
	| expr=factor                                  #toFactor
	;
factor
	: pe=primary chain_element*                    #complexFactor
	;
chain_element
	: LPAREN params=parameterList? RPAREN          #methodCall
	| LBRACKET elems=elementList RBRACKET          #arrayAccess
	| sep=SEPARATOR id=member                      #memberCall
	;
primary
    : var=ID                                       #varExp
    | LPAREN expr=expression RPAREN                #expr
    | NOT expr=factor                              #notFactor
    | PLUS expr=factor                             #plusFactor
    | MINUS expr=factor                            #minusFactor
    | expr=constant                                #const
    | expr=list                                    #ls
	| LPAREN type=typeName RPAREN expr=expression  #castFactor     
    ;
member
	: id=ID #memberName
	;
typeName
	: castingType=ID
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
	| expr=expression                           #paramSingle
	;
constant
    : value=STRING_LITERAL  #string
    | value=DECIMAL_LITERAL #decimal
    | value=nullLiteral    #null
    | value=emptyLiteral   #empty
    | value=booleanLiteral  #bool
    ;

booleanLiteral
    : value=TRUE #true
    | value=FALSE #false
    ;
nullLiteral: NULL;
emptyLiteral: EMPTY;

/*
 * Lexer Rules
 */
TRUE: T R U E;
FALSE: F A L S E;
EMPTY: E M P T Y;
NULL: N U L L;
LBRACE: '{';
RBRACE: '}';
LBRACKET: '[';
RBRACKET: ']';
QUESTION: '?';
COLON: ':';
LPAREN: '(';
RPAREN: ')';
COMMA: ',';
AND : A N D;
OR : O R;
NOT : N O T | '!';
PLUS : '+';
MINUS : '-';
MUL : '*';
MOD : M O D;
DIV : D I V;
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
AS: A S;
SLASH: '/';
ID : [a-zA-Z_][A-Za-z_0-9]*;
SEPARATOR : SLASH|'.'|'->'|'#'|'$';

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
fragment CHAR_SEQUENCE: CHAR*;
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

WHITESPACE :  ( ' ' | '\t' | '\n' | '\r' )+ -> skip;