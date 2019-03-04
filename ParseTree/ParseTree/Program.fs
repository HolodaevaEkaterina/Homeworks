module ParseTree

/// <summary>
/// arithmetic expression parse tree
/// </summary>

type Expression =
    | Plus of Expression * Expression
    | Minus of Expression * Expression
    | Multiplication of Expression * Expression
    | Divide of Expression * Expression
    | Result of int

/// <summary>
/// code that computes an arithmetic expression parse tree
/// </summary>

///<exception cref = System.DivideByZeroException > occurs when dividing by 0 </exception>

let rec expr (p: Expression) =
    match p with
    | Result p -> p
    | Plus(p1, p2) -> expr p1 + expr p2
    | Minus (p1, p2) -> expr p1 - expr p2
    | Multiplication (p1, p2) -> expr p1 * expr p2
    | Divide (p1, p2) -> 
        try 
            if (expr p1 % expr p2) = 0 then
                expr p1 / expr p2
            else 0
        with
        | :? System.DivideByZeroException -> printfn "Division by zero!"; 0