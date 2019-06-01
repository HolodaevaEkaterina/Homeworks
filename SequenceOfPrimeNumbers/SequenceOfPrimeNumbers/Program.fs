module PrimeNumbers

///finds the remainder of dividing by all numbers less than the square root
let checkIsPrime n =
    let rec check x =
        match n with
        | 0 | 1 -> false
        | _ when sqrt(n |> float) |> int < x || (n % x <> 0 && check (x + 1)) -> true
        | _ -> false

    check 2

let sequenceOfNumbers () = Seq.initInfinite (id) |> Seq.filter ( fun x -> checkIsPrime x)
printfn "%A" (sequenceOfNumbers ())