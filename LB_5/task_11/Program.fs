(*Задание 11. Спросить у пользователя, какой язык у него любимый, если
это F# или Prolog, ответь пользователю, что он — подлиза, для других
языков придумать комментарий, реализовать функцию, принимающую
аргументом ответ пользователя и возвращающую наш ответ
пользователю.
*)

open System

/// Функция принимающая аргументом ответ пользователя
let ans (st:int):unit = 
    System.Console.WriteLine()
    match st with
    |_ when st=1||st=2 -> printfn "Подлиза"
    |_ -> printfn "Булка"

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый ЯП?"
    printfn "1. F#"
    printfn "2. Prolog"
    printfn "3. Точно не эта парочка!"
    System.Convert.ToInt32(System.Console.ReadLine()) |> ans |> System.Console.WriteLine
    0
