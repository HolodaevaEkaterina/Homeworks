module Point_freeTests

open NUnit.Framework
open FsCheck
open FsUnit

[<Test>]
let ``Let us prove that function 1 gives the same result``() =
        Check.Quick(fun x l -> (PointFreeStyle.func x l) = (PointFreeStyle.func1 x l)) 

[<Test>]
let ``Let us prove that the function 2 gives the same result``() =
        Check.Quick(fun x l -> (PointFreeStyle.func x l) = (PointFreeStyle.func2 x l)) 

[<Test>]
let ``Let us prove that the function 3 gives the same result``() =
        Check.Quick(fun x l -> (PointFreeStyle.func x l) = (PointFreeStyle.func3 x l)) 