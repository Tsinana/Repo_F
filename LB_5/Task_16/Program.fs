(*Задание 16. Протестировать написанную функцию. Построить отдельные
функции для вычисления числа Эйлера и НОД.*)

open System

///Ф-ия нахождения НОД
let rec NOD a b =
    if (a%b)=0 then b
    else NOD b (a%b)

///Вычисление числа Эйлера
let rec Eiler a quality beg = 
    match beg with
    | _ when beg>a ->quality
    | _ when (NOD a beg) = 1 -> 
        printfn $"Простая компонента{beg}" 
        Eiler a (quality+1) (beg+1)
    | _ -> Eiler a quality (beg+1)

let rec divider_rc (a:int,init:int,beg:int,func: int->int->int):int = 
    match beg with
    | _ when beg>a ->init
    | _ when (NOD a beg) = 1 -> divider_rc (a,func beg init,beg+1,func)
    | _ -> divider_rc (a,init,beg+1,func)

let UberFunc (a:int,init:int,func: int->int->int):int = divider_rc (a,init,1,func)
let UberFuncEiler a init = Eiler a init 1

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn $"Сумма всех взаимно простых компонент числа - {UberFunc(a,0,fun a b->a+b)}"
    printfn ""
    printfn $"Колво взаимно простых компонент числа - {UberFuncEiler a 0}"
    0
