namespace BracketsTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit 

[<TestClass>]
type ``BracketsTests`` () =

    [<TestMethod>]
    member this.``String only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraskets "5+2*(2+3)" 0 0 0 0 |> should equal (Some true);
    
    [<TestMethod>]
    member this.``Incorrect string only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraskets "5+2*(2)+3)" 0 0 0 0 |> should equal (Some false);
    
    [<TestMethod>]
    member this.``String only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraskets "a[x] = 25" 0 0 0 0 |> should equal (Some true);
    
    [<TestMethod>]
    member this.``Incorrect string only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraskets "a[x] = 2]5" 0 0 0 0 |> should equal (Some false);

    [<TestMethod>]
    member this.``String only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraskets "x{1,25,y} = |69|" 0 0 0 0 |> should equal (Some true);
    
    [<TestMethod>]
    member this.``Incorrect string only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraskets "{x = {y,z,x}" 0 0 0 0 |> should equal (Some false);
    
    [<TestMethod>]
    member this.``Correct string`` () =
        SequenceOfBrackets.checkBraskets "{5 + [7 - 12 : (8 - 5) : 3] + 7 - 2} :[3 + 6 : (5 - 1)]" 0 0 0 0 |> should equal (Some true);
    
    [<TestMethod>]
    member this.``Incorrect string`` () =
        SequenceOfBrackets.checkBraskets "{5 + [7 - 12 : (8 - 5) : 3] + 7) - 2} :[3 + 6 : (5 - 1)]" 0 0 0 0 |> should equal (Some false);

    [<TestMethod>]
    member this.``Empty string`` () =
        SequenceOfBrackets.checkBraskets "" 0 0 0 0 |> should equal (Some true);

    [<TestMethod>]
    member this.``String without brackets`` () =
        SequenceOfBrackets.checkBraskets "a*45 /  69 x + 87ab" 0 0 0 0 |> should equal (Some true);
