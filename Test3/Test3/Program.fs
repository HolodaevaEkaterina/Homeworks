module Test3 
open System.Collections.Generic 
///open Microsoft.FSharp.Math

///task 3
type MyStack<'T>() = 
    let list = new List<'T>() 
    member this.IsEmpty() = 
        list.Count = 0 
    
    member this.Push value = 
        list.Add(value) 

    member this.Pop () = 
        if (this.IsEmpty()) then failwith "Stack is empty" 
        let maxIndex = list.Count - 1 
        let elem = list.Item(maxIndex) 
        list.RemoveAt(maxIndex) 
        elem


///task 2
let printer n =
    let printLine n m =
      let s =""
      if n = m then printfn "*%s*\n" (String.replicate (m) "*")
      else printf "*%s*\n" (String.replicate (n - m) " " + String.replicate (m) "*" + String.replicate (n - m) " ")


    let rec printRow n m =
      match n with
      |_ when n <  m -> 
        printLine m n
        printRow (n + 1) m
      |_ when n = m ->
        printLine n n
        printRow (n - 1) m
      | _  when (m < n) && (n <> 0) -> 
        printLine n m
        printRow (n - 1) m
      | _ -> printLine 0 0

    if n < 1
    then
      raise (System.ArgumentException("Error"))
    else if n = 1 then printf "*\n"
    else printRow 1 n
 
printer 5
System.Console.ReadKey()
        