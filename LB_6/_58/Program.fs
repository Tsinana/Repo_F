(*1.58 Для введенного списка вывести количество элементов, которые
могут быть получены как сумма двух любых других элементов списка*)

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

let func list =

    let rec counter_rec list acc =
        match list with
        |[]->acc
        |h::t->counter_rec t (acc+1)

    let rec func_rec_answer list x listAns= 
        match list with 
        |[]->(listAns@[x])
        |h::t ->
            if x=h then listAns
            else func_rec_answer t x listAns

    let rec func_rec2 list x listAns =
        match list with
        |[]->listAns
        |h::t->
            func_rec2 t x (func_rec_answer listAns (h+x) listAns)

    let rec func_rec1 list listsv listAns= 
        match list with
        |[]-> listAns
        |h::t -> 
            func_rec1 t listsv (func_rec2 listsv h listAns)
    
    let listAns = func_rec1 list list []
    Console.WriteLine()
    write_list listAns|>ignore
    Console.WriteLine()
    counter_rec listAns 0
 

[<EntryPoint>]
let main argv =
    init_list()|>func|>Console.WriteLine
    0 
