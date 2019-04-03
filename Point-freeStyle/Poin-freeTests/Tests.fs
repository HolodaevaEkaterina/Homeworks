module Point_freeTests

open NUnit.Framework
open FsCheck

[<Test>]
let ``Let us prove that the poin-free function gives the same result``() =
        Check.Quick(fun x l -> (PointFreeStyle.func x l) = (PointFreeStyle.func3 x l)) 