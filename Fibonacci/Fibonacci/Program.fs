let count = System.Console.ReadLine() |> int 

if count > 0 then
    let  fibonacci n =
        let rec fib_helper n acc1 acc2 =
            match n with
            | 1 | 2 -> acc2
            | _ -> fib_helper (n - 1) acc2 (acc1 + acc2)

        in fib_helper n 0 1

    let rec printFibonacci n  =
        match n with 
            | 1 -> printf "%d, " (fibonacci n)
            | _ -> printFibonacci (n - 1)
        printf "%d, " (fibonacci n)
           
    printFibonacci (count)
 else printfn ("n cannot be <=");
