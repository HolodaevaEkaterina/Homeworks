namespace EvenNumbersTest

module Tests = 
    open FsUnit
    open FsCheck
    open EvenNumbers
    open NUnit.Framework
   
    let list1 = []
    let list2 = [1; 3; 5; 7; 9]
    let list3 = [1; 6; 5; 7; 10]
    let list4 = [568; 6; 8520; 7414; 92]


    [<Test>]
    let``Empty list ``() =
        Check.Quick(evenOnlyWithMap list1 = evenOnlyWithFilter list1) 
        Check.Quick(evenOnlyWithMap list1 = evenOnlyWithFold list1)
        evenOnlyWithFold list1 |> should equal 0

    [<Test>]
    let`` list without even numbers ``() =
        Check.Quick(evenOnlyWithMap list2 = evenOnlyWithFilter list2) 
        Check.Quick(evenOnlyWithMap list2 = evenOnlyWithFold list2)
        evenOnlyWithFold list2 |> should equal 0

    [<Test>]
    let`` list with even numbers ``() =
        Check.Quick(evenOnlyWithMap list3 = evenOnlyWithFilter list3) 
        Check.Quick(evenOnlyWithMap list3 = evenOnlyWithFold list3)
        evenOnlyWithFold list3 |> should equal 2

    [<Test>]
    let``list with even numbers only ``() =
        Check.Quick(evenOnlyWithMap list4 = evenOnlyWithFilter list4) 
        Check.Quick(evenOnlyWithMap list4 = evenOnlyWithFold list4)
        evenOnlyWithFold list4 |> should equal 5
         