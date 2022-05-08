// Learn more about F# at http://fsharp.org

open System

///Паспорт гражданина РФ
type Id (fullName: string, sex: char, dob: DateTime, nationality: string, bpl: string, series: int, number: int,issued:string,doi:DateTime,department:string,code:int ) =
    member this.fullName: string = fullName
    member this.sex: char = sex
    member this.dob: DateTime = dob
    member this.nationality: string = nationality
    member this.bpl: string = bpl
    member this.series: int = series
    member this.number: int = number
    member this.issued:string = issued
    member this.doi:DateTime = doi
    member this.department:string = department
    member this.code: int = code
     

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
