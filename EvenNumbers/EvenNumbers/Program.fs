module EvenNumbers

let evenOnlyWithMap list = 
    let remainderOfTheDivision = List.map (fun x -> x % 2) list
    let count = List.length list - List.sum remainderOfTheDivision
    count

printfn "%A" (evenOnlyWithMap [1; 2; 3; 4; 5])

let evenOnlyWithFilter list = 
    let evenList = List.filter (fun x -> x % 2 = 0) list
    let count = List.length evenList
    count

printfn "%A" (evenOnlyWithFilter [1; 2; 3; 4; 5])

let evenOnlyWithFold list =  
    let sumOfMod = List.fold ( fun acc x -> acc + x % 2) 0 list
    let count = List.length list - sumOfMod
    count   

printfn "%A" (evenOnlyWithFold [])

System.Console.ReadKey()