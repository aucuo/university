module ListOperations

// Функция для выполнения операций над списками: map, sort, filter, fold, zip

/// Функция сортировки и фильтрации списка с последующим суммированием элементов
let sortedFilteredSum (inputList: int list): int =
    inputList
    |> List.sort
    |> List.filter (fun x -> x % 2 = 0)
    |> List.sum

/// Функция сортировки и фильтрации списка с последующей сверткой элементов
let sortedFilteredFold (inputList: int list): int =
    inputList
    |> List.sort
    |> List.filter (fun x -> x % 2 = 0)
    |> List.fold (fun acc x -> acc + x) 0

/// Функция сортировки и преобразования списка с последующим объединением с другим списком (zip)
let mappedSortedZipped (inputList: int list) (anotherList: int list): (int * int) list =
    inputList
    |> List.map (fun x -> x * 2)
    |> List.sort
    |> List.zip anotherList

