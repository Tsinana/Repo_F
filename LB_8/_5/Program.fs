// Learn more about F# at http://fsharp.org

open System

///Паспорт гражданина РФ
type Class_Id (fullName: string, sex: char, dob: DateTime, nationality: string, bpl: string, series: string, number: string,issued:string,doi:DateTime,departmentCode:string ) =
    member this.fullName: string = fullName.ToUpper()
    member this.sex: char = sex
    member this.dob: DateTime = dob
    member this.nationality: string = nationality
    member this.bpl: string = bpl.ToUpper()
    member this.series: string = series
    member this.number: string = number
    member this.seriesInt: int = Convert.ToInt32(series)
    member this.numberInt: int = Convert.ToInt32(number)
    member this.issued:string = issued.ToUpper()
    member this.doi:DateTime = doi
    member this.code: string = $"{departmentCode.[0]}{departmentCode.[1]}{departmentCode.[2]}-{departmentCode.[3]}{departmentCode.[4]}{departmentCode.[5]}"
    //методы
    member this.Compare(s:int,n:int) = if s=this.seriesInt&&n=this.numberInt then this.Print() else printf"Документ не найден\n"
    member this.Compare() = 
        printf"Введите серию паспорта: "
        let ser = Convert.ToInt32(Console.ReadLine())
        printf"Введите номер паспорта: "
        let num = Convert.ToInt32(Console.ReadLine())
        printf"\n"
        this.Compare(ser,num)
    member this.Print() = printf$"\nПаспорт гражданина РФ\n{this.fullName}\n
Пол      Дата рождения     Гражданство\n{this.sex}        {this.dob.ToShortDateString()}        {this.nationality}\n
Место рождения\n{this.bpl}\n
Серия и номер паспорта\n{this.series} {this.number}\n
Выдан\n{issued}\n
Дата выдачи     Код подразделения\n{this.doi.ToShortDateString()}      {this.code}\n"

[<EntryPoint>]
let main argv =
    let cl1 = Class_Id("Иванов Иван Иваныч", 'M',new DateTime(2000,01,01),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ","0123","012345","ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,01), "012345")
    cl1.Compare()

    
    0 // return an integer exit code
