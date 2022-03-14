open System

/// Функция принимающая аргументом ответ пользователя
let ansmanager (st:int):unit = 
    match st with
    |_ when st=1||st=2 -> printfn "Подлиза"
    |_ when st=3 -> printfn "Булка"
    |_ -> printfn "Дурачок"

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый ЯП?"
    printfn "1. F#"
    printfn "2. Prolog"
    printfn "3. Точно не эта парочка!"
    let ans = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "Суперпозиция"
    ansmanager ans
    System.Console.WriteLine()
    printfn "Каррирование*"
    if ans=1|| ans=2 then printfn "Подлиза"
    elif ans=3 then printfn "Булка"
    else printfn "Дурачок"
    0
