module PointFreeStyle

let func x l = List.map (fun y -> y * x) l
printfn "%A" (func 5 [5; 6] )

let func1 x : int list -> int list = List.map (fun y -> y * x)
printfn "%A" (func1 5 [5; 6]) 

let func2 x : int list -> int list = List.map ((*) x)
printfn "%A" (func2 5 [5; 6])

let func3 = (*) >> List.map
printfn "%A" (func3 5 [5; 6])