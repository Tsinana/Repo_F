(*Задание 18. «Работа с числами». Составить 3 функции для работы с
цифрами или делителей* числа на основании варианта с использованием
только хвостовой рекурсии. Каждый метод отдельный коммит.
Вариант № 10.
Метод 1. Найти количество четных чисел, не взаимно простых с данным числом
Метод 2. Найти максимальную цифры числа, не делящуюся на 3.
Метод 3. Найти произведение максимального числа, не взаимно простого
с данным, не делящегося на наименьший делитель исходно числа, и
суммы цифр числа, меньших 5.
*)

open System

//---метод 1---

///Ф-ия нахождения НОД*
let rec NOD a b =
    if (a%b)=0 then b
    else NOD b (a%b)

///Обход взаимнопростых
let rec divider_rc a init beg = 
    match beg with
    | _ when beg>a ->init
    | _ when ((beg%2)=0)&&((NOD a beg) <> 1 )->
    printfn $"НОД({a},{beg}) <> 1 и {beg} чет."
    divider_rc a (init+1) (beg+1)
    | _ -> divider_rc a init (beg+1)

///Оболочка для обхода ВП
let UberFunc a = divider_rc a 0 1

//---метод 2---

///Поиск максимальной цифры числа, не делящуюся на 3
let rec Search a (max:int) = 
    if a = 0 then max
    elif ((a%10)>max)&&((a%10%3<>0)) then Search (a/10) (a%10)
    else Search (a/10) max

///Оболочка для Search
let ShellForSearch a = Search a -1

//---метод 3---

///Ф-ия поиска наименьшего делителя исходно числа
let rec minDel a min =
    if a%min = 0 then min
    else minDel a (min+1)

/// Оболочка для minDel
let ShellminDel a = minDel a 2

///Ф-ия поиска суммы цифр числа, меньших 5
let rec SumNumWhichAreSmallerThan5 a sum =
    if a=0 then sum
    elif (a%10)<5 then SumNumWhichAreSmallerThan5 (a/10) (sum+(a%10))
    else SumNumWhichAreSmallerThan5 (a/10) sum

///Оболочка SumNumWhichAreSmallerThan5
let ShellForSumNumWhichAreSmallerThan5 a = SumNumWhichAreSmallerThan5 a 0

///метод 3 
let rec MegaSearch a beg maxbeg sumnum=
    if beg>a then 
        printfn $"Максимальное число удов. условию - {maxbeg}"
        printfn $"Сумма цифр числа, меньших 5 - {ShellForSumNumWhichAreSmallerThan5 a}"
        maxbeg*(ShellForSumNumWhichAreSmallerThan5 a)
    elif (NOD a beg <> 1)&&(beg%sumnum <> 0) then MegaSearch a (beg+1) beg sumnum
    else MegaSearch a (beg+1) maxbeg sumnum

///Оболочка для метода 3
let  MegaShellForMegaSearch a = MegaSearch a 1 0 (ShellminDel a)

[<EntryPoint>]
let main argv =
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    printfn ""
    printfn $"Колво четных чисел, не взаимно простых с данным числом - {UberFunc a}"
    printfn ""
    if (ShellForSearch a) <> -1 then printfn $"Максимальная цифра числа, не делящуюся на 3 - {ShellForSearch a}"
    else printfn $"Максимальная цифра числа, не делящуюся на 3 - NULL"
    printfn ""
    printfn $"метод 3 - {MegaShellForMegaSearch a}"
    printfn ""
    0
