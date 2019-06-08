namespace BracketsTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit 

[<TestClass>]
type ``BracketsTests`` () =

    [<TestMethod>]
    member this.``String only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraсkets "5+2*(2+3)" |> should equal true
    
    [<TestMethod>]
    member this.``Incorrect string only with '(', ')' brackets`` () =
        SequenceOfBrackets.checkBraсkets "5+2*(2)+3)" |> should equal false
    
    [<TestMethod>]
    member this.``String only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraсkets "a[x] = 25" |> should equal true
    
    [<TestMethod>]
    member this.``Incorrect string only with ']', '[' brackets`` () =
        SequenceOfBrackets.checkBraсkets "a[x] = 2]5" |> should equal false

    [<TestMethod>]
    member this.``String only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraсkets "x{1,25,y} = |69|" |> should equal true
    
    [<TestMethod>]
    member this.``Incorrect string only with '{', '}' brackets`` () =
        SequenceOfBrackets.checkBraсkets "{x = {y,z,x}" |> should equal false
    
    [<TestMethod>]
    member this.``Correct string`` () =
        SequenceOfBrackets.checkBraсkets "{5 + [7 - 12 : (8 - 5) : 3] + 7 - 2} :[3 + 6 : (5 - 1)]" |> should equal true
    
    [<TestMethod>]
    member this.``Incorrect string`` () =
        SequenceOfBrackets.checkBraсkets "{5 + [7 - 12 : (8 - 5) : 3] + 7) - 2} :[3 + 6 : (5 - 1)]" |> should equal false

    [<TestMethod>]
    member this.``Empty string`` () =
        SequenceOfBrackets.checkBraсkets "" |> should equal true

    [<TestMethod>]
    member this.``String without brackets`` () =
        SequenceOfBrackets.checkBraсkets "a*45 /  69 x + 87ab" |> should equal true
    
    [<TestMethod>]
    member this.``Overlapping brackets shall not be allowed`` () =
        SequenceOfBrackets.checkBraсkets "([)]" |> should equal false
