(*Дан целочисленный массив. Необходимо найти элементы,
расположенные перед последним минимальным.
*)

open System

///Иниц. списка
let init_list():int list = 
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

///Ф-ия поиска количества 
let find_acc list sm = 
    let rec find_acc_rec list sm acc= 
        match list with
        |[]-> acc
        |h::t ->
            if sm = h then find_acc_rec t sm (acc+1)
            else find_acc_rec t sm acc
    find_acc_rec list sm 0

///Функция задачи
let fun1 list =
    let rec fun1_rec list min acc newAcc newList= 
        match list with
        |[]->[]
        |h::t->
            if ((h=min)&&((acc-1)=newAcc)) then newList
            elif (h=min) then fun1_rec t min acc (newAcc+1) (newList@[h])
            else fun1_rec t min acc newAcc (newList@[h])
    let min = listMin list
    fun1_rec list min (find_acc list min) 0 []

[<EntryPoint>]
let main argv =
    init_list()|>fun1|>write_list|>ignore
    0 // return an integer exit code
