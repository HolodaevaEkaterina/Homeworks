module PrimeNumbers

let checkIsPrime n =
    let rec check x =
        match n with
        | 0 | 1 -> false
        | _ when n / 2 < x || (n % x <> 0 && check (x + 1)) -> true
        | _ -> false

    check 2

let sequenceOfNumbers () = Seq.initInfinite (fun index -> index) |> Seq.filter ( fun x -> checkIsPrime x = true)
printfn "%A" (sequenceOfNumbers ())