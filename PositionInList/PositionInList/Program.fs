module PositionInList

let rec firstPosition count element list =
    match list with
    | [] -> None
    | head :: tail -> if head = element then Some(count) 
                      else firstPosition (count + 1) element tail
 
printfn "%A" (firstPosition 0 1 [4; 1])
