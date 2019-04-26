module Palindrome

let rec palindromeChecking (string : string) count = 
    let length = String.length(string) - 1

    match string with
    |_ when string = "" -> None
    |_ when string.[count] = string.[length - count] && count <= length / 2 -> palindromeChecking string (count + 1)
    |_ -> if length / 2 = count - 1  then Some true
          else Some false

let rec checkDividers num acc =
    let list = []
    match num with
    |_ when acc < 1000 -> if num % acc = 0 && (num / acc) > 99 then num :: list else list
                          checkDividers num (acc + 1)
    |_ -> []

let rec searchOptions number =
    let composition = number.ToString() 
    let count = List.length (checkDividers number 100)
    if palindromeChecking composition 0 = Some true && count >= 2
    then composition
    else searchOptions (number - 1)
printfn "%A" (searchOptions 998001)
System.Console.ReadKey()