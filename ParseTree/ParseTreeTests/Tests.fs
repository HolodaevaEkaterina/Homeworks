namespace ParseTreeTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``ParseTreeTests``() =

    [<TestMethod>]
    member this.``Test only with addition``() =
        ParseTree.expr (ParseTree.Plus
            (ParseTree.Result 5, ParseTree.Plus
                (ParseTree.Result 4, ParseTree.Result 6))) |> should equal 15

    [<TestMethod>]
    member this.``Test only with subtraction``() =
        ParseTree.expr (ParseTree.Minus
            (ParseTree.Result 254, ParseTree.Minus
                (ParseTree.Result 10, ParseTree.Result 6))) |> should equal 250

    [<TestMethod>]
    member this.``Multiplication test only``() =
        ParseTree.expr (ParseTree.Multiplication
            (ParseTree.Result 10, ParseTree.Multiplication
                (ParseTree.Result 7, ParseTree.Result 3))) |> should equal 210

    [<TestMethod>]
    member this.``Test only with division``() =
        ParseTree.expr (ParseTree.Divide
            (ParseTree.Result 1400, ParseTree.Divide
                (ParseTree.Result 20, ParseTree.Result 10))) |> should equal 700

    [<TestMethod>]
    member this.``Division test by 0``() =
        ParseTree.expr (ParseTree.Divide
            (ParseTree.Result 1400, ParseTree.Divide
                (ParseTree.Result 20, ParseTree.Result 0))) |> should equal 0

    [<TestMethod>]
    member this.``Expression with addition and subtraction``() =
        ParseTree.expr (ParseTree.Plus
            (ParseTree.Minus
                 (ParseTree.Result 1400, ParseTree.Plus
                    (ParseTree.Result 40, ParseTree.Result 60)), ParseTree.Result 200)) |> should equal 1500
    [<TestMethod>]
    member this.``Еhe result of the expression is a fraction``() =
        ParseTree.expr (ParseTree.Divide
            (ParseTree.Result 1400, ParseTree.Divide
                (ParseTree.Result 20, ParseTree.Result 13))) |> should equal 0
       
    [<TestMethod>]
    member this.``Expression with the right priority``() =
        ParseTree.expr (ParseTree.Multiplication
            (ParseTree.Result 4, ParseTree.Plus
                (ParseTree.Result 2, ParseTree.Result 3))) |> should equal 20

    [<TestMethod>]
    member this.``Expression only with multiplication and division``() =
        ParseTree.expr (ParseTree.Multiplication
            (ParseTree.Divide
                 (ParseTree.Result 1400, ParseTree.Divide
                    (ParseTree.Result 120, ParseTree.Result 60)), ParseTree.Result 20)) |> should equal 14000
