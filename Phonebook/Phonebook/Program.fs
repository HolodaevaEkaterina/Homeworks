module Phonebook

open System
open System.IO

let showOpportunities =
    printfn "Select the desired item"
    printfn "1. выйти"
    printfn "2. добавить запись (имя и телефон)"
    printfn "3. найти телефон по имени"
    printfn "4. найти имя по телефону"
    printfn "5. вывести всё текущее содержимое базы"
    printfn "6. сохранить текущие данные в файл"
    printfn "7. считать данные из файла"

let addNote number name phonebook = Map.add number name phonebook
let findPhone phonebook desiredName = phonebook |> Map.filter(fun key value -> value = desiredName)
let findName phonebook desiredNumber =  phonebook |> Map.find desiredNumber
let saveToFile fileName phonebook = let fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)
                                    use writer = new StreamWriter(fs)
                                    phonebook |> Map.toList |> List.fold (fun acc pair -> acc + (snd pair) + " " + (fst pair) + writer.NewLine) "" |> writer.Write 
                                    writer.Close()
                                    
let readData (sr : StreamReader) = 
        let rec readData' (sr : StreamReader) phoneBook = 
            if (not sr.EndOfStream)
            then
                let subString = sr.ReadLine()
                readData' sr (subString :: phoneBook)
            else
                sr.Close()
                phoneBook
        readData' sr []

let readFromFile (filePath : string) = 
    if (File.Exists filePath)
    then
        use sr = new StreamReader(File.OpenRead(filePath))
        readData sr
    else
            []

let rec furtherAction phonebook =
    let userChoice = Console.ReadLine()
    match userChoice with
    | "1" -> printfn "Goodbye"
    | "2" ->
        printfn "Enter new name"
        let name = Console.ReadLine()
        printfn "Enter new number"
        let number = Console.ReadLine()
        furtherAction <| addNote number name phonebook
    | "3" ->
        printfn "Enter name"
        let desiredName = Console.ReadLine()
        printfn "%A" (findPhone phonebook desiredName |> Map.iter (fun key value -> printfn "number: %s name: %s" key value))
        furtherAction phonebook
    | "4" ->
        printfn "Enter new number"
        let desiredNumber = Console.ReadLine()
        findName phonebook desiredNumber |> printf "%A"
        furtherAction phonebook
    | "5" -> 
        phonebook |> Map.iter (fun key value -> printfn "number: %s name: %s" key value)
        furtherAction phonebook
    | "6" ->
        printf "Enter name of file: "
        let fileName = Console.ReadLine() 
        saveToFile fileName phonebook
        printfn "Done"
        furtherAction phonebook
    | "7" ->
       try
           printf "Enter name of file: "
           let fileName = System.Console.ReadLine() 
           printfn "%A" (readFromFile fileName)
           furtherAction phonebook
       with :? FileNotFoundException -> printfn "File not found"
    | _ -> furtherAction phonebook
furtherAction (Map.ofList [])