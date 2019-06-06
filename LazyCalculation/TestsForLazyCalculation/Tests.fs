namespace TestsForLazyCalculation

open Microsoft.VisualStudio.TestTools.UnitTesting
open Program
open LazyFactory
open LazyCalculation
open FsUnit
open System
open System.Threading

[<TestClass>]
type ``Tests for Lazy Calculation`` () =
    let random = Random()

    [<TestMethod>]
    member this.``Test for single threaded mode`` () =
        let list = [1..10]
        let obj = LazyFactory.CreateSingleThreadedLazy(fun () -> random.Next())
        let actualList = List.map(fun x -> (obj :> ILazy<int>).Get()) list
        let expectedResult = (obj :> ILazy<int>).Get()
        actualList |> List.iter (should equal expectedResult)

    [<TestMethod>]
    member this.``Test for multithreaded mode`` () =
        
        let object = LazyFactory.CreateMultiThreadedLazy(fun () -> random.Next())
        let threadCount = 80
        let results = Array.zeroCreate threadCount
        let threads = [| for index in 0..threadCount - 1 -> new Thread(fun () -> results.[index] <-  (object :> ILazy<int>).Get()) |]
        threads |> Array.iter (fun thread -> thread.Start())
        threads |> Array.iter (fun thread -> thread.Join())
        let expectedResult = (object :> ILazy<int>).Get()
        results |> Array.iter (should equal expectedResult)

    [<TestMethod>]
    member this.``Test for lock-free`` () =
        let object = LazyFactory.CreateLockFreeThreadedLazy(fun () -> random.Next())
        let threadCount = 80
        let results = Array.zeroCreate threadCount
        let threads = [| for index in 0..threadCount - 1 -> new Thread(fun () -> results.[index] <- (object :> ILazy<int>).Get()) |]
        threads |> Array.iter (fun thread -> thread.Start())
        threads |> Array.iter (fun thread -> thread.Join())
        let expectedResult = (object :> ILazy<int>).Get()
        results |> Array.iter (should equal expectedResult)
