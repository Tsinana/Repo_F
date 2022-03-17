(*Задание 20. Напишите программу, в которой пользователь вводит кортеж
из двух чисел, где первое число это номер одной из трех функций вашего
варианта, второе число аргумент этой функции. Построить функцию,
которая принимает номер от 1 до 3 и возвращает одну из трех
написанных функций. Далее программа выполняет указанную функцию
и выдает результат на экран. Для реализации функции main использовать
только оператор каррирования, потом только оператор суперпозиции.*)

open System


open System

//---метод 1---

///Ф-ия нахождения greatest common divisor
let rec GCD a b =
    if (a%b)=0 then b
    else GCD b (a%b)

///Обход взаимнопростых
let rec Сoprime_Integers a init beg = 
    match beg with
    | _ when beg>a ->init
    | _ when ((beg%2)=0)&&((GCD a beg) <> 1 )->
    printfn $"НОД({a},{beg}) <> 1 и {beg} чет."
    Сoprime_Integers a (init+1) (beg+1)
    | _ -> Сoprime_Integers a init (beg+1)

///Оболочка для обхода ВП
let Shell_For_Сoprime_Integers a = Сoprime_Integers a 0 1

//---метод 2---

///Поиск максимальной цифры числа, не делящуюся на 3
let rec Finding_a_Maximum_Number_Not_Divisible_by_3 a (max:int) = 
    if a = 0 then max
    elif ((a%10)>max)&&((a%10%3<>0)) then Finding_a_Maximum_Number_Not_Divisible_by_3 (a/10) (a%10)
    else Finding_a_Maximum_Number_Not_Divisible_by_3 (a/10) max

///Оболочка для Finding_a_Maximum_Number_Not_Divisible_by_3
let Shell_For_Finding_a_Maximum_Number_Not_Divisible_by_3 a = Finding_a_Maximum_Number_Not_Divisible_by_3 a -1

//---метод 3---

///Ф-ия поиска наименьшего делителя исходно числа
let rec Finding_The_lowest_divisor_of_the_original_number a min =
    if a%min = 0 then min
    else Finding_The_lowest_divisor_of_the_original_number a (min+1)

/// Оболочка для Finding_The_lowest_divisor_of_the_original_number
let Shell_For_Finding_The_lowest_divisor_of_the_original_number a = Finding_The_lowest_divisor_of_the_original_number a 2

///Ф-ия поиска суммы цифр числа, меньших 5
let rec Sum_Num_Which_Are_Smaller_Than_5 a sum =
    if a=0 then sum
    elif (a%10)<5 then Sum_Num_Which_Are_Smaller_Than_5 (a/10) (sum+(a%10))
    else Sum_Num_Which_Are_Smaller_Than_5 (a/10) sum

///Оболочка Sum_Num_Which_Are_Smaller_Than_5
let Shell_For_Sum_Num_Which_Are_Smaller_Than_5 a = Sum_Num_Which_Are_Smaller_Than_5 a 0

///метод 3 
let rec MegaFinding_a_Maximum_Number_Not_Divisible_by_3 a beg maxbeg sumnum=
    if beg>a then 
        printfn $"Максимальное число удов. условию - {maxbeg}"
        printfn $"Сумма цифр числа, меньших 5 - {Shell_For_Sum_Num_Which_Are_Smaller_Than_5 a}"
        maxbeg*(Shell_For_Sum_Num_Which_Are_Smaller_Than_5 a)
    elif (GCD a beg <> 1)&&(beg%sumnum <> 0) then MegaFinding_a_Maximum_Number_Not_Divisible_by_3 a (beg+1) beg sumnum
    else MegaFinding_a_Maximum_Number_Not_Divisible_by_3 a (beg+1) maxbeg sumnum

///Оболочка для метода 3
let  MegaShellForMegaFinding_a_Maximum_Number_Not_Divisible_by_3 a = MegaFinding_a_Maximum_Number_Not_Divisible_by_3 a 1 0 (Shell_For_Finding_The_lowest_divisor_of_the_original_number a)


let select_fun = function
    | 1 -> 1
    | 2 -> 2
    | _ -> 3

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите номер функции и число")
    let a = (System.Convert.ToInt32(System.Console.ReadLine()),System.Convert.ToInt32(System.Console.ReadLine()))
    let result = select_fun 
    printfn "Результат применения функции №%d: %d" (fst opts) result
    0
