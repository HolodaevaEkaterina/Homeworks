let count = System.Console.ReadLine() |> int 
let rec fibonacci n =
    match n with
    | 1 | 2 -> 1
    | _ -> fibonacci (n-1) + fibonacci (n-2)

let rec printFibonacci n  =
    match n with 
    | 1 -> printf "%d, " (fibonacci (n))
    | _ -> printFibonacci (n-1)
           printf "%d, " (fibonacci (n))
           

printFibonacci(count)
