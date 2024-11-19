module ListComprehensionInput

open System

// Функция для работы с List Comprehension, где пользователь вводит диапазон
let executeListComprehension () =
    printfn "Введите диапазон для ListComprehension (начало и конец через пробел):"
    let rangeInput = Console.ReadLine().Split(' ')
    let startRange = int rangeInput.[0]
    let endRange = int rangeInput.[1]
    
    let evenTuples = [ for x in startRange .. endRange do if x % 2 = 0 then yield (x, x * x, x * x * x) ]
    printfn "Четные элементы в диапазоне [%d..%d], их квадраты и кубы: %A" startRange endRange evenTuples
