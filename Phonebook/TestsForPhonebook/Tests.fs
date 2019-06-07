namespace TestsForPhonebook

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit
open Phonebook
open System.IO

[<TestClass>]
type ``Tests for phonebook`` () =

    let phoneBook = Map.ofList[(1, "Nastya"); (2, "Misha"); (3, "Sasha")]
    let phoneBook1 = Map.ofList[(1, "Nastya"); (2, "Misha"); (3, "Sasha"); (4, "Sasha")]
    let phoneBook2 = Map.ofList[("1", "Nastya"); ("2", "Misha"); ("3", "Sasha")]
       
    [<TestMethod>]
    member this.``Add new record test`` () =
        let list = Map.ofList[(1, "Nastya"); (2, "Misha"); (3, "Sasha"); (5, "Denis")]
        addNote 5 "Denis" phoneBook |> should equal list

    [<TestMethod>]
    member this.``Find a name by phone`` () =
        findName phoneBook 3 |> should equal "Sasha"

    [<TestMethod>]
    member this.``Find a phone by name`` () =
        let list = Map.ofList [(3, "Sasha")]
        findPhone phoneBook "Sasha" |> should equal list

    [<TestMethod>]
    member this.``Find a phone by name with the same name`` () =
        let list = Map.ofList [(3, "Sasha"); (4, "Sasha")]
        findPhone phoneBook1 "Sasha" |> should equal list

    [<TestMethod>]
    member this.``Read from file`` () =
        saveToFile "phonebook.txt" phoneBook2
        let list = ["Sasha 3"; "Misha 2"; "Nastya 1"]
        readFromFile "phonebook.txt" |> should equal list
