(*Задание 14. Написать функцию обход делителей числа, которая
выполняет операции над делителями числа, принимает три аргумента,
число, функция (например, сумма, произведение, минимум, максимум) и
инициализирующее значение. Функция должна иметь два Int аргумента и
возвращать Int.
*)

open System

let rec divider_rc (a:int,init:int,beg:int,func: int->int->int):int = 
    match beg with
    | _ when beg>a/2 ->init
    | _ when a%beg=0 -> divider_rc (a,func beg init,beg+1,func)
    | _ -> divider_rc (a,init,beg+1,func)


let UberFunc (a:int,init:int,func: int->int->int):int = divider_rc (a,init,1,func)

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn $"{UberFunc(a,0,fun a b->a+b)}"
    printfn $"{UberFunc(a,1,fun a b->a*b)}"
    0
