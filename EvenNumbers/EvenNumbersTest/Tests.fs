namespace EvenNumbersTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``Count the number of even numbers ``() =

    [<TestMethod>]
    member this.``Empty list ``() =
        EvenNumbers.evenOnlyWithMap [] |> should equal 0
        EvenNumbers.evenOnlyWithFilter [] |> should equal 0
        EvenNumbers.evenOnlyWithFold [] |> should equal 0

    [<TestMethod>]
    member this.`` list without even numbers ``() =
        EvenNumbers.evenOnlyWithMap [1; 3; 5; 7; 9] |> should equal 0
        EvenNumbers.evenOnlyWithFilter [1; 3; 5; 7; 9] |> should equal 0
        EvenNumbers.evenOnlyWithFold [1; 3; 5; 7; 9] |> should equal 0

    [<TestMethod>]
    member this.`` list with even numbers ``() =
        EvenNumbers.evenOnlyWithMap [1; 6; 5; 7; 10] |> should equal 2
        EvenNumbers.evenOnlyWithFilter [1; 6; 5; 7; 10] |> should equal 2
        EvenNumbers.evenOnlyWithFold [1; 6; 5; 7; 10] |> should equal 2

    [<TestMethod>]
    member this.``list with even numbers only ``() =
        EvenNumbers.evenOnlyWithMap [568; 6; 8520; 7414; 92] |> should equal 5
        EvenNumbers.evenOnlyWithFilter [568; 6; 8520; 7414; 92] |> should equal 5
        EvenNumbers.evenOnlyWithFold [568; 6; 8520; 7414; 92] |> should equal 5

         