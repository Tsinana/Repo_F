(*1.30 Дан целочисленный массив и натуральный индекс (число, меньшее
размера массива). Необходимо определить является ли элемент по
указанному индексу локальным максимумом.

List.nth проходит по списку это O(n). 
arr.[n] - O(1)
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

///функция решения задачи List.tryItem (n-2) list1
let func list1 digit = 
    let f2 list = List.nth list (List.findIndex (fun x -> x = (List.max (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))) (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))   
    
    let n = List.length list1
    if digit >= n then 
        Console.WriteLine("Не надо так")
        0
    else
        if digit = (n-1) then 
            if List.item (n-2) list1 > List.item digit list1 then List.item (n-2) list1
            else List.item (digit) list1
        elif digit = 0 then 
            if List.item (1) list1 > List.item digit list1 then List.item 1 list1
            else List.item digit list1
        else 
            [(List.item digit list1); (List.item (digit-1) list1);(List.item (digit+1) list1)]|>List.max

        (*let arr = List.toArray list1
        if digit = (n-1) then 
            if arr.[n-2] > arr.[digit] then arr.[n-2]
            else arr.[digit]
        elif digit = 0 then 
            if arr.[1] > arr.[digit] then arr.[1]
            else arr.[digit]
        else 
            [|arr.[digit];arr.[digit-1];arr.[digit+1]|]|>Array.max*)

[<EntryPoint>]
let main argv =
    let list1 = init_list()
    func list1 1|>Console.WriteLine
    0 // return an integer exit code
