(*1.40 Дан целочисленный массив. Необходимо найти минимальный
четный элемент.*)

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
let func list1 =  
    List.sort list1|>List.find (fun a -> (a%2)=0)|>Console.WriteLine
    
[<EntryPoint>]
let main argv =
    let list1 = init_list()
    func list1|>ignore 
    0 
