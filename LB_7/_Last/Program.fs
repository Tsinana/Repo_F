(* порядке увеличения разницы между средним количеством согласных и средним количеством гласных букв в строке

В порядке увеличения среднего количества «зеркальных» троек
(например, «ada») символов в строке
*)

open System

///Иниц. списка
let init_list() = 
    let rec read_list n=
        if n=0 then []
        else
            let Head = Console.ReadLine()
            let Tail = read_list (n-1)
            Head::Tail
    Console.WriteLine("Введите количество чего-нибудь")
    let a = read_list (Convert.ToInt32(Console.ReadLine()))
    Console.WriteLine("Что-то было создано\n")
    a

///Вывод списка на экран
let rec write_list = function
    |[] -> ""
    |   (head:string)::tail -> 
                   Console.WriteLine(head)
                   write_list tail

///Возвращает список отсортированный в порядке увеличения разницы между средним количеством согласных и средним количеством гласных букв в строке
let func_1 list = 
    let rec inint i newList = 
       if i >= List.length list then newList
       else 
           let i1 = i + 1 
           inint i1 newList@[0]
    let list1 = List.zip list (inint 0 [])
    let a,b = list1|>List.map(fun (str,x:int)-> (str,Math.Abs(x+((String.filter(fun c -> c='a'||c='e'||c='y'||c='u'||c='i'||c='o')str)|>String.length)-str.Length+((String.filter(fun c -> c='a'||c='e'||c='y'||c='u'||c='i'||c='o')str)|>String.length))))|>List.sortBy(fun (_,x) -> x)|>List.unzip
    a

///Возвращает список отсортированный в порядке увеличения среднего количества «зеркальных» троек (например, «ada») символов в строке
let func_2 list1 = 
    let rec func_2_recc (str:string) i counter =
        let ln = str.Length
        if i = ln-2 then counter
        else
            let i1 = i + 1
            let c1 = counter + 1
            if str.[i]=str.[i+2] then func_2_recc str i1 c1
            else func_2_recc str i1 counter

    let rec func_2_rec list2 newlist= 
        match list2 with
        |[]->newlist
        |(h:string)::t->
            if h.Length <3 then func_2_rec t newlist@[0]
            else
                let y = func_2_recc h 0 0
                func_2_rec t newlist@[y]
    let list4 = func_2_rec list1 []
    let a,b = List.zip list1 list4|>List.sortBy (fun (_,i)->i)|> List.unzip
    a
    
let ololo list a =
    match a with
    |1-> func_1 list|>Console.WriteLine
    |2-> func_2 list|>Console.WriteLine
    |_->Console.WriteLine("ololo")

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку:")
    let list = init_list()
    Console.WriteLine("Мы -- люди свободные, так что имеем право выбирать!\n
    1. Сортировка порядке увеличения разницы между средним количеством согласных и средним количеством гласных букв в строке\n
    2. Сортировка в порядке увеличения среднего количества «зеркальных» троек (например, «ada») символов в строке?\n")
    let a = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine()
    ololo list a |>ignore
    0 // return an integer exit code