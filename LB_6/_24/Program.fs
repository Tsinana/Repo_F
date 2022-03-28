(*1.24 Дан целочисленный массив. Необходимо найти два наибольших
элемента.
*)

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

///Ф-ия задачи
let func list:int list =
    let rec func_rec (list:int list) maxF maxP = 
        match list with
        |[]-> [maxP]@[maxF]
        |h::t ->
            if h > maxF then func_rec t h maxF
            else func_rec t maxF maxP
    match list with
    |[]->[]
    |h::[] -> [h]
    |h1::h2::t-> 
        if h1 > h2 then func_rec list h1 h2
        else func_rec list h2 h1
        

[<EntryPoint>]
let main argv =
    init_list()|>func|>write_list|> ignore
    0 // return an integer exit code
