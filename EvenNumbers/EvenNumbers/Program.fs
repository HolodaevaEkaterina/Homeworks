module EvenNumbers

let evenOnlyWithMap list = 
    let count = List.map (fun x ->  (x + 1) % 2) list |> List.sum    
    count

let evenOnlyWithFilter list = 
    let evenList = List.filter (fun x -> x % 2 = 0) list
    let count = List.length evenList
    count

let evenOnlyWithFold list =  List.fold ( fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 list