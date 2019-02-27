namespace PalindromesTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type ``palidromesTests``() =
    [<TestMethod>]
    member test.``palindrome of 1 word`` () =
       Palindromes.palindromeChecking "топот" 0 |> should equal (Some true)

    [<TestMethod>]
    member test.``not palindrome`` () =
       Palindromes.palindromeChecking "красота" 0 |> should equal (Some false)
    
    [<TestMethod>]
    member test.``multi-word palindrome`` () =
       Palindromes.palindromeChecking "а роза упала на лапу азора" 0 |> should equal (Some true)

    [<TestMethod>]
    member test.``palindrome with capital letters`` () =
       Palindromes.palindromeChecking "А роза упала на лапу азора" 0 |> should equal (Some true)

    [<TestMethod>]
    member test.``empty word`` () =
       Palindromes.palindromeChecking "" 0 |> should equal None
