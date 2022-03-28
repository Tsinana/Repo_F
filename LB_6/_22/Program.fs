(*1.22 Дан целочисленный массив и интервал a..b. Необходимо найти
количество минимальных элементов в этом интервале.*)

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

///Функция задачи
let fun1 list A B=
    let rec fun1_rec list A B min accA acc= 
        match list with
        |[]->acc
        |h::t ->
            if (accA >= A)&&(accA <= B)&&(min=h) then fun1_rec t A B min (accA+1) (acc+1)
            else fun1_rec t A B min (accA+1) acc
    fun1_rec list A B (listMin list) 0 0

[<EntryPoint>]
let main argv =
    printfn "Введите интервал [a;b]"
    let A = Convert.ToInt32(Console.ReadLine())
    let B = Convert.ToInt32(Console.ReadLine())
    let list = init_list()
    printf $"{fun1 list A B}"

    0 // return an integer exit code
