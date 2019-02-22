let n = System.Console.ReadLine() |> int 
let m = System.Console.ReadLine() |> int 

if (m + n < 32) && (n > 0) && (m > 0) then 
        
        let rec degreeList count acc accList =
            match count with
            | _ when count <= n -> degreeList (count + 1) (float(2) ** float(count)|>int) accList
            | _ when count > n &&  count <= m + n + 1 -> degreeList (count + 1) (float(2) ** float(count)|>int) (acc::accList)
            | _ -> List.rev(accList)

        printfn "%A" (degreeList 1 0 [])

else printfn ("error")
