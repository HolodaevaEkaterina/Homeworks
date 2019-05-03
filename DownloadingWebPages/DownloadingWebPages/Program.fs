module DownloadingWebPages

open System.Text.RegularExpressions
open System.Net
open Microsoft.FSharp.Control.WebExtensions
open System.IO

let webPageLoading address =
    
    let asyncComp(address : string) = 
         async {
                let request = WebRequest.Create(address)
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let str = reader.ReadToEnd()
                printfn "%A" (address + "—" +  str.Length.ToString())
                return str
            }

    let readPage(url:string) =
        async {
            let! html = asyncComp url
            return html
          }
    
    let regex = new Regex("<a\shref=\x22https?://\w[\w-]*\.[a-zA-Z]+[^\x22]*\x22[^>]*>")
    let html = Async.RunSynchronously(readPage address)
    let webPages = regex.Matches(html)
    let pageList = [for url in webPages -> 
                       let value = url.Value
                       asyncComp(value.Substring(value.IndexOf("f=") + 3 , value.IndexOf("\">") - value.IndexOf("=\"") - 2))]
    Async.Parallel pageList |> Async.RunSynchronously |> ignore
webPageLoading "https://vk.com/id137171441"