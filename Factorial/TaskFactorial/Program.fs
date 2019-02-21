let n = System.Console.ReadLine() |> int 

let factorial n = 
    try
        let rec fact n acc = 
            if n = 0 then acc
            elif n < 0 then failwith "unable to calculate negative factorial." 
            else fact (n - 1) (acc * n) 
            in fact n 1  
    with :? System.Exception as ex -> printfn "Exception! %s " (ex.Message); 0
printfn "%A" (factorial n) 



