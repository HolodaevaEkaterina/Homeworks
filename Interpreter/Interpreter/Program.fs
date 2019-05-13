module Interpreter

type term = 
    |Variable of char
    |Application of  term * term
    |LambdaAbstraction of char * term 

let subst substedVar substing inTerm =
    let rec substitution substedVar substing expr list =
        match expr with
        | Variable (var) -> if List.exists (fun x -> x = substedVar) list <> true && var = substedVar then substing else expr
        | Application (expr1, expr2) -> Application (substitution substedVar substing expr1 list, substitution substedVar substing expr2 list)
        | LambdaAbstraction (var, expr) -> LambdaAbstraction (var, substitution substedVar substing expr (var::list))
    substitution substedVar substing inTerm []
      
let rec reduceOnce expr =
    match expr with
    | Variable _ -> None
    | Application (LambdaAbstraction (var, expr1), expr2) -> Some (subst var expr2 expr1)
    | Application (expr1, expr2) ->
        match reduceOnce expr1 with
        | Some x -> Some (Application (x, expr2))
        | _ -> 
        match reduceOnce expr2 with
        | Some x -> Some (Application (expr1, x))
        | _ -> None
    | LambdaAbstraction (var, expr) ->
        match reduceOnce expr with
        | Some x -> Some (LambdaAbstraction (var, x))
        | _ -> None

let rec reduce expr =
    match reduceOnce expr with
    | Some x -> reduce x
    | _ -> expr