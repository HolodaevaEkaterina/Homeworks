let ReverseList list =
    let rec NewList s = function
    |[] -> s
    |h::t -> NewList(h::s) t in
    NewList [] list
printfn "%A" ( ReverseList [1; 2; 3] )