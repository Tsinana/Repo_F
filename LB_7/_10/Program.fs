(*Даны два массива. Необходимо найти количество совпадающих по
значению элементов.

Далее в задаче реализовано два подхода к осмыслению задачи 
Пусть L1 = [1,1,1] L2 = [1,1]
1. func and func1 дадут ответ - 6
2. func2 - 2
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

///функция решения задачи
let func list1 list2 =
    (list1,list2)||>List.allPairs|>List.filter (fun (a,b)-> a=b)|>List.length|>Console.WriteLine

///Тоже самое что и func, но избегаем ситуации "Ты хоть понимаешь что будет если у тебя будут 2 листа с +100 элементов?!"
let func1 list1 list2 = 
    let rec func1_rec list1 list2 quantity =
        match list1 with
        |[]->quantity
        |h::t-> 
            let quantity1 = quantity + List.length (List.filter (fun x -> x = h) list2)
            func1_rec t list2 quantity1
    func1_rec list1 list2 0|> Console.WriteLine

///Функция моего интереса 
let func2 list1 list2 = 
    let list3 = List.append list1 list2
    List.length(List.filter (fun x -> ((List.length (List.filter (fun elem -> elem = x) list3) > 1))) list3)/2|>Console.WriteLine

[<EntryPoint>]
let main argv =
    let list1 = init_list()
    let list2 = init_list()
    Console.WriteLine("Количество совпадающих по значению элементов = ")
    func list1 list2
    Console.WriteLine("Количество совпадающих по значению элементов = ")
    func1 list1 list2
    Console.WriteLine("Количество совпадающих по значению элементов = ")
    func2 list1 list2
    
    0