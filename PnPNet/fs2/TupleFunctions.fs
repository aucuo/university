module TupleFunctions

// Первый вариант: принимает кортеж значений
let tupleFunction (a, b) = (a + b, a - b)

// Второй вариант: принимает параметры в каррированном виде
let curriedFunction a b = (a + b, a - b)
