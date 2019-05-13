namespace InterpreterTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open Interpreter



[<TestClass>]
type ``InterpreterTests ``() =

    [<TestMethod>]
    member this.`` Test for simple expression``() =
         reduce (Application(LambdaAbstraction ('x', Variable 'x'), Variable 'x')) |> should equal (Variable 'x')
    
    [<TestMethod>]
    member this.`` Test for random expression``() =
         let expr = LambdaAbstraction('x',Application(Application(Variable 'x', Variable 'x'), Variable 'x'))
         reduce (Application(LambdaAbstraction('x', Variable 'y'), Application(expr, expr)))|> should equal (Variable 'y')