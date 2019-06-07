namespace InterpreterTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open Interpreter



[<TestClass>]
type ``InterpreterTests ``() =

    [<TestMethod>]
    member this.`` Test for simple expression``() =
         reduce (Application(LambdaAbstraction ("x", Variable "x"), Variable "x")) |> should equal (Variable "x")
    
    [<TestMethod>]
    member this.`` Test for random expression``() =
         let expr = LambdaAbstraction("x",Application(Application(Variable "x", Variable "x"), Variable "x"))
         reduce (Application(LambdaAbstraction("x", Variable "y"), Application(expr, expr)))|> should equal (Variable "y")
     
    [<TestMethod>]
    member this.`` Test with renaming``() =
         let expr = LambdaAbstraction("x",Application(Application(Variable "x", Variable "x"), Variable "x"))
         reduce (Application(LambdaAbstraction("x", LambdaAbstraction("y", Application(Variable "x", Variable "y"))), Variable "y")) |> should equal (LambdaAbstraction( "y1", Application( Variable "y" , Variable "y1" )))