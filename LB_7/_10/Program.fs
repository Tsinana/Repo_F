(*Даны два массива. Необходимо найти количество совпадающих по
значению элементов.*)

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

///функция решения задачи
let func list1 list2 =
    let timer = System.Diagnostics.Stopwatch.StartNew()
    Console.WriteLine("Количество совпадающих по значению элементов = ")
    (list1,list2)||>List.allPairs|>List.filter (fun (a,b)-> a=b)|>List.length|>Console.WriteLine
    timer.Stop()
    printfn "elapsed=%O" timer.Elapsed


///Тоже самое что и func, но избегаем ситуации "Ты хоть понимаешь что будет если у тебя будут 2 листа с +100 элементов?!"
let func1 list1 list2 = 
    let timer = System.Diagnostics.Stopwatch.StartNew()
    let rec func1_rec list1 list2 quantity =
        match list1 with
        |[]->quantity
        |h::t-> 
            let quantity1 = quantity + List.length (List.filter (fun x -> x = h) list2)
            func1_rec t list2 quantity1
    Console.WriteLine("Количество совпадающих по значению элементов = ")
    func1_rec list1 list2 0|> Console.WriteLine
    timer.Stop()
    printfn "elapsed=%O" timer.Elapsed

[<EntryPoint>]
let main argv =
    //let list3 = init_list()
    //let list4 = init_list()
    let list1 = [1;2;3;4;5;] 
    let list2 = [9;8;7;6;5;4;3;2;1]
    func list1 list2
    func1 list1 list2
    //init_list()|>Console.WriteLine
    (*
    Количество совпадающих по значению элементов =
    5
    elapsed=00:00:00.0492575 - за такое -1 балл
    Количество совпадающих по значению элементов =
    5
    elapsed=00:00:00.0036955 - за такое +1 балл
    *)
    0