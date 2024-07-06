module Fumon.Core.ConstraintParser

open Fumon.Core.Types.ConstraintExpression
open Parsec

type UserState = unit
type Parser<'T> = Parser<'T, UserState>

let (clause, clauseRef): Parser<Clause> * Parser<Clause> ref = createParserForwardedToRef()
let (predicate, predicateRef): Parser<Predicate> * Parser<Predicate> ref = createParserForwardedToRef()

let parseStringValue (quoteChar: char): Parser<_> =
    let escapedChar = pstring "\\" >>. anyChar |>> string 
    let normalChar = manySatisfy (fun c -> c <> '\\' && c <> quoteChar)
    between (pchar quoteChar) (pchar quoteChar) (stringsSepBy normalChar escapedChar) |>> StringValue .>> spaces

let singleQuoteString: Parser<_> = parseStringValue '\''
let doubleQuoteString: Parser<_> = parseStringValue '"'

let stringValue: Parser<_> =
    choice [
        doubleQuoteString
        singleQuoteString
    ]

let intValue: Parser<_> =
    pint32 |>> IntValue .>> spaces

let value: Parser<_> =
    choice [
        stringValue
        intValue
    ]
    .>> spaces

let parameterName: Parser<_> =
    let name = manySatisfy (fun c -> c <> ']')
    between (pchar '[') (pchar ']') name .>> spaces

let relation: Parser<_> =
    choice [
        pstring "=" >>% Equal
        pstring "<>" >>% NotEqual
        pstring ">=" >>% GreaterThanOrEqual
        pstring ">" >>% GreaterThan
        pstring "<=" >>% LessThanOrEqual
        pstring "<" >>% LessThan
    ]
    .>> spaces

let andOperator: Parser<_> = skipAnyOf "aA" .>> skipAnyOf "nN" .>> skipAnyOf "dD" >>% And .>> spaces

let orOperator: Parser<_> = skipAnyOf "oO" .>> skipAnyOf "rR" >>% Or .>> spaces

let logicalOperator: Parser<_> =
    choice [
        andOperator
        orOperator
    ]

let nameFactor: Parser<_> = parameterName |>> NameFactor .>> spaces

let valueFactor: Parser<_> = value |>> ValueFactor .>> spaces

let factor: Parser<_> =
    choice [
        nameFactor
        valueFactor
    ]

let factorSet: Parser<_> = sepBy (spaces >>. factor) (pchar ',') |>> List.toArray

let relationTerm: Parser<_> = pipe3 factor relation factor (fun left relation right -> RelationTerm(left, relation, right)) .>> spaces

let inTerm: Parser<_> =
    let in' = skipAnyOf "iI" >>. skipAnyOf "nN" .>> spaces
    let factors = between (pchar '{') (pchar '}') (spaces >>. factorSet .>> spaces) .>> spaces
    pipe3 factor in' factors (fun left _ right -> InTerm(left, right))

let term: Parser<_> =
    choice [
        relationTerm
        inTerm
    ]

let termClause: Parser<_> = term |>> TermClause .>> spaces

let predicateClause: Parser<_> = between (pchar '(') (pchar ')') (spaces >>. predicate) |>> ParenPredicateClause .>> spaces

let notClause: Parser<_> =
    let not' = skipAnyOf "nN" .>> skipAnyOf "oO" .>> skipAnyOf "tT" .>> spaces
    not' >>. clause |>> NotClause .>> spaces

clauseRef.Value <-
    choice [
        notClause
        termClause
        predicateClause
    ]

let clausePredicate: Parser<_> = clause |>> ClausePredicate .>> spaces

let logicalOperatorPredicate: Parser<_> =
    pipe3 clause logicalOperator predicate (fun left op right -> LogicalOperatorPredicate(left, op, right))

predicateRef.Value <-
    choice [
        logicalOperatorPredicate
        clausePredicate
    ]

let unconditionalConstraint: Parser<_> = predicate |>> UnconditionalConstraint .>> spaces

let conditionalConstraint: Parser<_> =
    let ifKeyword = skipAnyOf "iI" .>> skipAnyOf "fF" .>> spaces
    let if' =  ifKeyword >>. predicate .>> spaces
    let thenKeyword = skipAnyOf "tT" .>> skipAnyOf "hH" .>> skipAnyOf "eE" .>> skipAnyOf "nN" .>> spaces
    let then' = thenKeyword >>. predicate .>> spaces
    let elseKeyword = skipAnyOf "eE" .>> skipAnyOf "lL" .>> skipAnyOf "sS" .>> skipAnyOf "eE" .>> spaces
    let else' =  elseKeyword >>. predicate .>> spaces
    pipe3 if' then' (opt else') (fun i t e -> ConditionalConstraint(i, t, e)) .>> spaces

let constraint_: Parser<_> =
    choice [
        conditionalConstraint
        unconditionalConstraint
    ]

let constraints: Parser<_> = spaces >>. many1 constraint_ .>> eof |>> List.toArray

let parse (str: string): Constraints =
    match runString constraints () str with
    | Ok (result, _, _) -> result
    | Error (errors, _) -> failwithf "%A" errors
