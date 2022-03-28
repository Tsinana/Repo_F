(*1.40 Дан целочисленный массив. Необходимо найти минимальный
четный элемент.*)

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

///Ф-ия чет поиска 
let rec find_sm list (p: int->int->int) sm = 
    match list with
    |[]-> sm
    |h::t -> 
        if (h%2=0) then find_sm t p (p sm h)
        else find_sm t p sm

///Ф-ия поиска min
let listMin list = 
    let rec func_rec list =
        match list with
        |[]->0
        |h::t->
            if h%2=0 then h
            else func_rec t
    let a = func_rec list 
    if a=0 then 0
    else
        match list with
        |[]->0
        |h::t->find_sm list (fun x y -> if x < y then x else y) a

[<EntryPoint>]
let main argv =
    let list = init_list()
    let a = listMin list 
    Console.WriteLine(a)
    0 // return an integer exit code
