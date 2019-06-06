namespace BracketsTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit 

[<TestClass>]
type ``BracketsTests`` () =

    [<TestMethod>]
    member this.``String only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraсkets "5+2*(2+3)" 0 0 0 0 |> should equal (Some true)
    
    [<TestMethod>]
    member this.``Incorrect string only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraсkets "5+2*(2)+3)" 0 0 0 0 |> should equal (Some false)
    
    [<TestMethod>]
    member this.``String only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraсkets "a[x] = 25" 0 0 0 0 |> should equal (Some true)
    
    [<TestMethod>]
    member this.``Incorrect string only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraсkets "a[x] = 2]5" 0 0 0 0 |> should equal (Some false)

    [<TestMethod>]
    member this.``String only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraсkets "x{1,25,y} = |69|" 0 0 0 0 |> should equal (Some true)
    
    [<TestMethod>]
    member this.``Incorrect string only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraсkets "{x = {y,z,x}" 0 0 0 0 |> should equal (Some false)
    
    [<TestMethod>]
    member this.``Correct string`` () =
        SequenceOfBrackets.checkBraсkets "{5 + [7 - 12 : (8 - 5) : 3] + 7 - 2} :[3 + 6 : (5 - 1)]" 0 0 0 0 |> should equal (Some true)
    
    [<TestMethod>]
    member this.``Incorrect string`` () =
        SequenceOfBrackets.checkBraсkets "{5 + [7 - 12 : (8 - 5) : 3] + 7) - 2} :[3 + 6 : (5 - 1)]" 0 0 0 0 |> should equal (Some false)

    [<TestMethod>]
    member this.``Empty string`` () =
        SequenceOfBrackets.checkBraсkets "" 0 0 0 0 |> should equal (None)

    [<TestMethod>]
    member this.``String without brackets`` () =
        SequenceOfBrackets.checkBraсkets "a*45 /  69 x + 87ab" 0 0 0 0 |> should equal (Some true)
