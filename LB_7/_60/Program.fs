(*1.60. Дан список. Построить массив из элементов, делящихся на свой
номер и встречающихся в исходном массиве 1 раз.
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
    let a,b = list1|>List.indexed |>List.skip 1 |> List.filter (fun (i,x)->(x%i)=0)|>List.unzip
    b|>List.filter(fun x ->(List.length (List.filter (fun elem -> elem = x) list1))=1)

[<EntryPoint>]
let main argv =
    let list1 = init_list()
    func list1|>write_list|>ignore
    0 // return an integer exit code
