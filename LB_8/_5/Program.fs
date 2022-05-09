open System
open System.Text.RegularExpressions
open System.Diagnostics

///Паспорт гражданина РФ
type Class_Id (fullName: string, sex: char, dob: DateTime, nationality: string, bpl: string, series: int, number: int,issued:string,doi:DateTime,departmentCode:int ) =
    
    member this.id: int = series*1000000+number
    
    member this.fullName: string = fullName.ToUpper()
    
    member this.sex: char = sex
    
    member this.dob: DateTime = dob
    
    member this.nationality: string = nationality
    
    member this.bpl: string = bpl.ToUpper()
    
    member this.series: string = 
        match series with
        |_ when series<10 -> $"000{series}"
        |_ when series<100 -> $"00{series}"
        |_ when series<1000 -> $"0{series}"
        |_ -> $"{series}"
    
    member this.number: string = 
        match number with
        |_ when number<10 -> $"00000{number}"
        |_ when number<100 -> $"0000{number}"
        |_ when number<1000 -> $"000{number}"
        |_ when number<10000 -> $"00{number}"
        |_ when number<100000 -> $"0{number}"
        |_ -> $"{number}"
    
    member this.seriesInt: int = series
    
    member this.numberInt: int = number
    
    member this.issued:string = issued.ToUpper()
    
    member this.doi:DateTime = doi
    
    member this.code: string = 
        match departmentCode with
        |_ when departmentCode<10 -> $"000-00{departmentCode}"
        |_ when departmentCode<100 -> $"000-0{departmentCode}"
        |_ when departmentCode<1000 -> $"000-{departmentCode}"
        |_ when departmentCode<10000 -> $"00{departmentCode/1000}-{departmentCode%1000}"
        |_ when departmentCode<100000 -> $"0{departmentCode/1000}-{departmentCode%1000}"
        |_ -> $"{departmentCode/1000}-{departmentCode%1000}"
    
    //методi
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
    
    override this.Equals(obj1) = 
        match obj1 with
        | :? Class_Id as license ->
            license.id = this.id
        | _ -> false
    
    interface IComparable with
        member this.CompareTo obj = 
            match obj with
            | :? Class_Id as license -> this.id.CompareTo(license.id)
            | _ -> 1
        end
    
    override this.GetHashCode() = this.id.GetHashCode()



[<AbstractClass>]
    type AbstractDocCatalog() =
        abstract member SearchDoc: Class_Id -> Boolean
    
type ListId(list: Class_Id list) =
    inherit AbstractDocCatalog()
    member this.list: Class_Id list = list
    override this.SearchDoc (doc: Class_Id) = 
        this.list |> List.exists (fun x -> x = doc)
    
type ArrayId(arr: Class_Id array) =
    inherit AbstractDocCatalog()
    member this.arr: Class_Id array = arr
    override this.SearchDoc (doc: Class_Id) = 
        this.arr |> Array.exists (fun x -> x = doc) 
    
type SetId(set: Class_Id Set) =
    inherit AbstractDocCatalog()
    member this.set: Class_Id Set = set
    override this.SearchDoc (doc: Class_Id) = 
        Set.contains doc this.set
        
type Tree<'a> = 
  | Empty
  | Node of value: 'a * left: Tree<'a> * right: Tree<'a>

type TreeId(tree:Tree<Class_Id>) =
    inherit AbstractDocCatalog()
    let exists doc tree =
        let rec SearchDoc tree =
            match tree with
            | Node (head, left, right) when head = doc->true
            | Node (head, left, right) when head<doc -> SearchDoc right
            | Node (head, left, right) when head>doc -> SearchDoc left
            | Empty -> false
        SearchDoc tree
    member this.tree: Tree<Class_Id>= tree
    override this.SearchDoc (doc: Class_Id) =
        exists doc this.tree



let CreateObjClassId() = 
    printf "Начат процесс создания новой записи!\nПри заполнении данных, пожалуйста, используйте только МОГУЧИЕ БУКВЫ и цифры. Иван-Иваныч следит за вами -_-\n\nВведите ФИО\n"
    let fullName = Console.ReadLine()
    let myReg = new Regex("([^А-Яа-я ])|([А-Я][А-Я])|([а-я]+[А-Я])|( [а-я]+)")
    
    printf"Введите пол используя символы 'M' и 'Ж'\n"
    let sex = Console.ReadLine()
    let myReg1 = new Regex("[^М^Ж]")
    
    printf "Введите дату рождения как - дд/мм/гггг\n"
    let dobS = Console.ReadLine()
    let myReg2 = new Regex("[^0-9/]") 
    let dob = Convert.ToDateTime(dobS)
    
    printf"Введите гражданство\n"
    let nat = Console.ReadLine()
    let myReg3 = new Regex("([^А-Яа-я ])|([А-Я][А-Я])|([а-я]+[А-Я])|( [а-я]+)")
    
    printf"Введите место рождения\n"
    let bpl = Console.ReadLine()
    let myReg4 = new Regex("[a-zA-Z0-9]")
    
    printf"Введите серию документа\n"
    let series = Convert.ToInt32(Console.ReadLine())
    
    printf"Введите номер документа\n"
    let number = Convert.ToInt32(Console.ReadLine())
    
    printf"Введите кем был выдан документ\n"
    let issued = Console.ReadLine()
    let myReg5 = new Regex("[a-zA-Z0-9]")
    
    printf"Введите дату выдачи как - дд/мм/гггг\n"
    let doiS = Console.ReadLine()
    let myReg6 = new Regex("[^0-9/]")
    let doi = Convert.ToDateTime(dobS)
    
    printf"Введите код выдачи\n"
    let cod = Convert.ToInt32(Console.ReadLine())
    
    if (cod<1000000)&&(cod>0)&&(number<1000000&&number>0)&&(series<10000&&series>0)&&(myReg4.IsMatch(bpl)=false&&myReg5.IsMatch(issued)=false&&myReg6.IsMatch(doiS)=false&&myReg3.IsMatch(nat)=false&&myReg2.IsMatch(dobS)=false&&myReg1.IsMatch(sex)=false&&myReg.IsMatch(fullName)=false) then 
        printf"\nЗапись создана успешно!\n"
        Class_Id(fullName,sex.[0],dob,nat,bpl,series,number,issued,doi,cod)
    else
        printf"\nИван-Иваныч нашел у Вас ошибку и теперь это его запись\n"
        Class_Id("Иванов Иван Иваныч", 'M',new DateTime(2000,01,01),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ",0123,012345,"ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,01), 012345)

let rec insert newValue (tree : Tree<'a>) =
  match tree with
  | Empty -> Node (newValue, Empty, Empty)
  | Node (value, left, right) when newValue < value ->
    let left' = insert newValue left
    Node (value, left', right)
  | Node (value, left, right) when newValue > value ->
    let right' = insert newValue right
    Node (value, left, right')
  | _ -> tree

[<EntryPoint>]
let main argv =
    let cl1 = Class_Id("Иванов Степан Иваныч", 'M',new DateTime(2000,01,01),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ",0123,012345,"ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,01), 012345)
    let cl2 = Class_Id("Иванов Иван Иваныч", 'M',new DateTime(2000,01,02),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ",987,987654,"ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,02), 987654)
    let cl3 = Class_Id("Иванов Михайло Иваныч", 'M',new DateTime(2000,01,03),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ",0198,012398,"ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,03), 012398)
    
    let random = System.Random()
    let tree =
        Node (cl1, Empty, Empty)
    let randomList = [ for i in 1 .. 10000 -> Class_Id("Иванов Иван Иваныч", 'M',new DateTime(2000,01,01),"Россия","ГОР. ТУАПСЕ КРАСНОДАРСКОГО КРАЯ",random.Next(1,9999),random.Next(1,999999),"ОТДЕЛОМ УФМС РОССИИ ПО КРАСНОДАРСКОМУ КРАЮ В ТУАПСИНСКОМ РАЙОНЕ",new DateTime(2014,01,01), random.Next(100000,999999))]
    
    let rec init i tree = 
        match i with
        |0-> tree
        |_->
            let i1 = i - 1 
            let tree1 = insert randomList.[i] tree
            init i1 tree1

    let tree = init 9998 tree


    let listId = ListId(randomList)
    let arrId = ArrayId(List.toArray randomList)
    let setId = SetId(Set.ofList randomList)
    let treeId = TreeId(tree)

    let timer = System.Diagnostics.Stopwatch.StartNew()
    let res1 = listId.SearchDoc(randomList.[50])
    timer.Stop()

    let timer1 = System.Diagnostics.Stopwatch.StartNew()
    let res2 = arrId.SearchDoc(randomList.[50])
    timer1.Stop()

    let timer2 = System.Diagnostics.Stopwatch.StartNew()
    let res3 = setId.SearchDoc(randomList.[50])
    timer2.Stop()

    let timer3 = System.Diagnostics.Stopwatch.StartNew()
    let res4 = treeId.SearchDoc(randomList.[50])
    timer3.Stop()

    printfn "elapsed=%O" timer.Elapsed
    Console.WriteLine(res1)
    printfn "elapsed=%O" timer1.Elapsed
    Console.WriteLine(res2)
    printfn "elapsed=%O" timer2.Elapsed
    Console.WriteLine(res3)
    printfn "elapsed=%O" timer3.Elapsed
    Console.WriteLine(res4)
    0



