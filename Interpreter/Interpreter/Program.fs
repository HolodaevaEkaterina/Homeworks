module Interpreter

type Var = string

type Term = 
    | Variable of string
    | Application of  Term * Term
    | LambdaAbstraction of string * Term 

///beta-reduction
let rec reduction (term:Term) (var : Var) value =
    match term with
    | Variable(w) when w = var -> value
    | Application (x, y) -> Application(reduction x var value, reduction y var value)
    | LambdaAbstraction (x, y) -> LambdaAbstraction (x, reduction y var value)
    | _ -> term

let newVar (x : string) = (x + "1")

/// renaming
let rec rename term (v:Var) =
    match term with
    | Variable x  when x = v -> Variable (newVar x)
    | Application(x, y) -> Application(rename x v, rename y v)
    | LambdaAbstraction (x, y) -> match x with
                                  | x when x = v -> LambdaAbstraction (newVar x, rename y v)
                                  | _ -> LambdaAbstraction (x, rename y v)
    | _ -> term

/// lambda abstraction check
let rec containAbstraction term =
        match term with
        | Variable(_) -> false
        | LambdaAbstraction (y, z) -> true
        | Application(y, z) -> (containAbstraction y) || (containAbstraction z)

/// entry check        
let rec withSameLetter term l =
    match term with
    | x when x = l -> true
    | LambdaAbstraction (y, z) -> (Variable y = l) || (withSameLetter z l)
    | Application(y, z) -> (withSameLetter y l) || (withSameLetter z l)
    | _ -> false

let rec reduce term =
    match term with
    | Variable (_) -> term
    | Application (x, y) -> 
        match x with 
        | LambdaAbstraction (t, u) -> match y with
                       | Variable(v) -> if (withSameLetter x y) then (reduce <| reduction (rename u v) (if (t = v) then (newVar t) else (t)) y) else (reduce <| reduction u t y)
                       | _ -> reduce <| reduction u t y
        | Variable(_) -> Application(x, y)
        | _ -> if (containAbstraction term) then reduce <| Application(reduce x, reduce y) else Application(reduce x, reduce y)
    | LambdaAbstraction (x, y) -> 
        match y with
        | Variable (_) -> term
        | _ -> LambdaAbstraction (x, reduce y)