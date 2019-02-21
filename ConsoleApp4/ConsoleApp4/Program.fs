

let n = System.Console.ReadLine() |> int 
let factorial n = 
 let rec fact n acc = 
  if n = 1 then acc 
  else fact (n-1) (acc*n) 
   in fact n 1 ;; 
printfn "%A" (factorial n) 




