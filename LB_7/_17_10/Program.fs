(*17_10. Для введенного списка вывести кортеж списков, составленных из
List2 - номера элементов, которые могут быть получены как произведение
двух любых ДРУГИХ элементов списка
List3 - номера элементов, которые могут быть получены как сумма трех
любых других элементов списка.
LIST4 - номера элементов, которые делятся ровно на четыре элемента из
списка
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

///Функция решения задачи
let func list1 = 
    let listId = list1|>List.indexed

    let rec func_rec_1 a list2 count:int =
        match list2 with
        |[] -> count
        |h::t-> 
        if a%h=0 then func_rec_1 a t (count+1)
        else func_rec_1 a t count

    let rec func_rec listId list2 newList =
        match listId with 
        |[] -> newList
        |(i,x)::t -> 
            if (func_rec_1 x list2 0) = 4 then func_rec t list2 newList@[i] 
            else func_rec t list2 newList 

    let rec func_rec_full list m = 
        match m with
        |0 -> list
        |_-> func_rec_full (list@[0]) (m-1)

    let list2,a = list1|>List.indexed |>List.filter(fun (_,x)->List.exists(fun el-> List.exists(fun el1->((el1*el)=x)&&el<>x&&el1<>x)list1)list1)|>List.unzip
    let list3,a = list1|>List.indexed |>List.filter(fun (_,x)->List.exists(fun el-> List.exists(fun el1->List.exists(fun el2->((el1+el+el2)=x)&&el<>x&&el1<>x&&el2<>x)list1)list1)list1)|>List.unzip
    //Код с 6 ур вложения циклов* - совсем переборщил =) let list4,a = list1|>List.indexed |>List.filter(fun (_,x)->List.exists(fun el-> List.exists(fun el1->List.exists(fun el2->List.exists(fun el3->List.exists(fun el4->((x mod el)= 0)&&((x mod el1)= 0)&&((x mod el2)= 0)&&((x mod el3)= 0)&&((x mod el4)= 0) list1)list1)list1)list1)list1)|>List.unzip
    //Сделаем через рекурсию
    let list4 = func_rec listId list1 []

    let max = if list2.Length <list3.Length then 
                if list3.Length < list4.Length then list4.Length
                else list3.Length
              else 
                if list2.Length < list4.Length then list4.Length 
                else list2.Length

    List.zip3 (func_rec_full list3 (max-list3.Length)) (func_rec_full list4 (max-list4.Length)) (func_rec_full list2 (max-list2.Length))|>Console.WriteLine
[<EntryPoint>]
let main argv =
    let list1 = init_list()
    func list1 |>Console.WriteLine
    0 // return an integer exit code
