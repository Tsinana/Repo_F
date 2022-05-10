(*Напишите программу, вводящую целые коэффициенты
многочлена и находящую все его рациональные корни.
*)
//Теорема. Для того чтобы несократимая дробь p/q была корнем уравнения an (q!<-0) xn + an-1 xn-1 + ... + a0 <- 0 с целыми коэффициентами, необходимо, чтобы число р было делителем свободного члена а0, а число q – делителем старшего коэффициента an (причем q¹0 и an¹0).
//Если уравнение имеет целые коэффициенты, а старший коэффициент равен единице (т.е. аn<-1), то рациональными корнями этого уравнения могут быть только целые числа, которые являются делителями свободного члена а0.
open System.Drawing
open System.Windows.Forms
open System
open System.Text.RegularExpressions



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



let form = new Form()
// 
// labelAr
// 
let labelAr = new Label()
labelAr.AutoSize <- true;
labelAr.Location <- new System.Drawing.Point(12, 9);
labelAr.Name <- "labelAr";
labelAr.Size <- new System.Drawing.Size(148, 13);
labelAr.TabIndex <- 0;
labelAr.Text <- "Коэффиценты многочлена: ";
form.Controls.Add(labelAr)
// 
// label1
// 
let label1 = new Label()
label1.AutoSize <- true;
label1.Location <- new System.Drawing.Point(12, 48);
label1.Name <- "label1";
label1.Size <- new System.Drawing.Size(121, 13);
label1.TabIndex <- 1;
label1.Text <- "Рациональные корни: ";
form.Controls.Add(label1)
// 
// textBox1
// 
let textBox1 = new TextBox()
textBox1.Location <- new System.Drawing.Point(166, 6);
textBox1.Name <- "textBox1";
textBox1.Size <- new System.Drawing.Size(100, 20);
textBox1.TabIndex <- 2;
form.Controls.Add(textBox1)
// 
// labelAns
// 
let labelAns = new Label()
labelAns.AutoSize <- true;
labelAns.Location <- new System.Drawing.Point(139, 48);
labelAns.Name <- "labelAns";
labelAns.Size <- new System.Drawing.Size(193, 13);
labelAns.TabIndex <- 3;
form.Controls.Add(labelAns)
// 
// button
// 
let button = new Button()
button.Location <- new System.Drawing.Point(15, 74);
button.Name <- "button";
button.Size <- new System.Drawing.Size(75, 23);
button.TabIndex <- 4;
button.Text <- "Найти";
button.UseVisualStyleBackColor <- true;
form.Controls.Add(button)

let rec read_array arr n (ololo:MatchCollection) =
    match n with
    |0->arr
    |_ ->
        let n1 = n - 1
        let a = ololo.Item n1
        let tail = Convert.ToInt32(a.Value)
        let newArr = Array.append arr [|tail|]
        read_array newArr n1 ololo

let fucButton _ = 
    let str0 = textBox1.Text
    let myReg = new Regex("-?[\d]+")
    let ololo = myReg.Matches(str0);
    let strAns =  (read_array Array.empty ololo.Count ololo)|>func|>string
    labelAns.Text <- strAns

button.Click.Add(fucButton)
// 
// Form1
// 
form.AutoScaleDimensions <- new System.Drawing.SizeF(6F, 13F);
form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize <- new System.Drawing.Size(551, 111);
form.Controls.Add(button);
form.Controls.Add(labelAns);
form.Controls.Add(textBox1);
form.Controls.Add(label1);
form.Controls.Add(labelAr);
form.Name <- "Form1";
form.Text <- "Form1";
form.ResumeLayout(false);
form.PerformLayout();
// Запускаем форму
do Application.Run(form)

[<EntryPoint>]
let main argv =
    0 // return an integer exit code
