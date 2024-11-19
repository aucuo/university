module FiniteStateMachine

// Конечный автомат с тремя состояниями
let rec stateA count =
    printfn "In StateA, count = %d" count
    if count > 0 then stateB (count - 1)

and stateB count =
    printfn "In StateB, count = %d" count
    if count > 0 then stateC (count - 1)

and stateC count =
    printfn "In StateC, count = %d" count
    if count > 0 then stateA (count - 1)
