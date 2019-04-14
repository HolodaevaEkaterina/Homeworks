module ImplementationWorkflow

open System

///checking the correctness of the entered lines
let validationCheck(str: string) = 
    match Int32.TryParse(str) with
    | (true,int) -> Some(int)
    | _ -> None
 
 ///performing calculations
type CalculationBuilder() =
    member this.Bind(x: string, f) =
        let value = validationCheck(x)
        match value with
        | None -> None
        | Some a -> f a
    member this.Return(x) = Some x