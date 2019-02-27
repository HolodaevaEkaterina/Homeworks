module MergeSort 

let mergeLists list1 list2 = 
    let rec merge list1 list2 sort =
        match (list1, list2) with
        | ([], list2) -> sort list2
        | (list1, []) -> sort list1
        | (element1::newList1, element2::newList2) ->
            if element1 <= element2 
            then merge newList1 list2 (fun x -> sort (element1::x))
            else merge list1 newList2 (fun x -> sort (element2::x))
    merge list1 list2 id

let mergeSort list = 
    let rec sortLists list sort = 
        let (firstElement, lastElement) = List.splitAt (List.length list / 2) list
        match list with
        | [] -> sort []
        | [x] -> sort list
        | _  -> sortLists firstElement (fun element -> sortLists lastElement (fun part -> sort (mergeLists element part)))
    sortLists list id

