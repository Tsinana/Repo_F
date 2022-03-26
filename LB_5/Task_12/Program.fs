(*Задание 12. Предыдущую программу реализовать в функции main с
помощью только оператора суперпозиции, потом только с помощью
оператора каррирования.
*)

open System

[<EntryPoint>]
let main argv =
    let ansmanager (st:string) = 
        match st with
        |"prolog"|"F#" ->  Console.WriteLine("Подлиза")
        |_ ->  Console.WriteLine("Лишь однажды")

    //Композиция функций
    printfn "Какой твой любимый ЯП?\nF#\nProlog\nТочно не эта парочка! (напиши свой вариант)"
    (Console.ReadLine >> ansmanager >> Console.WriteLine)()

    //каррирования + конвейер 
    printfn "Может что-нибудь другое?"
    Console.ReadLine() |> ansmanager
    0
