(*Задание 11. Написать функцию, принимающую в качестве аргумента
список и функцию трех переменных, и возвращающую новый список
длины в три раза меньше, где каждый элемент — это результат
применения функции к соответствующей тройке. На основе этой
функции модифицировать введенный пользователем список так, чтобы
каждый элемент нового списка был суммой соответствующей тройки,
если количество элементов не делится на три, то в качестве
недостающих элементов использовать единицы.
*)

open System

///Игит. списка
let init_list() = 
    let rec read_list n=
        if n=0 then []
        else
            let Head = Convert.ToInt32(Console.ReadLine())
            let Tail = read_list (n-1)
            Head::Tail
    Console.WriteLine("Введите количество чего-нибудь")
    let a = read_list (Convert.ToInt32(Console.ReadLine()))
    Console.WriteLine("Что-то было создано\n")
    a

///Вывод списка на экран
let rec write_list = function
    [] -> let z = Console.ReadKey()
          0
    |   (head:int)::tail -> 
                   Console.WriteLine(head)
                   write_list tail  

///Функция задачи
let shell_for_fun1 list (f: int->int->int->int) = 
    let rec fun1 list newList =
        match list with
        |[]->newList
        |x1::x2::x3::t -> fun1 t newList @[(f x1 x2 x3)]
        |x1::x2::[] -> fun1 [] newList @[(f x1 x2 1)]
        |x1::[] -> fun1 [] newList @[(f x1 1 1)]
    fun1 list []


[<EntryPoint>]
let main argv =
    let list1 = init_list()
    let list2 = shell_for_fun1 list1 (fun x y z ->x+y+z)
    write_list list2 |> ignore
    0 

    (*
    .
    ░░░░░░░░░░░░░░░░░░░░
    ░░░░░ЗАПУСКАЕМ░░░░░░░
    ░ГУСЯ░▄▀▀▀▄░РАБОТЯГИ░░
    ▄███▀░◐░░░▌░░░░░░░░░
    ░░░░▌░░░░░▐░░░░░░░░░
    ░░░░▐░░░░░▐░░░░░░░░░
    ░░░░▌░░░░░▐▄▄░░░░░░░
    ░░░░▌░░░░▄▀▒▒▀▀▀▀▄
    ░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
    ░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
    ░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
    ░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
    ░░░░░░░░░░░▌▌░▌▌░░░░░
    ░░░░░░░░░░░▌▌░▌▌░░░░░
    ░░░░░░░░░▄▄▌▌▄▌▌░░░░░
    *)    