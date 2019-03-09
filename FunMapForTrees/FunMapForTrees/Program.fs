module FunctionMap

type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Tip  

let myFunction x = x + 1
let myTree = Node(0, Node(1, Node(2, Tip, Tip), Node(3, Tip, Tip)), Node(4, Tip, Tip))

let rec mapForTree tree f =
    match tree with
    | Node (x , l, r) -> Node(f x, mapForTree l f, mapForTree r f )
    | Tip _ -> Tip
    
printfn "%A"  (mapForTree myTree myFunction )