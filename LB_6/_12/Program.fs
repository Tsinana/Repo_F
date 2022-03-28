(*.12 Дан целочисленный массив. Необходимо переставить в обратном
порядке элементы массива, расположенные между его минимальным и
максимальным элементами*)

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

///Ф-ия поиска 
let rec find_sm list (p: int->int->int) sm = 
    match list with
    |[]-> sm
    |h::t -> find_sm t p (p sm h)

///Ф-ия поиска min
let listMin list = 
    match list with
    |[]->0
    |h::t->find_sm list (fun x y -> if x < y then x else y) h

///Ф-ия поиска max
let listMax list = 
    match list with
    |[]->0
    |h::t->find_sm list (fun x y -> if x > y then x else y) h

///Ф-ия задачи
let shell_fun1 (list):int list = 
    let rec find_first_index list max min condition newList1 newList2 newList3=
        match list with
        |[]->(newList2@newList1@newList3):int list
        |h::t ->
            if (h=max||h=min) then 
                if (condition=0) then find_first_index t max min (condition+1) newList1 (newList2@[h]) newList3
                else find_first_index t max min (condition+1) newList1 newList2 (newList3@[h])
            elif (condition=1) then find_first_index t max min condition ([h]@newList1) newList2 newList3
            elif (condition=0) then find_first_index t max min condition newList1 (newList2@[h]) newList3
            else find_first_index t max min condition newList1 newList2 (newList3@[h])
    find_first_index list (listMin list) (listMax list) 0 [] [] []

[<EntryPoint>]
let main argv =
    let list = [2;2;2;1;2;3;4;5;2;2;2]    
    write_list (shell_fun1 list) |>ignore
    0 // return an integer exit code
