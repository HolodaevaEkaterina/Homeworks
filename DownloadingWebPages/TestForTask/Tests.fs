namespace TestForTask

open FsUnit
open Microsoft.VisualStudio.TestTools.UnitTesting
open DownloadingWebPages

[<TestClass>]
type ``TestForTask `` () =

    [<TestMethod>]
    member this.``Test for unlinked page `` () =
        let pages = List.length(webPageLoading "http://se.math.spbu.ru")
        pages |> should equal 1