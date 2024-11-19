module LambdaFunctions

// Функция, принимающая кортеж и лямбда-выражение
let tupleLambdaFunction (a, b, c) lambda = lambda (a, b, c)

// Функция, принимающая каррированные параметры и лямбда-выражение
let curriedLambdaFunction a b c lambda = lambda a b c

// Лямбда-выражение для суммирования
let sumTuple (a, b, c) = a + b + c
let sumCurried a b c = a + b + c
