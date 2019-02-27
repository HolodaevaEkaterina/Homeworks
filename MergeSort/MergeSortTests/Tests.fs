namespace MergeSortTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.``Empty list `` () =
        MergeSort.mergeSort [] |> should equal []

    [<TestMethod>]
    member this.``list of 1 item`` () =
        MergeSort.mergeSort [2] |> should equal [2]

     [<TestMethod>]
     member this.``list to sort`` () =
        MergeSort.mergeSort [2; 60; 700000; 850; 102; 4000; 360] |> should equal [2; 60; 102; 360; 850; 4000; 700000]

    [<TestMethod>]
     member this.``sorted list`` () =
        MergeSort.mergeSort [2; 6; 100; 850; 1020; 35600; 4785000] |> should equal [2; 6; 100; 850; 1020; 35600; 4785000]

     [<TestMethod>]
     member this.``partially sorted list`` () =
        MergeSort.mergeSort [2; 6; 100; 850; 689; 35600; 4785000] |> should equal [2; 6; 100; 689; 850; 35600; 4785000]

     [<TestMethod>]
     member this.``repeating list`` () =
        MergeSort.mergeSort [6; 6; 6; 6; 2; 2; 2] |> should equal [2; 2; 2; 6; 6; 6; 6]