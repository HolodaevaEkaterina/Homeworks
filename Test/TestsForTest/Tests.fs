namespace TestsForTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type TestsForTests () =

    [<TestMethod>]
    member this.``Sum of even fibonacci numbers`` () =
        Test.sumEvenFibonacciNumbers() |> should equal 1089154;
