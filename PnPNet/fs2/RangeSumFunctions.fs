module RangeSumFunctions

// Рекурсивная функция для вычисления суммы целых чисел в диапазоне
let rec sumRange start finish =
    if start > finish then 0
    else start + sumRange (start + 1) finish

// Хвостовая рекурсия для вычисления суммы чисел в диапазоне
let sumRangeTailRecursive start finish =
    let rec loop acc current finish =
        if current > finish then acc
        else loop (acc + current) (current + 1) finish
    loop 0 start finish
