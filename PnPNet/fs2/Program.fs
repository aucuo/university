open System
open TupleFunctions
open RangeSumFunctions
open FiniteStateMachine
open LambdaFunctions

let showMenu () =
    printfn "\nМеню:"
    printfn "1. Использовать функции TupleFunctions (tupleFunction и curriedFunction)"
    printfn "2. Использовать функции RangeSumFunctions (sumRange и sumRangeTailRecursive)"
    printfn "3. Использовать функции FiniteStateMachine (stateA)"
    printfn "4. Использовать функции LambdaFunctions (tupleLambdaFunction и curriedLambdaFunction)"
    printfn "0. Выход"

let executeChoice choice =
    match choice with
    | 1 ->
        // TupleFunctions
        printfn "Введите два числа (через пробел):"
        let input = Console.ReadLine().Split(' ')
        let a = int input.[0]
        let b = int input.[1]
        let tupleResult = tupleFunction (a, b)
        let curriedResult = curriedFunction a b
        printfn "Tuple Function Result: %A" tupleResult
        printfn "Curried Function Result: %A" curriedResult
    | 2 ->
        // RangeSumFunctions
        printfn "Введите начало и конец диапазона (через пробел):"
        let input = Console.ReadLine().Split(' ')
        let start = int input.[0]
        let finish = int input.[1]
        let sumResult = sumRange start finish
        let sumTailResult = sumRangeTailRecursive start finish
        printfn "Sum of range (%d to %d): %d" start finish sumResult
        printfn "Tail-Recursive Sum of range (%d to %d): %d" start finish sumTailResult
    | 3 ->
        // FiniteStateMachine
        printfn "Введите количество переходов:"
        let count = int (Console.ReadLine())
        stateA count
    | 4 ->
        // LambdaFunctions
        printfn "Введите три числа для суммирования (через пробел):"
        let input = Console.ReadLine().Split(' ')
        let a = int input.[0]
        let b = int input.[1]
        let c = int input.[2]
        let tupleSumResult = tupleLambdaFunction (a, b, c) sumTuple
        let curriedSumResult = curriedLambdaFunction a b c sumCurried
        printfn "Sum using tuple function: %d" tupleSumResult
        printfn "Sum using curried function: %d" curriedSumResult
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
        | _ -> executeChoice (int choice)

    0
