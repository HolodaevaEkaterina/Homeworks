namespace TestsForTest4

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open Test4

[<TestClass>]
type ``Tests for test4`` () =

    let salon : Auto list  = [Car("a","b","c", 1, true); Track("a", 1, true, 2)]
    let salon1 : Auto list  = [Car("a","b","c",100, true); Track("c", 50, true, 2)]
    let salon2 : Auto list  = [Car("a", "b", "c", 100, false); Car("C4","Black","Volga",2000, true)]

    [<TestMethod>]
    member this.``Random test `` () =
        brands salon |> should equal ["c"; "a"]
        sum salon |> should equal 2

    [<TestMethod>]
    member this.``Duplicate test `` () =
        brands salon1 |> should equal ["c"]
        sum salon1 |> should equal 150

    [<TestMethod>]
    member this.``Not all cars are sold`` () =
        brands salon2 |> should equal ["Volga"]
        sum salon2 |> should equal 2000
        
