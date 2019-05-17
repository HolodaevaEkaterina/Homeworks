module TestsForTest3 

open NUnit.Framework
open Test3
open FsUnit

[<Test>] 
let ``Test with empty stack``() = 
    let stack = new MyStack<int>() 
    stack.IsEmpty() |> should equal true 

[<Test>] 
let ``Random test``() = 
    let stack = new MyStack<int>() 
    for x in 0..50
        do stack.Push(x) 
    let expected = 50 
    let actual = stack.Pop() 
    Assert.AreEqual(expected, actual) 

[<Test>] 
let ``Test with type problem``() = 
    let stack = new MyStack<int>() 
    (fun () -> stack.Pop() |> ignore) |> should throw typeof<System.Exception>
