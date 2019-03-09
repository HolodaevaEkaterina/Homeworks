namespace FunMapForTreesTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open FunctionMap

[<TestClass>]
type ``FunMapForTreesTests`` () =

    let myEmptyTreeBeforeFunc = Node(2, Tip, Tip)
    let myEmptyTreeAfterFunc = Node(6, Tip, Tip)
    let myTreeBeforeFunc = 
        Node(0, 
            Node(1, 
                Node(3, Tip, Tip),             
                    Node(4, Tip, Tip)), 
                        Node(2, 
                            Node (5, Tip, Tip), 
                                Node(6, Tip, Tip)))

    let myTreeAfterFunc = 
         Node(0, 
            Node(1, 
                Node(27, Tip, Tip),             
                    Node(64, Tip, Tip)), 
                        Node(8, 
                            Node (125, Tip, Tip), 
                                Node(216, Tip, Tip)))
     
    let myTreeAfterFunc1 = 
       Node(250, 
            Node(251, 
                Node(253, Tip, Tip),             
                    Node(254, Tip, Tip)), 
                        Node(252, 
                            Node(255, Tip, Tip), 
                                Node(256, Tip, Tip)))
    
    let myUnBalancedTreeBeforeFunc =
         Node(0, Tip, 
             Node(1, Tip,
                 Node(2, Tip, 
                     Node(3, Tip, Tip))))
               

    let myUnBalancedTreeAfterFunc =
         Node(0, Tip, 
             Node(1, Tip,
                 Node(8, Tip, 
                     Node(27, Tip, Tip))))

    let myUnBalancedTreeAfterFunc1 =
          Node(250, Tip, 
              Node(251, Tip,
                  Node(252, Tip, 
                      Node(253, Tip, Tip))))

    [<TestMethod>]
     member this.``Empty tree`` () =
         mapForTree myEmptyTreeBeforeFunc  (fun x -> x * 3) |> should equal myEmptyTreeAfterFunc

    [<TestMethod>]
     member this.``A tree in which for each of its vertices the height of its two subtrees is equal with exponentiation`` () =
          mapForTree myTreeBeforeFunc  (fun x -> x * x * x) |> should equal myTreeAfterFunc

     [<TestMethod>]
     member this.``A tree in which for each of its vertices the height of its two subtrees is equal with addition`` () =
          mapForTree myTreeBeforeFunc  (fun x -> x + 250) |> should equal myTreeAfterFunc1

    [<TestMethod>]
     member this.``Unbalanced tree with exponentiation`` () =
        mapForTree myUnBalancedTreeBeforeFunc  (fun x -> x * x * x) |> should equal myUnBalancedTreeAfterFunc

    [<TestMethod>]
     member this.``Unbalanced tree with addition`` () =
        mapForTree myUnBalancedTreeBeforeFunc  (fun x -> x + 250) |> should equal myUnBalancedTreeAfterFunc1
