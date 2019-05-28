module Test4

type Auto =
    | Car of Model : string * Colour : string * Brand : string * Price : int * Sold : bool
    | Track of Brand : string * Price : int * Sold : bool * Weight : int

let rec  brandAuto (auto : Auto) = 
    match auto with
    |Car (model, colour, brand, price, true) -> brand 
    |Car (model, colour, brand, price, false) -> ""
    |Track (brand, price, true, weight) ->  brand 
    |Track (brand, price, false, weight) -> ""

let rec  sumAuto (auto : Auto) = 
    match auto with
    |Car (model, colour, brand, price, true) ->   price
    |Car (model, colour, brand, price, false) -> 0
    |Track (brand, price, true, weight) ->  price
    |Track (brand, price, false, weight) -> 0

let brands (list : Auto list) = List.filter(fun x -> x <> "") (List.distinct(List.map(fun x -> (brandAuto x)) list))
let sum (list : Auto list) = List.sum(List.map(fun x -> (sumAuto x)) list)



