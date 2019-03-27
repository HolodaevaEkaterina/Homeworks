  module SequenceOfBrackets

  let rec checkBraskets (ourString : string) acc count1 count2 count3 =

    match ourString with
    |_  when ourString.Length = acc -> if count1 = 0 && count2 = 0 && count3 = 0 then Some true
                                       else Some false
    |_  when ourString.[acc] = '(' -> checkBraskets ourString (acc + 1) (count1 + 1) count2 count3
    |_  when ourString.[acc] = ')' -> if count1 <= 0  then Some false
                                      else checkBraskets ourString (acc + 1) (count1 - 1) count2 count3   
    |_  when ourString.[acc] = '{' -> checkBraskets ourString (acc + 1) count1 (count2 + 1) count3
    |_  when ourString.[acc] = '}' -> if count2 <= 0  then Some false
                                      else checkBraskets ourString (acc + 1) count1 (count2 - 1) count3  
    |_  when ourString.[acc] = '[' -> checkBraskets ourString (acc + 1) count1 count2 (count3 + 1)
    |_  when ourString.[acc] = ']' -> if count3 <= 0  then Some false
                                      else checkBraskets ourString (acc + 1) count1 count2 (count3 - 1)  
    |_ -> checkBraskets ourString (acc + 1) count1  count2 count3   