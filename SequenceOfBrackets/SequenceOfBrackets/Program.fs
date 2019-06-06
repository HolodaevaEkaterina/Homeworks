  module SequenceOfBrackets

  let funHelper bracket = bracket <= 0
      
  let rec checkBraсkets (ourString : string) helper round square figured =

      match ourString with
      |_ when ourString = "" -> None
      |_ when ourString.Length = helper -> if round = 0 && square = 0 && figured = 0 then Some true
                                           else Some false
      |_ when ourString.[helper] = '(' -> checkBraсkets ourString (helper + 1) (round + 1) square figured
      |_ when ourString.[helper] = ')' -> if funHelper round then Some false
                                          else checkBraсkets ourString (helper + 1) (round - 1) square figured   
      |_ when ourString.[helper] = '{' -> checkBraсkets ourString (helper + 1) round (square + 1) figured
      |_ when ourString.[helper] = '}' -> if funHelper square then Some false
                                          else checkBraсkets ourString (helper + 1) round (square - 1) figured  
      |_ when ourString.[helper] = '[' -> checkBraсkets ourString (helper + 1) round square (figured + 1)
      |_ when ourString.[helper] = ']' -> if funHelper figured then Some false
                                          else checkBraсkets ourString (helper + 1) round square (figured - 1)  
      |_ -> checkBraсkets ourString (helper + 1) round  square figured   