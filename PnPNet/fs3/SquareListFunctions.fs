module SquareListFunctions

// Функция, возвращающая квадраты элементов списка, используя if
let rec squareListIf (lst: int list) : int list =
    if lst.IsEmpty then
        []
    else
        let head = lst.Head
        let tail = lst.Tail
        (head * head) :: squareListIf tail

// Функция, возвращающая квадраты элементов списка, используя сопоставление с образцом
let rec squareListPattern (lst: int list) : int list =
    match lst with
    | [] -> []
    | head :: tail -> (head * head) :: squareListPattern tail
