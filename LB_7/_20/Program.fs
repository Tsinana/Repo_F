(*1.20 Дан целочисленный массив. Необходимо найти все пропущенные
числа.*)

open System

///Иниц. списка
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

///функция решения задачи
let func list1 =
    let min = List.min list1
    let max = List.max list1 
    let list2 = [min..max]
    let rec func_rec list1 list2 =
        match list1 with
        |[]-> list2
        |h::t->
            let list3 = List.filter(fun a -> a <> h) list2
            func_rec t list3
    func_rec list1 list2|>write_list

[<EntryPoint>]
let main argv =
    let list1 = [1;2;5;9]
    func list1|>ignore 
    0 // return an integer exit code
