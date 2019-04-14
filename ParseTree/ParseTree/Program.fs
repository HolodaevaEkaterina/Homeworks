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
let rec expr (p: Expression) =
    match p with
    | Result p -> p
    | Plus(p1, p2) -> expr p1 + expr p2
    | Minus(p1, p2) -> expr p1 - expr p2
    | Multiplication(p1, p2) -> expr p1 * expr p2
    | Divide(p1, p2) -> expr p1 / expr p2
        