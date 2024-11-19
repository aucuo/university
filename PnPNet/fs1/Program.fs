// Определим типы решений
type Solution =
    | RealSolutions of float list
    | ComplexSolutions

// Функция решения квадратного уравнения
let solveQuadratic (a: float) (b: float) (c: float) : Solution =
    let discriminant = b * b - 4.0 * a * c
    match discriminant with
    | d when d > 0.0 ->
        let sqrtD = sqrt d
        let y1 = (-b + sqrtD) / (2.0 * a)
        let y2 = (-b - sqrtD) / (2.0 * a)
        RealSolutions [y1; y2]
    | d when d = 0.0 ->
        let y = -b / (2.0 * a)
        RealSolutions [y]
    | _ ->
        ComplexSolutions

// Функция решения биквадратного уравнения
let solveBiquadratic (a: float) (b: float) (c: float) : Solution =
    // Решаем квадратное уравнение относительно y = x^2
    match solveQuadratic a b c with
    | RealSolutions ys ->
        let xs =
            ys
            |> List.collect (fun y ->
                if y < 0.0 then [] // Отрицательные значения y не дают действительных корней для x^2 = y
                else [sqrt y; -sqrt y])
        if List.isEmpty xs then
            ComplexSolutions
        else
            RealSolutions xs
    | ComplexSolutions ->
        ComplexSolutions

// Функция для печати решения уравнения
let printSolution a b c solution =
    // Печать уравнения
    printfn "Уравнение: %gx^4 + %gx^2 + %g = 0" a b c
    // Печать корней
    match solution with
    | RealSolutions xs -> printfn "Корни: %A" xs
    | ComplexSolutions -> printfn "Комплексные корни"

// Главная функция
[<EntryPoint>]
let main argv =
    let a = 1.0
    let b = -5.0
    let c = 4.0

    let solution = solveBiquadratic a b c
    printSolution a b c solution

    0 // Код возврата
