module Test

//sum of even fibonacci numbers
let  sumEvenFibonacciNumbers() =
    let rec fib_helper acc1 acc2 acc3=
        if acc2 <= 1000000 && acc2 % 2 = 0  then fib_helper acc2 (acc1 + acc2) (acc2 + acc3)
        elif acc2 > 1000000 then acc3
        else fib_helper acc2 (acc1 + acc2) acc3
       
    fib_helper 0 1 0

//square drawing
let printer n =
    let printLine n m =
      let s =""
      if n = m then printf "*%s*\n" (String.replicate (m - 2) "*")
      else printf "*%s*\n" (String.replicate (m - 2) " ")

    let rec printRow n m =
      match n with
      | n when n = 1 -> 
        printLine m m
        printRow (n + 1) m
      | n when n = m ->
        printLine n n
      | _ ->
        printLine n m
        printRow (n + 1) m

    if n < 1
    then
      raise (System.ArgumentException("Error"))
    else if n = 1 then printf "*\n"
    else if n = 2 then
      printf "**\n"
      printf "**\n"
    else printRow 1 n



    