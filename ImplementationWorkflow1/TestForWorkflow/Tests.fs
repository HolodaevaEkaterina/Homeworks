namespace TestForWorkflow

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open ImplementationWorkflow

[<TestClass>]
type ``TestForWorkflow ``() =

    [<TestMethod>]
    member this.``Simple Value Test``() =
        let rounding = new RoundingBuilder(3)
        let result = rounding {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
            }
        result |> should equal 0.048

    [<TestMethod>]
    member this.``Test with great accuracy``() =
        let rounding = new RoundingBuilder(6)
        let result = rounding {
            let! a = 15.789 * 12.123
            let! b = 3.128
            return a / b
            }
        result |> should equal 61.192470

    [<TestMethod>]
    member this.``Integer tests``() =
        let rounding = new RoundingBuilder(0)
        let result = rounding {
            let! a = 15.0 + 3.0
            let! b = 4.0
            return a * b
            }
        result |> should equal 72.0

    [<TestMethod>]
    member this.``Test with big expression``() =
        let rounding = new RoundingBuilder(2)
        let result = rounding {
            let! a = 15.0 + 3.0
            let! b = 4.0
            let! c = 12.25
            let! d = 20.225
            return a + d - c - b
            }
        result |> should equal 21.98

    [<TestMethod>]
    member this.``Test rounded to the nearest whole number``() =
        let rounding = new RoundingBuilder(0)
        let result = rounding {
            let! a = 10.0 / 3.0
            return a
            }
        result |> should equal 3.0
   