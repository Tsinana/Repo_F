(*Задание 13. Написать функции произведение цифр числа, минимальная и
максимальная цифра с использованием рекурсии вверх и с
использованием хвостовой рекурсии.
*)

open System

///Хвостовая рекурсия поиска произведения числа
let rec rc a mult = 
    if a=0 then mult
    else rc (a/10) (mult * (a%10))

///Оболочка для rc
let MultiR a = rc a 1

///Ф-ия поиска max
let rec rcmx a max= 
    if a=0 then max
    elif a%10 > max then rcmx (a/10) (a%10)
    else rcmx (a/10) max

///Оболочка для rcmx
let rcMax a = rcmx a (a%10)

///Ф-ия поиска min
let rec rcmn a min = 
    if a=0 then min
    elif a%10 < min then rcmn (a/10) (a%10)
    else rcmn (a/10) min

///Оболочка для rcmn
let rcMin a = rcmn a (a%10)

///Рекурсия вверх поиска произведения числа
let rec multiR1 a = 
    if a = 0 then 1
    else (a%10) * (multiR1 (a/10))

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn $"Хвостовая рекурсия - {MultiR a}"
    printfn $"Обычная рекурсия - {multiR1 a}"
    printfn $"Min - {rcMin a}"
    printfn $"Max - {rcMax a}"
    0 
