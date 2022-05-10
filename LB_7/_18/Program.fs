(*Напишите программу, вводящую целые коэффициенты
многочлена и находящую все его рациональные корни.
*)
//Теорема. Для того чтобы несократимая дробь p/q была корнем уравнения an (q!=0) xn + an-1 xn-1 + ... + a0 = 0 с целыми коэффициентами, необходимо, чтобы число р было делителем свободного члена а0, а число q – делителем старшего коэффициента an (причем q¹0 и an¹0).
//Если уравнение имеет целые коэффициенты, а старший коэффициент равен единице (т.е. аn=1), то рациональными корнями этого уравнения могут быть только целые числа, которые являются делителями свободного члена а0.
open System

///Иниц. массива
let init_array() = 
    let rec read_array arr n=
        match n with
        |0->arr
        |_ ->
            let tail = System.Convert.ToInt32(System.Console.ReadLine())
            let newArr = Array.append arr [|tail|]
            let n1 = n - 1
            read_array newArr n1
    Console.WriteLine("Введите n степень многочлена. Потом коэффиценты начиная с a0 по an")
    let a = read_array Array.empty (Convert.ToInt32(Console.ReadLine()))
    Console.WriteLine("Что-то было создано\n")
    a

///Вывод массива на экран
let write_array arr=
    printfn "%A" arr

///Math.Pow(int int)
let pow a b = 
    let rec pow_rec a b z=
        match b with
        |0-> z
        |_->
            let b1 = b-1
            let z1 = z * a
            pow_rec a b1 z1
    pow_rec a b 1

///Вывод списка на экран
let rec write_list = function
    [] -> let z = Console.ReadKey()
          0
    |   (head:string)::tail -> 
                   Console.WriteLine(head)
                   write_list tail 

///Функция решения задачи
let func (arr:int[]) =
    let lenght = arr.Length
    let p = Array.get arr 0
    let q = Array.get arr (lenght-1)

    let func_ololo p1 q1 arr newlist=
        let a = arr|>Array.mapi(fun i x -> x*(pow p1 i)/(pow q1 i))|>Array.sum
        if a = 0 then 
            if q1 = 1 then 
                let a = $"{p1}"
                newlist@[a]
            else
                let a = $"{p1}/{q1}"
                newlist@[a]
        else
            newlist
        

    let rec div_q i p1 newlist=
        if q <> 0 && i = 0 then div_q (i-1) p1 newlist
        else
            if -q <> i then 
                let i1 = i - 1
                let y = q%i
                if y=0 then 
                    let a = func_ololo p1 i arr newlist
                    div_q i1 p1 a
                else div_q i1 p1 newlist
            else
                newlist

    let rec div_p i newlist=
        if p <> 0 && i = 0 then div_p (i-1) newlist
        else
            if -(p+1) <> i then 
                let i1= i - 1
                let y = p % i
                if y=0 then 
                    let a = div_q q i newlist
                    div_p i1 a
                else div_p i1 newlist
            else 
                newlist
    div_p p []

[<EntryPoint>]
let main argv =
    let arr = init_array()
    func arr|>write_list

    0 // return an integer exit code
