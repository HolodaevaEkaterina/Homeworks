namespace ParseTreeTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open ParseTree

[<TestClass>]
type ``ParseTreeTests``() =

    [<TestMethod>]
    member this.``Test only with addition``() =
        expr (Plus
            (Result 5, Plus
                (Result 4, Result 6))) |> should equal 15

    [<TestMethod>]
    member this.``Test only with subtraction``() =
        expr (Minus
            (Result 254, Minus
                (Result 10, Result 6))) |> should equal 250

    [<TestMethod>]
    member this.``Multiplication test only``() =
        expr (Multiplication
            (Result 10, Multiplication
                (Result 7, Result 3))) |> should equal 210

    [<TestMethod>]
    member this.``Test only with division``() =
        expr (Divide
            (Result 1400, Divide
                (Result 20, Result 10))) |> should equal 700

    [<TestMethod>]
    member this.``Expression with addition and subtraction``() =
        expr (Plus
            (Minus
                 (Result 1400, Plus
                    (Result 40, Result 60)), Result 200)) |> should equal 1500
    
    [<TestMethod>]
    member this.``Expression with the right priority``() =
        expr (Multiplication
            (Result 4, Plus
                (Result 2, Result 3))) |> should equal 20

    [<TestMethod>]
    member this.``Expression only with multiplication and division``() =
        expr (Multiplication
            (Divide
                 (Result 1400, Divide
                    (Result 120, Result 60)), Result 20)) |> should equal 14000
