(*1.31 Дан целочисленный массив. Найти количество чётных элементов.*)

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

///Ф-ия решения задачи
let func list = 
    let rec func_rec list acc =
        match list with
        |[]->acc
        |h::t->
            if h%2=0 then func_rec t (acc+1)
            else func_rec t acc
    func_rec list 0

[<EntryPoint>]
let main argv =
    init_list()|>func|>Console.WriteLine
    0 // return an integer exit code
