namespace InterpreterTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open Interpreter



[<TestClass>]
type ``InterpreterTests ``() =

    let term1 = LambdaAbstraction("x", Variable("x"))
    let var = "x"
    let term2 = Variable("y")

    let term3 = LambdaAbstraction("x", Application(Variable("x"), Variable("y")))
    let var2 = "y"
    let term4 = Variable("z")

    [<TestMethod>]
    member this.`` Test for simple expression``() =
         reduce (Application(LambdaAbstraction ("x", Variable "x"), Variable "x")) |> should equal (Variable "x")
    
    [<TestMethod>]
    member this.`` Test for random expression``() =
         let expr = LambdaAbstraction("x",Application(Application(Variable "x", Variable "x"), Variable "x"))
         reduce (Application(LambdaAbstraction("x", Variable "y"), Application(expr, expr)))|> should equal (Variable "y")
     
    
    [<TestMethod>]
    member this.``Test with substitution``() =
         reduction term1 var term2 |> should equal (LambdaAbstraction("x", Variable("x")))

    [<TestMethod>]
    member this.``Another test with substitution``() =
        reduction term3 var2 term4 |> should equal (LambdaAbstraction("x", Application(Variable("x"), Variable("z"))))

    [<TestMethod>]
    member this.``Test with free variables``() =
         getFreeVariable term3 |> should equal ["y"]