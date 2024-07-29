namespace Tsugihagi.Core

type Ternary =
    | True
    | False
    | Unknown
with
    static member (&&&) (left, right) =
        match left, right with
        | True, True -> True
        | False, _ | _, False -> False
        | Unknown, _ | _, Unknown -> Unknown

    static member (|||) (left, right) =
        match left, right with
        | True, _ | _, True -> True
        | Unknown, _ | _, Unknown -> Unknown
        | False, False -> False

module Ternary =
    let inline ofBool b =
        match b with
        | true -> True
        | false -> False

    let inline toBool t =
        match t with
        | True -> true
        | False -> false
        | Unknown -> false

    let inline not t =
        match t with
        | True -> False
        | False -> True
        | Unknown -> Unknown

    let inline ifThen (ifPredicate: unit -> Ternary) (thenPredicate: unit -> Ternary): Ternary =
        match ifPredicate() with
        | True -> thenPredicate()
        | False -> True
        | Unknown ->
            match thenPredicate() with
            | True -> True
            | False | Unknown -> Unknown

    let inline ifThenElse (ifPredicate: unit -> Ternary) (thenPredicate: unit -> Ternary) (elsePredicate: unit -> Ternary): Ternary =
        match ifPredicate() with
        | True -> thenPredicate()
        | False -> elsePredicate()
        | Unknown ->
            match thenPredicate(), elsePredicate() with
            | True, True -> True
            | _ -> Unknown

    module Array =
        let exists (predicate: 'a -> Ternary) (array: 'a[]): Ternary =
            let rec loop index result =
                if index >= array.Length then
                    result
                else
                    match predicate array[index] with
                    | True -> True
                    | False -> loop (index + 1) result
                    | Unknown -> loop (index + 1) Unknown
            loop 0 False

        let forall (predicate: 'a -> Ternary) (array: 'a[]): Ternary =
            let rec loop index result =
                if index >= array.Length then
                    result
                else
                    match predicate array[index] with
                    | True -> loop (index + 1) result
                    | False -> False
                    | Unknown -> loop (index + 1) Unknown
            loop 0 True
