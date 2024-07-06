module Fumon.Core.ConstraintParser

open Fumon.Core.Types.ConstraintExpression
open Parsec

let clause, clauseRef = createParserForwardedToRef()
let predicate, predicateRef = createParserForwardedToRef()

let parseStringValue (quoteChar: char) =
    let escapedChar = pstring "\\" >>. anyChar |>> string 
    let normalChar = manySatisfy (fun c -> c <> '\\' && c <> quoteChar)
    between (pchar quoteChar) (pchar quoteChar) (stringsSepBy normalChar escapedChar) |>> StringValue .>> spaces

let singleQuoteString = parseStringValue '\''
let doubleQuoteString = parseStringValue '"'

let stringValue =
    choice [
        doubleQuoteString
        singleQuoteString
    ]

let intValue =
    pint32 |>> IntValue .>> spaces

let value =
    choice [
        stringValue
        intValue
    ]
    .>> spaces

let parameterName =
    let name = manySatisfy (fun c -> c <> ']')
    between (pchar '[') (pchar ']') name .>> spaces

let relation =
    choice [
        pstring "=" >>% Equal
        pstring "<>" >>% NotEqual
        pstring ">=" >>% GreaterThanOrEqual
        pstring ">" >>% GreaterThan
        pstring "<=" >>% LessThanOrEqual
        pstring "<" >>% LessThan
    ]
    .>> spaces

let andOperator = skipAnyOf "aA" .>> skipAnyOf "nN" .>> skipAnyOf "dD" >>% And .>> spaces

let orOperator = skipAnyOf "oO" .>> skipAnyOf "rR" >>% Or .>> spaces

let logicalOperator =
    choice [
        andOperator
        orOperator
    ]

let nameFactor = parameterName |>> NameFactor .>> spaces

let valueFactor = value |>> ValueFactor .>> spaces

let factor =
    choice [
        nameFactor
        valueFactor
    ]

let factorSet = sepBy (spaces >>. factor) (pchar ',') |>> List.toArray

let relationTerm = pipe3 factor relation factor (fun left relation right -> RelationTerm(left, relation, right)) .>> spaces

let inTerm =
    let in' = skipAnyOf "iI" >>. skipAnyOf "nN" .>> spaces
    let factors = between (pchar '{') (pchar '}') (spaces >>. factorSet .>> spaces) .>> spaces
    pipe3 factor in' factors (fun left _ right -> InTerm(left, right))

let term =
    choice [
        relationTerm
        inTerm
    ]

let termClause = term |>> TermClause .>> spaces

let predicateClause = between (pchar '(') (pchar ')') (spaces >>. predicate) |>> ParenPredicateClause .>> spaces

let notClause =
    let not' = skipAnyOf "nN" .>> skipAnyOf "oO" .>> skipAnyOf "tT" .>> spaces
    not' >>. clause |>> NotClause .>> spaces

clauseRef.Value <-
    choice [
        notClause
        termClause
        predicateClause
    ]

let clausePredicate = clause |>> ClausePredicate .>> spaces

let logicalOperatorPredicate =
    pipe3 clause logicalOperator predicate (fun left op right -> LogicalOperatorPredicate(left, op, right))

predicateRef.Value <-
    choice [
        logicalOperatorPredicate
        clausePredicate
    ]

let unconditionalConstraint = predicate |>> UnconditionalConstraint .>> spaces

let conditionalConstraint =
    let ifKeyword = skipAnyOf "iI" .>> skipAnyOf "fF" .>> spaces
    let if' =  ifKeyword >>. predicate .>> spaces
    let thenKeyword = skipAnyOf "tT" .>> skipAnyOf "hH" .>> skipAnyOf "eE" .>> skipAnyOf "nN" .>> spaces
    let then' = thenKeyword >>. predicate .>> spaces
    let elseKeyword = skipAnyOf "eE" .>> skipAnyOf "lL" .>> skipAnyOf "sS" .>> skipAnyOf "eE" .>> spaces
    let else' =  elseKeyword >>. predicate .>> spaces
    pipe3 if' then' (opt else') (fun i t e -> ConditionalConstraint(i, t, e)) .>> spaces

let constraint_ =
    choice [
        conditionalConstraint
        unconditionalConstraint
    ]

let constraints = spaces >>. many1 constraint_ .>> eof |>> List.toArray

let parse (str: string): Constraints =
    match runString constraints () str with
    | Ok (result, _, _) -> result
    | Error (errors, _) -> failwithf "%A" errors
