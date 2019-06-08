module DownloadingWebPages

open System.Text.RegularExpressions
open System.Net
open Microsoft.FSharp.Control.WebExtensions
open System.IO

/// Downloads the page and all pages to which there are links
let webPageLoading address =

    /// Asynchronous download
    let asyncComp(address : string) = 
         async {
            try
                let request = WebRequest.Create(address)
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let str = reader.ReadToEnd()
                printfn "%A" (address + "—" +  str.Length.ToString())
                return Some str
            with 
            | _ -> return None     
            }

    /// Search for regular expressions on each of the pages
    let download content = 
        let regex = new Regex("<a\shref=\x22https?://\w[\w-]*\.[a-zA-Z]+[^\x22]*\x22[^>]*>")
        let webPages = regex.Matches(content)
        let pageList = [for url in webPages -> 
                           let value = url.Value
                           asyncComp(value.Substring(value.IndexOf("f=") + 3 , value.IndexOf("\">") - value.IndexOf("=\"") - 2))]
        Async.Parallel pageList |> Async.RunSynchronously |> Array.toList

    let listPage = address |> asyncComp |> Async.RunSynchronously
    match listPage with
    | Some site -> listPage :: download site
    | None -> [None]

        