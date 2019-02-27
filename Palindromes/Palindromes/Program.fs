module Palindromes

let rec palindromeChecking (string : string) count = 
    let string = string.ToLower().Replace(" ","")
    let length = String.length(string) - 1

    match string with
    |_ when string = "" -> None
    |_ when string.[count] = string.[length - count] && count <= length / 2 -> palindromeChecking string (count + 1)
    |_ -> if length / 2 = count - 1  then Some true
          else Some false


