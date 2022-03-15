(*Задание 15. Написать функцию обход взаимно простых компонентов
числа, которая выполняет операции над числами, взаимно простыми с
данным, принимает три аргумента, число, функция (например, сумма,
произведение, минимум, максимум, количество) и инициализирующее
значение. Функция должна иметь два Int аргумента и возвращать Int*)

open System

let rec NOD a b =
    if a%b=0 then b
    else NOD b (a%b)

let rec divider_rc (a:int,init:int,beg:int,func: int->int->int):int = 
    match beg with
    | _ when beg>a ->init
    | _ when (NOD a beg) = 1 -> divider_rc (a,func beg init,beg+1,func)
    | _ -> divider_rc (a,init,beg+1,func)

let UberFunc (a:int,init:int,func: int->int->int):int = divider_rc (a,init,1,func)

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn $"{UberFunc(a,0,fun a b->a+b)}"
    printfn $"{UberFunc(a,1,fun a b->a*b)}"
    0
