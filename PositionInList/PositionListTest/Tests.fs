namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``positionInList`` ()=
    
    [<TestMethod>]
    member this.``List  with 1 appearance on the list`` () =
        PositionInList.firstPosition 0 6 [1; 6; 4; 2; 8; 6] |> should equal 1
       
