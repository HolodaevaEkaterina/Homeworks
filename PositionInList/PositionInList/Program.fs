module PositionInList

let rec firstPosition count element list =
    match list with
    | _ when list = [] -> None
    | _ when List.item count list = element -> Some count
    | _ when list.Length - 1 = count  -> None 
    | _ -> firstPosition (count + 1) element list
printfn "%A" (firstPosition 0 1 [4; 1])
