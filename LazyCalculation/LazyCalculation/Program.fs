module LazyCalculation =
    open System.Threading

    type ILazy<'a> =
        abstract member Get: unit -> 'a

/// Interface implementation without synchronization
    type SingleLazy<'a> (supplier : unit -> 'a) = 
        
        let mutable var = None

        interface ILazy<'a> with
            member this.Get () = 
                match var with 
                | Some x -> x
                | None -> 
                    let res = supplier ()
                    var <- Some res
                    res

/// Interface implementation with multi-threaded operation guarantee
    type MultiLazy<'a> (supplier : unit -> 'a) = 

        let protect = obj()
        let mutable var = None
        
        interface ILazy<'a> with 
            member this.Get () = 
                    match var with
                    | Some x -> x
                    | None ->
                        lock protect (fun () ->
                             match var with
                             | Some x -> x
                             | None ->
                                 let res = supplier ()
                                 var <- Some res
                                 Option.get var
                        )
                                        
/// The implementation of the interface with the guarantee of work in multi-threaded mode, but lock-free               
    type LockFreeLazy<'a> (supplier : unit -> 'a) = 

        let mutable var = None

        interface ILazy<'a> with
            member this.Get () = 
                match var with
                | Some x -> x
                | None ->
                    let res = supplier ()
                    Interlocked.CompareExchange(&var, Some res, None) |> ignore
                    Option.get var

open LazyCalculation

/// Class for creating different interface implementations
module LazyFactory =

    type LazyFactory() =
         
        static member CreateSingleThreadedLazy (supplier : unit -> 'a) = 
            SingleLazy<'a>(supplier)
        static member CreateMultiThreadedLazy (supplier : unit -> 'a) = 
            MultiLazy<'a>(supplier) 
        static member CreateLockFreeThreadedLazy (supplier : unit -> 'a) = 
            LockFreeLazy<'a>(supplier)