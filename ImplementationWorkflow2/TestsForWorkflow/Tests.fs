namespace TestsForWorkflow

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open ImplementationWorkflow

[<TestClass>]
type ``Tests for Workflow `` () =

    [<TestMethod>]
    member this.``Test with correct data`` () =
        let calculate = new CalculationBuilder()
        let result = calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
         }
        result |> should equal (Some 3)

    [<TestMethod>]
    member this.``Test with incorrect data`` () =
        let calculate = new CalculationBuilder()
        let result = calculate {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
         }
        result |> should equal None