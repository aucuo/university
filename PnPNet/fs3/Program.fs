open System
open TupleFunction
open AddFunctions
open SquareListFunctions
open ListComprehensionInput
open ListOperations

let showMenu () =
    printfn "\nМеню:"
    printfn "1. Функция createTuple (создание кортежа из трех параметров)"
    printfn "2. Функции сложения (addInt, addFloat, addString)"
    printfn "3. Функция ListComprehension (четные элементы списка и их квадрат и куб)"
    printfn "4. Функции для получения квадратов элементов списка (squareListIf, squareListPattern)"
    printfn "5. Функции работы с последовательностями (map, sort, filter, fold, zip)"
    printfn "0. Выход"

let executeChoice choice =
    match choice with
    | 1 ->
        // Пример использования функции createTuple
        printfn "Введите три значения: целое число, число с плавающей запятой и строку (через пробел):"
        let input = Console.ReadLine().Split(' ')
        let a = int input.[0]
        let b = float input.[1]
        let c = input.[2]
        let tupleResult = createTuple a b c
        printfn "Результат кортежа: %A" tupleResult
    | 2 ->
        // Пример использования функций сложения
        printfn "Введите три значения типа int для сложения (через пробел):"
        let intInput = Console.ReadLine().Split(' ')
        let a = int intInput.[0]
        let b = int intInput.[1]
        let c = int intInput.[2]
        let intSum = addInt a b c
        printfn "Сумма целых чисел: %d" intSum

        printfn "Введите три значения типа float для сложения (через пробел):"
        let floatInput = Console.ReadLine().Split(' ')
        let x = float floatInput.[0]
        let y = float floatInput.[1]
        let z = float floatInput.[2]
        let floatSum = addFloat x y z
        printfn "Сумма чисел с плавающей запятой: %f" floatSum

        printfn "Введите три строки для конкатенации (через пробел):"
        let stringInput = Console.ReadLine().Split(' ')
        let str1 = stringInput.[0]
        let str2 = stringInput.[1]
        let str3 = stringInput.[2]
        let stringConcat = addString str1 str2 str3
        printfn "Конкатенация строк: %s" stringConcat
    | 3 ->
        // Пример использования функции ListComprehension с пользовательским вводом
        ListComprehensionInput.executeListComprehension ()
    | 4 ->
        // Пример использования функций для получения квадратов элементов списка
        printfn "Введите список целых чисел через пробел:"
        let listInput = Console.ReadLine().Split(' ') |> Array.map int |> List.ofArray
        let squaresIf = squareListIf listInput
        let squaresPattern = squareListPattern listInput
        printfn "Квадраты элементов списка (версия с if): %A" squaresIf
        printfn "Квадраты элементов списка (версия с сопоставлением с образцом): %A" squaresPattern
    | 5 ->
        // Пример использования операций с последовательностями с пользовательским вводом
        printfn "Введите список целых чисел через пробел:"
        let listInput = Console.ReadLine().Split(' ') |> Array.map int |> List.ofArray

        // Вызов функции sortedFilteredSum
        let sumResult = ListOperations.sortedFilteredSum listInput
        printfn "Сумма четных элементов после сортировки: %d" sumResult

        // Вызов функции sortedFilteredFold
        let foldResult = ListOperations.sortedFilteredFold listInput
        printfn "Результат свертки четных элементов после сортировки: %d" foldResult

        // Вызов функции mappedSortedZipped
        printfn "Введите второй список для объединения (zip) через пробел:"
        let anotherListInput = Console.ReadLine().Split(' ') |> Array.map int |> List.ofArray
        let zippedList = ListOperations.mappedSortedZipped listInput anotherListInput
        printfn "Результат объединения (zip): %A" zippedList
    | _ ->
        printfn "Неверный выбор. Пожалуйста, выберите снова."

[<EntryPoint>]
let main argv =
    let mutable running = true
    while running do
        showMenu()
        printfn "Введите ваш выбор:"
        let choice = Console.ReadLine()
        Console.Clear()
        match choice with
        | "0" -> running <- false
        | _ -> 
            try
                executeChoice (int choice)
            with
            | :? System.FormatException -> printfn "Ошибка: введите корректное число."

    0 // Код возврата
