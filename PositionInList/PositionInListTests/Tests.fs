namespace PositionInListTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit


[<TestClass>]
type PositionInListTests() =
    [<TestMethod>]
    member test.``List  with 1 appearance on the list`` () =
        PositionInList.firstPosition 0 6 [1; 6; 4; 2; 8; 6] |> should equal (Some 1)

    [<TestMethod>]
    member test. ``Without appearance on the list`` () =
        PositionInList.firstPosition 0 7 [1; 6; 4; 2; 8; 6] |> should equal None
  
    [<TestMethod>]
    member test. ``Empty list``() =
        PositionInList.firstPosition 0 7 [] |> should equal None

    [<TestMethod>]
    member test. ``left extreme element`` () =
        PositionInList.firstPosition 0 7 [7; 2; 9; 6] |> should equal (Some 0)
    
    [<TestMethod>]
    member test. ``right extreme element`` () =
        PositionInList.firstPosition 0 6 [7; 2; 9; 6] |> should equal (Some 3)
        
