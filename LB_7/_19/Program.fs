(*Дана строка. Необходимо проверить, является ли она палиндромом.

Дана строка в которой записаны слова через пробел. Необходимо
посчитать количество слов.

*)

open System

///Строка полиндром?
let func_1 str1 = 
    let ln = (String.length str1)
    let rec func_1_rec (str1:string) i str2:string =
        if i = (ln/2)-1 then str2
        else 
            let i1 = i - 1
            func_1_rec str1 i1 (str2+Convert.ToString(str1.[i]))

    let str2 = func_1_rec str1 (ln-1) ""

    let rec func_1_rec1 (str1:string) i (str2:string)=
        if i = (ln/2)-1 then true
        else 
            if str1.[i] = str2.[i] then func_1_rec1 str1 (i+1) str2
            else false
            
    func_1_rec1 str1 0 str2

///Считает колво слов через пробел
let func_2 str1 =
    (str1|>String.filter(fun c-> c = ' ')|>String.length)+1

///Ф-ия выбора,а над название потом поработаю
let ololo str1 a =
    match a with
    |1-> func_1 str1|>Console.WriteLine
    |2-> func_2 str1|>Console.WriteLine
    |3 -> func_3 str1|>Console.WriteLine
    |_->Console.WriteLine("ololo")

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку:")
    let string0 = Console.ReadLine()
    Console.WriteLine("Мы -- люди свободные, так что имеем право выбирать!\n
    1. Узнать яв-ся ли слово полиндромом\n
    2. А сколько в строке словечек?\n
    3. Посчитать колво количество различных цифр в его десятичной записи\n")
    ololo string0|>ignore
    0 // return an integer exit code
