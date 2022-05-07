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
            (Head,0)::Tail
    Console.WriteLine("Введите количество чего-нибудь")
    let a = read_list (Convert.ToInt32(Console.ReadLine()))
    Console.WriteLine("Что-то было создано\n")
    a

///Вывод списка на экран
let rec write_list = function
    |[] -> ""
    |   (head:string,_)::tail -> 
                   Console.WriteLine(head)
                   write_list tail 

//Создает список отсортированный в порядке увеличения разницы между средним количеством согласных и средним количеством гласных букв в строке
let func_1 list1 = 
     list1|>List.map(fun (str,x:int)-> (str,Math.Abs(x+((String.filter(fun c -> c='a'||c='e'||c='y'||c='u'||c='i'||c='o')str)|>String.length)-str.Length+((String.filter(fun c -> c='a'||c='e'||c='y'||c='u'||c='i'||c='o')str)|>String.length))))|>List.sortBy(fun (_,x) -> x)
     



[<EntryPoint>]
let main argv =
    let list1 = init_list()
    list1|>func_1|>ignore
    0 // return an integer exit code
