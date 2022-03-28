(*.46 Дан целочисленный массив. Необходимо вывести вначале его
положительные элементы, а затем - отрицательные.
*)

open System

//Иниц. списка
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

///ф-ия задачи
let func list =
    let rec func_rec list newList1  =
        match list with
        |[]->newList1
        |h::t->
            if h<0 then func_rec t (newList1@[h])
            else func_rec t ([h]@newList1)
    func_rec list []

[<EntryPoint>]
let main argv =
    init_list()|>func|>write_list|>ignore
    0 // return an integer exit code
