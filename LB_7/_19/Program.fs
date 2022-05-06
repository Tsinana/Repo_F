(*Дана строка. Необходимо проверить, является ли она палиндромом.*)

open System
 
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



[<EntryPoint>]
let main argv =
    let str1 = Console.ReadLine()
    func_1 str1|>Console.WriteLine
    

    0 // return an integer exit code
