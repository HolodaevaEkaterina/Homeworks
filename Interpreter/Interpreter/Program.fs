module Interpreter

open System

/// variable definition
type Var = string

/// term definition
type Term = 
    | Variable of Var
    | Application of  Term * Term
    | LambdaAbstraction of Var * Term 

/// find free variables
let getFreeVariable (term : Term) = 
    let rec freeVar (term' : Term) (list : string list) = 
        match term' with
        | Variable (x) -> x :: list
        | Application (term1, term2) -> (freeVar term1 list) @ (freeVar term2 list)
        | LambdaAbstraction (var, term3) -> freeVar term3 list |> List.filter ((<>) var)
    freeVar term [] |> List.distinct

/// renaming
let namesVar () = ['a' .. 'w'] |> List.map Char.ToString
let newName (busy : string list) = 
    let rec generate (iter : int) = 
        let names = namesVar () |> List.map (String.replicate iter)
        let notBusy = ((Set.ofList names) - (Set.ofList busy)) |> Set.toList
        match notBusy.Length with
        | 0 -> generate (iter + 1)
        | _ -> List.head notBusy
    generate 1

/// substitution
let rec reduction (term:Term) (variable : Var) value =
    match term with
    | Variable(v) when v = variable -> value
    | Variable(v) -> term
    | Application (term1, term2) -> Application(reduction term1 variable value, reduction term2 variable value)
    | LambdaAbstraction (var, term1) when var = variable -> term
    | LambdaAbstraction (var, term1) when not (getFreeVariable value |> List.contains var) || not (getFreeVariable term |> List.contains variable) -> LambdaAbstraction(var, reduction term1 variable value)
    | LambdaAbstraction (var, term1) ->  let str = newName ((getFreeVariable term) @ (getFreeVariable value))
                                         LambdaAbstraction(str, reduction (reduction term1 var (Variable str)) variable value) 

/// reduction
let rec reduce term =
    match term with
    | Variable (_) -> term
    | Application (LambdaAbstraction(var, term), term2) -> reduce (reduction term var term2)
    | Application(term1, term2) -> reduce (Application(term1, term2))
    | LambdaAbstraction (var, term) -> LambdaAbstraction (var, reduce term)