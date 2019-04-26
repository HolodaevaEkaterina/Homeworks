namespace TestsForTest2

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``TestsForTest2`` () =

    [<TestMethod>]
    member this.``The function should return "906609" ``() =
        Palindrome.searchOptions 998001 |> should equal "906609"
        
