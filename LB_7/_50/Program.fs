(*1.50. Для двух введенных списков L1 и L2 построить новый список,
состоящий из элементов, встречающихся только в одном из этих списков и
не повторяющихся в них.*)

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
   let list3 = List.append list1 list2
   List.filter (fun x -> ((((List.length (List.filter (fun elem -> elem = x) list3))) = 1))) list3
   
    
[<EntryPoint>]
let main argv =
    let list1 = [1;2;3;4;5;6;7;8]
    let list2 = [3;4;5;6;7;9]
    func list1 list2|>write_list|>ignore
    0 
