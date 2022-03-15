(*Задание 17. На основе написанных функций построить функции обход
делителей с условием и обход взаимнопростых с условием.
Протестировать написанные функции.
*)  

open System

///Ф-ия нахождения НОД*
let rec NOD a b =
    if (a%b)=0 then b
    else NOD b (a%b)

(*
///Вычисление числа Эйлера*
let rec Eiler a quality beg = 
    match beg with
    | _ when beg>a ->quality
    | _ when (NOD a beg) = 1 -> 
        printfn $"Простая компонента{beg}" 
        Eiler a (quality+1) (beg+1)
    | _ -> Eiler a quality (beg+1)
*)

///Обход взаимнопростых
let rec divider_rc (a:int,init:int,beg:int,func: int->bool,counter:int):int = 
    match beg with
    | _ when beg>a ->init
    | _ when ((NOD a beg) = 1 )&&(func beg) ->
    printfn $"{counter}. НОД({a},{beg}) = 1 и {beg} удов. условию"
    divider_rc (a,init+1,beg+1,func,counter+1)
    | _ -> divider_rc (a,init,beg+1,func,counter)

///Оболочка для обхода ВП
let UberFunc (a:int,func: int->bool):int = divider_rc (a,0,1,func,0)

/// Оболочка для ВЧЭ*
//let UberFuncEiler a init = Eiler a init 1

///Обход делителей числа и вывод их количества
let rec divider_rc1 (a:int,init:int,beg:int,func: int->bool,counter:int):int = 
    match beg with
    | _ when beg>a ->init
    | _ when ((a%beg=0)&&(func beg))-> 
    printfn $"{counter}. Делитель числа {a} число {beg} удовлетворяющие условию"
    divider_rc1 (a,init+1,beg+1,func,counter+1)
    | _ -> divider_rc1 (a,init,beg+1,func,counter)

///Оболочка для обхода ДЧ
let UberFunc1 (a:int,func: int->bool):int = divider_rc1 (a,0,1,func,0)

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn ""
    printfn $"Колво делителей числа удов. условию- {UberFunc1(a,fun a->a>4)}"
    printfn ""
    printfn $"Колво взаимно простых компонент числа - {UberFunc (a,fun a->a>4)}"
    printfn ""
    0