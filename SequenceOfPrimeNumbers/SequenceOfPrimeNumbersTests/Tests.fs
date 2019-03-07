namespace SequenceOfPrimeNumbersTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``PrimeNumbersTests`` () =

    [<TestMethod>]
    member this.``The sequence starts with 2``() =
        PrimeNumbers.sequenceOfNumbers () |> Seq.take 1 |> should equal [2]

    [<TestMethod>]
    member this.``The sequence contains 997 ``() =
        PrimeNumbers.sequenceOfNumbers () |> Seq.contains 997 |> should equal true 

    [<TestMethod>]
    member this.``The sequence of 11, 12, 13 prime numbers ``() =
        PrimeNumbers.sequenceOfNumbers ()  |> Seq.skip 10 |> Seq.take 3 |> should equal [31; 37; 41]

    [<TestMethod>]
    member this.``The sequence does not contains 182 ``() =
        PrimeNumbers.sequenceOfNumbers ()  |> Seq.skip 41 |> Seq.take 2 |> should equal [181; 191]