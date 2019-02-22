let reverseList list =
    let rec newList s = function
    |[] -> s
    |h::t -> newList (h::s) t in
    newList [] list
printfn "%A" ( reverseList [1; 2; 3] )